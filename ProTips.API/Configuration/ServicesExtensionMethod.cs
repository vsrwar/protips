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
            options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
        );
    }
    public static void AddServices(this IServiceCollection services)
    {
        services.AddScoped<IService<Team>, TeamService>();
        services.AddScoped<IService<Country>, CountryService>();
        services.AddScoped<IService<League>, LeagueService>();
        services.AddScoped<IService<Result>, ResultService>();
        services.AddScoped<IService<Game>, GameService>();
        services.AddScoped<IService<BetStrategy>, BetStrategyService>();
        services.AddScoped<IService<Bet>, BetService>();
    }
    
    public static void AddRepositories(this IServiceCollection services)
    {
        services.AddTransient<IRepository<Team>, TeamRepository>();
        services.AddTransient<IRepository<Country>, CountryRepository>();
        services.AddTransient<IRepository<League>, LeagueRepository>();
        services.AddTransient<IRepository<Result>, ResultRepository>();
        services.AddTransient<IRepository<Game>, GameRepository>();
        services.AddTransient<IRepository<BetStrategy>, BetStrategyRepository>();
        services.AddTransient<IRepository<Bet>, BetRepository>();
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