using FinAnalyzer.Core.Services.Implementation;
using FinAnalyzer.Core.Services.Interfaces;
using FinAnalyzer.Data.EntityFramework.Repositories.Implementation;
using FinAnalyzer.Data.EntityFramework.Repositories.Interfaces;

namespace FinAnalyzer.Web;

public static class FinAnalyserDI
{
    public static IServiceCollection AddRepositoriesDI(this IServiceCollection services)
    {
        return services
            .AddScoped<IRoomRepository, RoomRepository>()
            .AddScoped<IPersonRepository, PersonRepository>()
            .AddScoped<IPersonAccountRepository, PersonAccountRepository>()
            .AddScoped<IRoomAccountRepository, RoomAccountRepository>()
            .AddScoped<IThirdPartyAccountRepository, ThirdPartyAccountRepository>()
            .AddScoped<IAccountRepository, AccountRepository>()
            .AddScoped<IGlobalRoleRepository, GlobalRoleRepository>()
            .AddScoped<IPersonRoomRepository, PersonRoomRepository>();
    }

    public static IServiceCollection AddServicesDI(this IServiceCollection services)
    {
        return services
            .AddScoped<IRoomService, RoomService>()
            .AddScoped<IAuthService, AuthService>();
    }

    public static IServiceCollection AddValidatorsDI(this IServiceCollection services)
    {
        return services;
    }
}

