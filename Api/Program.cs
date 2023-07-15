using AutoMapper;
using Business;
using DataAcess.Api.Interfase;
using DataAcess.Context;
using DataAcess.Repositories;
using Microsoft.Data.SqlClient;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddHttpClient<ApiFlight>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IApiFlight,ApiFlight>();
builder.Services.AddTransient<IRepositoryFlight,RepositoryFlight>();
builder.Services.AddTransient<IBusinessRuta, BusinessRuta>();
builder.Services.AddTransient<IBusinessFlight, BusinessFlight>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddLogging(builder =>
{
    builder.AddConsole(); // Opcional: Registra los logs en la consola
                          // Otros proveedores de logs: AddDebug, AddEventLog, AddAzureLogAnalytics, etc.
});
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

app.Run();
