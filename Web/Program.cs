using Infrastructure.Data;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
var connection = builder.Configuration.GetConnectionString("Default");
builder.Services.AddDbContext<DataContext>(conf => conf.UseNpgsql(connection));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddScoped<DataContext>();
builder.Services.AddScoped<CompanyService>();
builder.Services.AddScoped<EmployeeService>();
builder.Services.AddScoped<EmployeeAddressService>();
builder.Services.AddScoped<SkillService>();
builder.Services.AddScoped<EmployeeSkillService>();
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

app.Run();
