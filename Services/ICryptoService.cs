using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CryptoMarketFetcher.Models;

namespace CryptoMarketFetcher.Services
{
    public interface ICryptoService
    {
        Task<List<Token>> GetTokens();
    }
}
