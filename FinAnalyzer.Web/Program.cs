using FinAnalyzer.Common;
using FinAnalyzer.Common.Auth;
using FinAnalyzer.Data.EntityFramework;
using FinAnalyzer.Web;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using StafferyInternal.StafferyInternal.Common;
using StafferyInternal.StafferyInternal.Web.Middleware;
using System.Reflection;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = Assembly.GetExecutingAssembly().GetName().Name,
    });

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please insert JWT with Bearer into field",
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        BearerFormat = "bearer",
        Scheme = "Bearer"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement {
        {
            new OpenApiSecurityScheme
            {
            Reference = new OpenApiReference
            {
                Type = ReferenceType.SecurityScheme,
                Id = "Bearer"
            }
            },
            new string[] { }
        }
    });

    var xmlCommentsPath = Path.ChangeExtension(Assembly.GetExecutingAssembly().Location, "xml");
    c.IncludeXmlComments(xmlCommentsPath);
});

builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.InvalidModelStateResponseFactory = context =>
    {
        var errorMessages = context.ModelState.Values.Select(x => x.Errors.Select(y => y.ErrorMessage).ToList()).ToList();
        var commandResult = OperationResult.Fail(OperationCode.ValidationError, JsonSerializer.Serialize(errorMessages));
        var result = new BadRequestObjectResult(commandResult);
        return result;
    };
});

var authOp = configuration.GetSection("Auth").Get<AuthOptions>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.RequireHttpsMetadata = false;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = authOp.Issuer,
            ValidateAudience = true,
            ValidAudience = authOp.Audience,
            ValidateLifetime = true,
            IssuerSigningKey = authOp.GetSymmetricSecurityKey(),
            ValidateIssuerSigningKey = true
        };
    });

builder.Services.AddDbContext<AppDbContext>(options => options.UseNpgsql(
    builder.Configuration.GetConnectionString("FinAnalyzerDb")));

builder.Services.Configure<AuthOptions>(configuration.GetSection("Auth"));

builder.Services.AddRepositoriesDI();
builder.Services.AddServicesDI();
builder.Services.AddValidatorsDI();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ErrorHandlingMiddleware>();

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();