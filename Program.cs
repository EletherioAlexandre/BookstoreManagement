using GerenciadorDeLivraria.Dtos;
using GerenciadorDeLivraria.Entities;
using GerenciadorDeLivraria.Interfaces;
using GerenciadorDeLivraria.Models;
using GerenciadorDeLivraria.Repositories;
using GerenciadorDeLivraria.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddRouting(options => options.LowercaseUrls = true);

builder.Services.AddScoped<IBaseRepository<LivroRequestDto, LivroResponse>, LivrariaRepository>();

builder.Services.AddScoped<ILivrariaService, LivrariaService>();


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
