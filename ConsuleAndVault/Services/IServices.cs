namespace ConsuleAndVault.Services
{
    public interface IServices
    {
        Task InitializeVault(IConfiguration configuration);
        Task InitializeConsul(IConfiguration configuration);
    }
}
