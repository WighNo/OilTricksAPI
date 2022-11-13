using OilTricksAPI.Data;

var builder = WebApplication.CreateBuilder(args);

IServiceCollection services = builder.Services;
IConfiguration configuration = builder.Configuration;

// Add services to the container.

services.AddControllers();
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

AccessSettings accessSettings = new();
configuration.Bind("DefaultAccessSettings", accessSettings);

TanksSettings tanksSettings = new();
configuration.Bind("DefaultTankSettings", tanksSettings);

services.AddSingleton(tanksSettings);
services.AddSingleton(accessSettings);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();