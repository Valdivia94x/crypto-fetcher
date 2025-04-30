using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CryptoMarketFetcher.Models
{
    public class TokenApiResponse
    {
        [JsonPropertyName("success")]
        public bool Success { get; set; }

        [JsonPropertyName("message")]
        public string Message { get; set; }

        [JsonPropertyName("length")]
        public int Length { get; set; }

        [JsonPropertyName("data")]
        public List<Token> Data { get; set; }
    }
}
