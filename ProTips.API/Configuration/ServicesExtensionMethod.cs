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
            options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));
    }
    public static void AddServices(this IServiceCollection services)
    {
        services.AddScoped<ITeamService, TeamService>();
    }
    
    public static void AddRepositories(this IServiceCollection services)
    {
        services.AddTransient<Repository<Team>, TeamRepository>();
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