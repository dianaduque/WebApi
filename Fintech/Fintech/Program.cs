using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Fintech.Models;
using AutoMapper;
using Fintech.DTOs;
using Fintech.DA;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<FintechContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("FintechContext") ?? throw new InvalidOperationException("Connection string 'FintechContext' not found.")));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Mapper
var config = new MapperConfiguration(cfg =>
{
    cfg.AddProfile(new AutoMapperProfile());
});

var mapper = config.CreateMapper();

builder.Services.AddSingleton(mapper);
//Fin Mapper

//Injectar servies
builder.Services.AddTransient<IUserDA, UserDA>();
builder.Services.AddTransient<ICreditRequestsDA, CreditRequestsDA>();
//FinInjectar servies

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
