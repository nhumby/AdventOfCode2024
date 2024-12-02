using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCodeDay2
{
    internal class PuzzleInputFetcher
    {
        private const string puzzleInputUri = "https://adventofcode.com";

        // HttpClient lifecycle management best practices:
        // https://learn.microsoft.com/dotnet/fundamentals/networking/http/httpclient-guidelines#recommended-use
        private static HttpClient? sharedClient;

        internal async Task<string> FetchInput()
        {
            sharedClient = new()
            {
                BaseAddress = new Uri(puzzleInputUri),
            };

            try
            {
                var result = await sharedClient.GetAsync("/2024/day/2/input");
                result.EnsureSuccessStatusCode();
                return await result.Content.ReadAsStringAsync();
            }
            catch
            {
                Console.WriteLine($"Couldn't read input from {puzzleInputUri}, returning local cache instead.");
                return File.ReadAllText("PuzzleInput.txt");
            }
        }
    }
}