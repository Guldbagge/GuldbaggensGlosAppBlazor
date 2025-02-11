using Microsoft.Extensions.Configuration;

namespace GlosApp.Services
{
    public class ConfigurationService
    {
        private readonly IConfiguration _configuration;

        public ConfigurationService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GetApiKey(string serviceName)
        {
            return _configuration[$"ApiKeys:{serviceName}"] ?? "API-nyckel saknas";
        }
    }
}
