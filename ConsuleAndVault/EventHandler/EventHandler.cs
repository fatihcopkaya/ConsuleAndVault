
using ConsuleAndVault.Services;

namespace ConsuleAndVault.EventHandler
{
    public class EventHandler : IEventHandler
    {
        public delegate Task XConfigurationManager(IConfiguration configuration);
        
        public event XConfigurationManager ConfigurationChanged;
        
        private readonly IServices _services;

        public EventHandler(IServices services)
        { 
            _services = services;
            ConfigurationChanged += _services.InitializeVault;
            ConfigurationChanged += _services.InitializeConsul;

        }
        
        public async Task GetConfigurationVariables(IConfiguration configuration)
        {
            
            await ConfigurationChanged(configuration);

        }
    }
}
