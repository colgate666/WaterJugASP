using WaterJugASP.Handlers;

namespace WaterJugASP
{
    public static class Router
    {
        public static void RegisterWaterJugEndpoints(WebApplication app)
        {
            var handler = new WaterJugHandler();

            app.MapGet("/waterjug/status", handler.HandleGet);
            app.MapPost("/waterjug", handler.HandlePost);
        }
    }
}
