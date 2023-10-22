using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.EntityFrameworkCore;
using SmartInvest.Dtos.PortafolioDTO;
using SmartInvest.Repositories;
using SmartInvest.Services;

var builder = WebApplication.CreateBuilder(args);

var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .Build();

string aesKey = configuration.GetSection("AppSettings:AESKey").Value;

var connectionString = configuration.GetConnectionString("connectionDB");

builder.Services.AddDbContext<UsuarioDBContext>(builderContext =>
builderContext.UseSqlServer(connectionString));
builder.Services.AddScoped<UsuarioService>();

builder.Services.AddDbContext<AccionDBContext>(builderContext =>
builderContext.UseSqlServer(connectionString));
builder.Services.AddScoped<AccionService>();

builder.Services.AddDbContext<TransaccionDBContext>(builderContext =>
builderContext.UseSqlServer(connectionString));
builder.Services.AddScoped<TransaccionService>();

builder.Services.AddDbContext<CuentaDBContext>(builderContext =>
builderContext.UseSqlServer(connectionString));
builder.Services.AddScoped<CuentaService>();
builder.Services.AddScoped<AESEncriptadorService>();
builder.Services.AddScoped<LoginService>();
builder.Services.AddScoped<PortafolioService>();




// Add services to the container.
builder.Services.AddControllers();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader();

    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
