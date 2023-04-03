using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.EntityFrameworkCore;
using ProTips.Business.Services;
using ProTips.Business.Services.Interfaces;
using ProTips.Entity.Database;
using ProTips.Entity.Models;
using ProTips.Entity.Repository;
using ProTips.Entity.Repository.Interfaces;

namespace ProTips.API.Configuration;

public static class ServicesExtensionMethod
{
    public static void AddMySqlContext(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<MySqlContext>(options =>
            options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)).EnableDetailedErrors()
        );
    }
    public static void AddServices(this IServiceCollection services)
    {
        services.AddScoped<ITeamService, TeamService>();
        services.AddScoped<ICountryService, CountryService>();
        services.AddScoped<ILeagueService, LeagueService>();
        services.AddScoped<IResultService, ResultService>();
        services.AddScoped<IGameService, GameService>();
        services.AddScoped<IBetStrategyService, BetStrategyService>();
        services.AddScoped<IBetService, BetService>();
        services.AddScoped<ILinkService, LinkService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IWalletService, WalletService>();
        services.AddScoped<IWalletTransactionService, WalletTransactionService>();
    }
    
    public static void AddRepositories(this IServiceCollection services)
    {
        services.AddTransient<ITeamRepository, TeamRepository>();
        services.AddTransient<ICountryRepository, CountryRepository>();
        services.AddTransient<ILeagueRepository, LeagueRepository>();
        services.AddTransient<IResultRepository, ResultRepository>();
        services.AddTransient<IGameRepository, GameRepository>();
        services.AddTransient<IBetStrategyRepository, BetStrategyRepository>();
        services.AddTransient<IBetRepository, BetRepository>();
        services.AddTransient<ILinkRepository, LinkRepository>();
        services.AddTransient<IUserRepository, UserRepository>();
        services.AddTransient<IWalletRepository, WalletRepository>();
        services.AddTransient<IWalletTransactionRepository, WalletTransactionRepository>();
    }
    
    public static void AddVersioning(this IServiceCollection services)
    {
        services.AddApiVersioning(opt =>
        {
            opt.DefaultApiVersion = new Microsoft.AspNetCore.Mvc.ApiVersion(1,0);
            opt.AssumeDefaultVersionWhenUnspecified = true;
            opt.ReportApiVersions = true;
            opt.ApiVersionReader = ApiVersionReader.Combine(new UrlSegmentApiVersionReader(),
                new HeaderApiVersionReader("x-api-version"),
                new MediaTypeApiVersionReader("x-api-version"));
        });
        
        services.AddVersionedApiExplorer(p =>
        {
            p.GroupNameFormat = "'v'VVV";
            p.SubstituteApiVersionInUrl = true;
        });
    }
}