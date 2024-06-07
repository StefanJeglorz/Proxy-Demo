using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;
using Models.Interfaces;
using Proxy_API.DB;
using Proxy_API.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<APIDataContext>(options =>
{
    options.UseInMemoryDatabase("API");
});

builder.Services.AddTransient<ISeedingUnit, SeedingUnit>();
builder.Services.AddTransient<IProjectUseCases, ProjectUseCases>();

var app = builder.Build();

using IServiceScope scope = app.Services.CreateScope();
var seeding = scope.ServiceProvider.GetRequiredService<ISeedingUnit>();
await seeding.SeedData();
scope.Dispose();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet($"/api/{nameof(Project)}/{nameof(IProjectUseCases.GetProjectsAsync)}", ([FromServices] IProjectUseCases projectUseCases) => projectUseCases.GetProjectsAsync())
.WithName(nameof(IProjectUseCases.GetProjectsAsync))
.WithOpenApi();

app.Run();
