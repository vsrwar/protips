using System.Text.Json.Serialization;
using ProTips.API.Configuration;
using ProTips.Entity.Database;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddJsonOptions(jsonOptions =>
    {
        jsonOptions.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    });

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddVersioning();
#if DEBUG
    builder.Services.AddMySqlContext(builder.Configuration.GetSection("ConnectionStrings")["MySql"]);
#else
    builder.Services.AddMySqlContext(Environment.GetEnvironmentVariable("MYSQL_CONNECTION_STRING"));
#endif
builder.Services.AddServices();
builder.Services.AddRepositories();

var app = builder.Build();

app.UseMyErrorHandler();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();