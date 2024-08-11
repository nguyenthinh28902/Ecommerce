using Authentication.Admin.Api.Register;
using Authentication.Service.DependencyInjections;
using Authentication.Service.ViewModel;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddServiceLayer(builder.Configuration);
builder.Services.AddRegisterConfiguration(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(op => {
        op.DisplayRequestDuration();
    });
}

app.Services.ServiceProvider();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
