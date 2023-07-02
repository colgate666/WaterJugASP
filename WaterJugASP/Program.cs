using WaterJugASP;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

Router.RegisterWaterJugEndpoints(app);

app.Run();
