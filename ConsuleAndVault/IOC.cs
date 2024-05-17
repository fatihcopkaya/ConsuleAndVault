
using ConsuleAndVault.Services;
using ConsuleAndVault.EventHandler;

namespace ConsuleAndVault
{
    public class IOC
    {
        public static void ConfigureServices(IServiceCollection services)
        {             
                services.AddScoped<IServices, ConsuleAndVault.Services.Services>();
                services.AddScoped<IEventHandler, ConsuleAndVault.EventHandler.EventHandler>(); 
            
        }
    }
}
