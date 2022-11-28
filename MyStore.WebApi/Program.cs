using Microsoft.EntityFrameworkCore;
using MyStore.Domain.Repositories;
using MyStore.Domain.Services;
using MyStore.Data.Ef.Data;
using MyStore.Data.Ef.Repositories;
using Microsoft.AspNetCore.Identity;
using MyStore.Models;
using Microsoft.AspNetCore.HttpLogging;

var builder = WebApplication.CreateBuilder(args);

var dbPath = "myapp.db";
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(
   options => options.UseSqlite($"Data Source={dbPath}"));

//builder.Services.AddScoped<AppDbContext>(_ => new AppDbContext($"D"));


builder.Services.AddCors();

/*// регистрация GenericRepository
builder.Services.AddScoped(
    typeof(IRepository<>), typeof(EfRepository<>));*/

builder.Services.AddScoped<IProductsRepository, ProductRepository>();
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<IAccountRepository, AccountRepository>();

builder.Services.AddControllers();

builder.Services.Configure<PasswordHasherOptions>(
   opt => opt.IterationCount = 100_000);
builder.Services.AddSingleton<IPasswordHasher<Account>, PasswordHasher<Account>>();

builder.Services.AddHttpLogging(options =>
{
    options.LoggingFields = HttpLoggingFields.RequestHeaders
                            | HttpLoggingFields.ResponseHeaders
                            | HttpLoggingFields.RequestBody
                            | HttpLoggingFields.ResponseBody;
});


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

app.Use(async (context, next) =>
{
    var userAgent = context.Request.Headers.UserAgent.ToString();
    if (userAgent.Contains("Edg"))
    {
        await next();
    }
    else
    {
        context.Response.Headers.ContentType = "text/plain; charset=utf-8";
        await context.Response.WriteAsync("Ваш браузер не поддерживается. Воспользуйтесь браузером MS Edge");
    }
});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseHttpLogging();

app.MapControllers();

app.Run();
