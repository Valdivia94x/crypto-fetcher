using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using CryptoMarketFetcher.Services;
using Microsoft.Extensions.Configuration;
using CryptoMarketFetcher.Configuration;
using CryptoMarketFetcher.Models;
using CryptoMarketFetcher.Menu;

var host = Host.CreateDefaultBuilder(args)
    .ConfigureAppConfiguration((context, config) =>
    {
        config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
    })
    .ConfigureServices((context, services) =>
    {
        services.AddSingleton<EnvironmentConfig>();
        services.AddHttpClient<ICryptoService, CryptoService>();
    })
    .Build();

var cryptoService = host.Services.GetRequiredService<ICryptoService>();
var tokens = await cryptoService.GetTokens() ?? new List<Token>();

var menu = new MenuManager(tokens);
menu.DisplayTitle();