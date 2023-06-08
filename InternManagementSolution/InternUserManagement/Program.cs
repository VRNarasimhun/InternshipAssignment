using InternUserManagement.Models;
using InterUserManagementAPI.Interfaces;
using InterUserManagementAPI.Services;
using JWTAuthenticationExample.Interfaces;
using JWTAuthenticationExample.Services;
using Microsoft.EntityFrameworkCore;
using UserManagementAPI.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(opts =>

{
    opts.AddPolicy("AngularCORS", options =>
    {
        options.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
    });
});

/// User defined services 
builder.Services.AddDbContext<UserContext>(opts =>
{
    opts.UseSqlServer(builder.Configuration.GetConnectionString("MyConn"));
});
builder.Services.AddScoped<IRepo<int, User>, UserRepo>();
builder.Services.AddScoped<IRepo<int, Intern>, InternRepo>();
builder.Services.AddScoped<IGeneratePassword , GeneratePasswordService>();
builder.Services.AddScoped<IGenerateToken, TokenService>();
builder.Services.AddScoped<IManageUser, ManageUserService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("AngularCORS");

app.UseAuthorization();

app.MapControllers();

app.Run();
