using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Netflix_Clone.API.Extensions;
using Netflix_Clone.Application.Services;
using Netflix_Clone.Application.Services.FileOperations;
using Netflix_Clone.Application.Services.IServices;
using Netflix_Clone.Domain;
using Netflix_Clone.Domain.Entities;
using Netflix_Clone.Domain.Options;
using Netflix_Clone.Infrastructure.DataAccess.Data.Contexts;
using Serilog;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

//swagger interface for authentication
builder.Services.ConfigureSwagger();

//configure the options:
builder.Services.Configure<ContentMovieOptions>(builder.Configuration.GetSection("Content:Movies"));
builder.Services.Configure<ContentTVShowOptions>(builder.Configuration.GetSection("Content:TVShows"));
builder.Services.Configure<UserRolesOptions>(builder.Configuration.GetSection("UserRoles"));
builder.Services.Configure<JwtOptions>(builder.Configuration.GetSection("Jwt"));

//register the JWT Authentication:
builder.Services.ConfigureJwtBearerAuthentication();
builder.Services.AddAuthorization();

//configure the logger
var logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .Enrich.FromLogContext()
    .CreateLogger();
builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);

builder.Services.AddLogging(loggingBuilder =>
{
    loggingBuilder.AddSerilog();
});

builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

//register db context
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
    options.EnableSensitiveDataLogging();
});

//configure the mediator:
builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
});

builder.Services.RegisterMapsterConfigurations();
builder.Services.AddScoped<IFileCompressor, FileCompressor>();
builder.Services.AddScoped<IFileManager, FileManager>();
builder.Services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseStaticFiles();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
