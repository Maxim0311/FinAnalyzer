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
            .AddScoped<IAccountRepository, AccountRepository>()
            .AddScoped<IAccountTypeRepository, AccountTypeRepository>()
            .AddScoped<IGlobalRoleRepository, GlobalRoleRepository>()
            .AddScoped<IPersonRoomRepository, PersonRoomRepository>()
            .AddScoped<ITransactionRepository, TransactionRepository>()
            .AddScoped<ICategoryRepository, CategoryRepository>();
    }

    public static IServiceCollection AddServicesDI(this IServiceCollection services)
    {
        return services
            .AddScoped<IRoomService, RoomService>()
            .AddScoped<IAuthService, AuthService>()
            .AddScoped<ICategoryService, CategoryService>()
            .AddScoped<ITransactionService, TransactionService>()
            .AddScoped<IAccountService, AccountService>()
            .AddScoped<IStatisticService, StatisticService>();
    }

    public static IServiceCollection AddValidatorsDI(this IServiceCollection services)
    {
        return services;
    }

}

