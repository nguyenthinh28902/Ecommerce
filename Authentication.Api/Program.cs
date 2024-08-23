using Authentication.User.Api.Registers;
using Authentication.User.Service.DependencyInjections;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRegisterConfiguration(builder.Configuration);
builder.Services.AddServiceLayer(builder.Configuration);
builder.Services.AddControllers();
builder.Services.AddHttpContextAccessor();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.Services.ServiceProvider();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
