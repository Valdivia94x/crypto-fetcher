using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CryptoMarketFetcher.Models;

namespace CryptoMarketFetcher.Menu
{
    public class MenuManager
    {
        private readonly List<Token> _tokens;
        public MenuManager(List<Token> tokens)
        {
            _tokens = tokens;
        }

        public void DisplayTitle()
        {
            Console.Clear();
            Console.WriteLine("                                                     \r\n," +
                "---.               |             ,-.-.          |         |        \r\n" +
                "|    ,---.,   .,---.|--- ,---.    | | |,---.,---.|__/ ,---.|---     \r\n" +
                "|    |    |   ||   ||    |   |    | | |,---||    |  \\ |---'|        \r\n" +
                "`---'`    `---||---'`---'`---'    ` ' '`---^`    `   ``---'`---'    \r\n" +
                "          `---'|                                                    \r\n" +
                "                                                                    \r\n" +
                "                ,---.     |         |                               \r\n" +
                "                |__. ,---.|--- ,---.|---.,---.,---.                 \r\n" +
                "                |    |---'|    |    |   ||---'|                     \r\n" +
                "                `    `---'`---'`---'`   '`---'`                     \r\n" +
                "                                                                    \r\n");
            Console.WriteLine("Press any key to continue");
            Console.ReadKey(true);
            DisplayMenu();
        }

        public void DisplayMenu()
        {
            bool keepGoing = true;

            while (keepGoing)
            {
                Console.Clear();
                Console.WriteLine("MAIN MENU");
                Console.WriteLine("1. Show tokens (paginated)");
                Console.WriteLine("2. Search token by name");
                Console.WriteLine("3. Filter by symbol");
                Console.WriteLine("4. Exit");

                Console.WriteLine("\nSelect one option...");
                var key = Console.ReadKey(true).Key;

                    switch (key)
                    {
                        case ConsoleKey.D1:
                            ShowTokensPaginated();
                            break;

                        case ConsoleKey.D2:
                            SearchTokenByName();
                            break;

                        case ConsoleKey.D3:
                            SearchTokenBySymbol(); 
                            break;

                        case ConsoleKey.D4:
                            keepGoing = false;
                            break;

                        default:
                            Console.WriteLine("Invalid option. Press key to continue...");
                            Console.ReadKey();
                            break;
                    }
            }
        }

        private void DisplayTokenTable(IEnumerable<Token> tokens)
        {
            Console.WriteLine($"{"TOKEN ID",-10} {"TOKEN NAME",-35} {"TOKEN SYMBOL"}");
            foreach (var token in tokens)
                Console.WriteLine($"{token.TokenId,-10} {token.TokenName,-35} {token.TokenSymbol}");
        }

        public void ShowTokensPaginated()
        {
            int currentPage = 0;
            int pageSize = 20;
            bool keepGoing = true;
            int totalPages = (int)Math.Ceiling((double)_tokens.Count / pageSize);

            while (keepGoing)
            {
                Console.Clear();
                Console.WriteLine($"--- Page {currentPage + 1} ---\n");

                var pageItems = _tokens
                .Skip(currentPage * pageSize)
                .Take(pageSize);

                if (_tokens.Count != 0)
                {
                    DisplayTokenTable(pageItems);
                }
                else
                    Console.WriteLine("No tokens were found");

                Console.WriteLine("\nOptions: [N]ext page | [P]revious page | [Q]uit");
                var key = Console.ReadKey(true).Key;

                switch (key)
                {
                    case ConsoleKey.N:
                        if (currentPage < totalPages - 1)
                            currentPage++;
                        break;
                    case ConsoleKey.P:
                        if (currentPage > 0)
                            currentPage--;
                        break;
                    case ConsoleKey.Q:
                        keepGoing = false;
                        break;
                    default:
                        keepGoing = false;
                        break;
                }
            }
        }

        public void SearchTokens(Func<Token, string, bool> filterFunc, string prompt)
        {
            Console.Clear();
            bool keepGoing = true;

            while (keepGoing)
            {
                Console.Write($"Enter {prompt} (or Q to quit): ");
                var input = Console.ReadLine();

                if (string.Equals(input, "Q", StringComparison.OrdinalIgnoreCase))
                {
                    keepGoing = false;
                    break;
                }

                var filteredValues = _tokens.Where(t => filterFunc(t, input));

                if (filteredValues.Any())
                {
                    DisplayTokenTable(filteredValues);
                }
                else
                    Console.WriteLine("No tokens were found");

                Console.WriteLine("\nPress any key to search again, or Q to quit.");
                var key = Console.ReadKey(true).Key;

                if (key == ConsoleKey.Q)
                {
                    keepGoing = false;
                }
                Console.Clear();
            }
        }

        public void SearchTokenByName()
        {
            SearchTokens(
                (t, input) => t.TokenName.Contains(input, StringComparison.OrdinalIgnoreCase),
                "token name"
            );
        }

        public void SearchTokenBySymbol()
        {
            SearchTokens(
                (t, input) => t.TokenSymbol.Contains(input, StringComparison.OrdinalIgnoreCase),
                "token symbol"
            );
        }
    }
}
