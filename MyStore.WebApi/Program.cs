using MyStore.Models;
using Microsoft.AspNetCore.Mvc;
using MyStore.WebApi.Data;
using Microsoft.EntityFrameworkCore;
using MyStore.WebApi.Repositories;
using MyStore.WebApi.Repositories.GenericRepository;
using MyStore.WebApi.Services;

var builder = WebApplication.CreateBuilder(args);

var dbPath = "myapp.db";
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(
   options => options.UseSqlite($"Data Source={dbPath}"));

builder.Services.AddCors();

/*// регистрация GenericRepository
builder.Services.AddScoped(
    typeof(IRepository<>), typeof(EfRepository<>));*/

builder.Services.AddScoped<IProductsRepository, ProductRepository>();
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<IAccountRepository, AccountRepository>();

builder.Services.AddControllers();
var app = builder.Build();

// CORS
app.UseCors(policy => policy
    .AllowAnyMethod()
    .AllowAnyHeader()
    .SetIsOriginAllowed(origin =>
        origin is "https://localhost:7074"
            or "http://localhost:5259")
    .AllowCredentials()
);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


// "/add_product" - RPC
// "/catalog/products" - REST


app.MapControllers();

app.Run();
