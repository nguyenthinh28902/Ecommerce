using Authentication.Service.DependencyInjections;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddHttpContextAccessor();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddServiceLayer(builder.Configuration);
builder.Services.AddControllersWithViews();
builder.Services.AddAuthentication()
       .AddCookie(options =>
       {
           options.Cookie.Name = "UserCookie";
           options.LoginPath = "/Account/Login";
           options.AccessDeniedPath = "/Account/AccessDenied";
       })
       .AddCookie("CustomerCookie", options =>
       {
           options.Cookie.Name = "CustomerCookie";
           options.LoginPath = "/CustomerAccount/Login";
           options.AccessDeniedPath = "/CustomerAccount/AccessDenied";
       });
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminOnly", policy => policy.RequireRole("Admin"));
    options.AddPolicy("CustomerOnly", policy => policy.RequireRole("Customer"));
});
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
