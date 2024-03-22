using Hellang.Middleware.ProblemDetails;
using RestaurantManagement.API.Extensions;
using RestaurantManagement.Application;
using RestaurantManagement.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

var configurationBuilder = new ConfigurationBuilder();

var environment = builder.Environment.EnvironmentName;

IConfiguration configuration = configurationBuilder
    .AddJsonFile($"appsettings.{environment}.json")
    .Build();

// Add services to the container.
builder.Services.AddApplication();
builder.Services.AddInfrastructure(configuration);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseProblemDetails();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.AddConsoleLifetime(app.Environment);

app.Run();
