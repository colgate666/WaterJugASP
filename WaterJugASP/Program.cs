using FluentValidation;
using WaterJugASP;
using WaterJugASP.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<IValidator<WaterJugModel>, WaterJugModelValidator>();

var app = builder.Build();

Router.RegisterWaterJugEndpoints(app);

app.Run();
