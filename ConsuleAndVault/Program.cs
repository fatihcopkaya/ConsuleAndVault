using VaultSharp.V1.AuthMethods.Token;
using VaultSharp;
using Winton.Extensions.Configuration.Consul;
using ConsuleAndVault.EventHandler;
using EventHandler = ConsuleAndVault.EventHandler.EventHandler;
using ConsuleAndVault.Middlewares;
using ConsuleAndVault;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
IOC.ConfigureServices(builder.Services);

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseMiddleware<ConfigurationMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

