using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CryptoMarketFetcher.Models
{
    public class Token
    {
        [JsonPropertyName("TOKEN_ID")]
        public int TokenId { get; set; }

        [JsonPropertyName("TOKEN_NAME")]
        public string TokenName { get; set; }

        [JsonPropertyName("TOKEN_SYMBOL")]
        public string TokenSymbol { get; set; }
    }
}
