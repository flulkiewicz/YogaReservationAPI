global using YogaReservationAPI.Dtos.YogaClass;
global using YogaReservationAPI.Models;
global using AutoMapper;
global using FluentValidation;
using Microsoft.EntityFrameworkCore;
using YogaReservationAPI.Data;
using YogaReservationAPI.Services.YogaClass;
using YogaReservationAPI.Middleware;
using NLog.Web;
using YogaReservationAPI.Data.Auth;
using YogaReservationAPI.Dtos.User;
using YogaReservationAPI.Dtos.Validators;
using FluentValidation.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.ClearProviders();
builder.Host.UseNLog();
// Add services to the container.
builder.Services.AddScoped<ErrorHandlingMiddleware>();
builder.Services.AddScoped<RequestTimeMiddleware>();

builder.Services.AddDbContext<DataContext>(options => 
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddControllers().AddFluentValidation();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(Program).Assembly);
builder.Services.AddScoped<IValidator<UserRegisterDto>, UserRegisterDtoValidator>();
builder.Services.AddScoped<IYogaClassService, YogaClassService>();
builder.Services.AddScoped<IAuthRepository, AuthRepository>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ErrorHandlingMiddleware>();
app.UseMiddleware<RequestTimeMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
