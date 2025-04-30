using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace CryptoMarketFetcher.Configuration
{
    public class EnvironmentConfig
    {
        private readonly IConfiguration _configuration;
        private readonly string _environment;

        public EnvironmentConfig(IConfiguration configuration)
        {
            _configuration = configuration;
            _environment = _configuration.GetValue<string>("Environment") ?? "Development";
        }

        private string GetEnvironmentValue(string section, string key)
        {
            var value = _configuration.GetValue<string>($"Environments:{_environment}:{section}:{key}");
            if (string.IsNullOrWhiteSpace(value))
                throw new InvalidOperationException($"Missing config for {section}:{key}");
            return value;
        }

        public string GetTokenMetricsApiKey() => GetEnvironmentValue("ApiKeys", "TokenMetrics");
        public string GetTokenMetricsApiUrl() => GetEnvironmentValue("ApiUrls", "TokenMetrics");
    }
}
