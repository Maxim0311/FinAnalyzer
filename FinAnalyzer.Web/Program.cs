using FinAnalyzer.Common;
using FinAnalyzer.Data.EntityFramework;
using FinAnalyzer.Web;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using StafferyInternal.StafferyInternal.Common;
using StafferyInternal.StafferyInternal.Web.Middleware;
using System.Reflection;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

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

builder.Services.AddDbContext<AppDbContext>(options => options.UseNpgsql(
    builder.Configuration.GetConnectionString("FinAnalyzerDb")));

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

app.UseAuthorization();

app.MapControllers();

app.Run();