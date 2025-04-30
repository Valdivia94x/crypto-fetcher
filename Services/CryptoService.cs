using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using CryptoMarketFetcher.Configuration;
using CryptoMarketFetcher.Models;

namespace CryptoMarketFetcher.Services
{
    public class CryptoService : ICryptoService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;
        private readonly string _apiUrl;

        public CryptoService(HttpClient httpClient, EnvironmentConfig config)
        {
            _httpClient = httpClient;
            _apiKey = config.GetTokenMetricsApiKey();
            _apiUrl = config.GetTokenMetricsApiUrl();
            _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {_apiKey}");
        }
        public async Task<List<Token>> GetTokens()
        {
            try
            {
                var response = await _httpClient.GetAsync(_apiUrl);

                if (!response.IsSuccessStatusCode)
                {
                    Console.WriteLine($"API error: {response.StatusCode}");
                    return new List<Token>();
                }

                var content = await response.Content.ReadAsStringAsync();
                var apiResponse = JsonSerializer.Deserialize<TokenApiResponse>(content);
                return apiResponse?.Data ?? new List<Token>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching tokens: {ex.Message}");
                return new List<Token>();
            }
        }
    }
}
