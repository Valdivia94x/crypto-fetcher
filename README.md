# 💰 CryptoMarketFetcher

A C# application that allows you to fetch cryptocurrency tokens' information using the TokenMetrics API. You can search tokens by their name or symbol, displaying detailed information such as token ID, name, and symbol.

## 📌 Features

- Fetches cryptocurrency tokens data from TokenMetrics API.
- Provides a command-line interface (CLI) for searching tokens by name or symbol.
- Configurable API keys and URLs for different environments (Development, Production).
- Exception handling for API requests.

## 🚀 Technologies

- .NET Core
- HttpClient for making HTTP requests.
- JSON handling via System.Text.Json.
- Configuration using appsettings.json and IConfiguration.
- Dependency Injection for the HttpClient and EnvironmentConfig.
- LINQ

## 🛠️ How to Run

### Requirements

- [.NET SDK](https://dotnet.microsoft.com/download) installed

### Steps

1. Clone the repo:
					
	git clone https://github.com/Valdivia94x/crypto-fetcher.git
    cd CryptoMarketFetcher

2. Install dependencies: The project uses .NET Core, so you can restore dependencies with:

	dotnet restore

3. Configure environment: The appsettings.json file contains configuration for API keys and URLs. Ensure that the TokenMetrics API key is correctly set in the ApiKeys section, and the URL is configured under ApiUrls in the Development environment.

{
  "Environment": "Development",
  "Environments": {
    "Development": {
      "ApiKeys": {
        "TokenMetrics": "your-api-key-here"
      },
      "ApiUrls": {
        "TokenMetrics": "https://api.tokenmetrics.com/v2/tokens"
      }
    }
  }
}

4. Run the application: Once everything is set up, you can build and run the project:

    dotnet run

## 📝 Usage

When you run the application, a menu will prompt you to search for tokens by name or symbol. Here’s what you can expect:

1. Get all tokens: Fetches all available tokens from the API in a paginated manner.
1. Search by Token Name: You’ll be asked to enter a token name to search. If any tokens match, the details (ID, name, symbol) will be displayed.
2. Search by Token Symbol: Similarly, you can search by the token symbol.

## ⚙️ Configuration

The app uses the EnvironmentConfig class to load environment-specific settings from appsettings.json. The GetTokenMetricsApiKey and GetTokenMetricsApiUrl methods are used to retrieve the API key and URL for the TokenMetrics API.

- API Key: The key is fetched from the ApiKeys section.

- API URL: The URL is retrieved from the ApiUrls section.

## 🤝 Contributing

If you'd like to contribute to this project, feel free to fork the repository, make changes, and create a pull request.

## 🔒 License

This project is licensed under the MIT License.