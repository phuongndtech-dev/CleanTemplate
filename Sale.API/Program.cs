using Sale.API.Extensions;
using Sale.Infrastructure;
using Sale.Application;
using Sale.Application.Services.Customers;

var builder = WebApplication.CreateBuilder(args);

var configurationBuilder = new ConfigurationBuilder();
IConfiguration configuration = configurationBuilder.Build();

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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.AddConsoleLifetime(app.Environment);

app.Run();
