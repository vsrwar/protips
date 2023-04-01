using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.EntityFrameworkCore;
using ProTips.Business.Services;
using ProTips.Business.Services.Interfaces;
using ProTips.Entity.Database;
using ProTips.Entity.Models;
using ProTips.Entity.Repository;

namespace ProTips.API.Configuration;

public static class ServicesExtensionMethod
{
    public static void AddMySqlContext(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<MySqlContext>(options =>
            options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
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
    }
    
    public static void AddRepositories(this IServiceCollection services)
    {
        services.AddTransient<Repository<Team>, TeamRepository>();
        services.AddTransient<Repository<Country>, CountryRepository>();
        services.AddTransient<Repository<League>, LeagueRepository>();
        services.AddTransient<Repository<Result>, ResultRepository>();
        services.AddTransient<Repository<Game>, GameRepository>();
        services.AddTransient<Repository<BetStrategy>, BetStrategyRepository>();
        services.AddTransient<Repository<Bet>, BetRepository>();
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