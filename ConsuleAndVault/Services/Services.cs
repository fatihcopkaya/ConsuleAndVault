
using VaultSharp.V1.AuthMethods.Token;
using VaultSharp;
using Microsoft.Extensions.Configuration;
using Winton.Extensions.Configuration.Consul;

namespace ConsuleAndVault.Services
{
    public class Services : IServices
    {
        public async Task InitializeConsul(IConfiguration configuration)
        {
            var configurationBuilder = new ConfigurationBuilder()
                                       .AddConfiguration(configuration)
                                       .AddConsul(
                            "myapp/config/db",
                            options =>
                            {
                                options.ConsulConfigurationOptions = cco =>
                                {
                                    cco.Address = new Uri(configuration["CONSUL_ADDRESS"]);
                                };
                                options.Optional = true;
                                options.ReloadOnChange = true;
                            });
            var newConfiguration = configurationBuilder.Build();
            foreach (var kvp in newConfiguration.AsEnumerable())
            {
                configuration[kvp.Key] = kvp.Value;
            }

            
        }

        public async Task InitializeVault(IConfiguration configuration)
        {
            try
            {
                var authMethod = new TokenAuthMethodInfo("root");
                var vaultClientSettings = new VaultClientSettings(configuration["VaultClientUri"], authMethod);
                var vaultClient = new VaultClient(vaultClientSettings);

                var secret = await vaultClient.V1.Secrets.KeyValue.V2.ReadSecretAsync("secret/myapp/dbpassword");
                var dbPassword = secret.Data.Data["password"].ToString();

                var configurationBuilder = new ConfigurationBuilder()
                                           .AddConfiguration(configuration);
                configuration["myapp/dbpassword"] = dbPassword;
                var newConfiguration = configurationBuilder.Build();
                foreach (var kvp in newConfiguration.AsEnumerable())
                {
                    configuration[kvp.Key] = kvp.Value;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            
        }

    }
}
