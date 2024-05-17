namespace ConsuleAndVault.EventHandler
{
    public interface IEventHandler
    {
        Task GetConfigurationVariables(IConfiguration configuration);
    }
}
