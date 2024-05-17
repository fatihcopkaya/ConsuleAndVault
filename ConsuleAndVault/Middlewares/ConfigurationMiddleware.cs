using ConsuleAndVault.EventHandler;

namespace ConsuleAndVault.Middlewares
{
    public class ConfigurationMiddleware
    {
        private readonly RequestDelegate _next;

        public ConfigurationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, IEventHandler eventHandler, IConfiguration configuration)
        {
           
            await eventHandler.GetConfigurationVariables(configuration);           
            await _next(context);
        }
    }
}
