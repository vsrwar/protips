using System.Text.Json.Serialization;
using Microsoft.OpenApi.Models;
using ProTips.API.Configuration;
using ProTips.Entity.Database;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new() { Title = "ProTips.API", Version = "v1" });
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme() 
    { 
        Name = "Authorization", 
        Type = SecuritySchemeType.ApiKey, 
        Scheme = "Bearer", 
        BearerFormat = "JWT", 
        In = ParameterLocation.Header, 
        Description = "JWT Authorization header using the Bearer scheme." +
                      "\r\n\r\n Enter 'Bearer' [space] and then your token in the text input below." +
                      "\r\n\r\nExample: \"Bearer 12345abcdef\"", 
    }); 
    options.AddSecurityRequirement(new OpenApiSecurityRequirement 
    { 
        { 
            new OpenApiSecurityScheme 
            { 
                Reference = new OpenApiReference 
                { 
                    Type = ReferenceType.SecurityScheme, 
                    Id = "Bearer" 
                } 
            }, 
            new string[] {} 
        } 
    });
});

builder.Services.AddVersioning();
#if DEBUG
    builder.Services.AddMySqlContext(builder.Configuration.GetSection("ConnectionStrings")["MySql"]);
#else
    builder.Services.AddMySqlContext(Environment.GetEnvironmentVariable("MYSQL_CONNECTION_STRING"));
#endif
builder.Services.AddServices();
builder.Services.AddRepositories();
builder.Services.AddAuth(
    builder.Configuration.GetSection("Jwt")["Issuer"],
    builder.Configuration.GetSection("Jwt")["Audience"],
    builder.Configuration.GetSection("Jwt")["SecretKey"]
);

var app = builder.Build();

app.UseMyErrorHandler();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();