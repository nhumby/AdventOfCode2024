using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCodeDay3
{
    internal class PuzzleSolver
    {
        private readonly string input;

        internal PuzzleSolver(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                throw new ArgumentException($"'{nameof(input)}' cannot be null or whitespace.", nameof(input));
            }

            this.input = input;
        }

        internal string Solve()
        {
            var result = 0;
            var nextMul = input.IndexOf("mul");

            while (nextMul >= 0)
            {
                if (input[nextMul + 3] == '(')
                {
                    var closingBrace = input.IndexOf(')', nextMul + 5);
                    var difference = closingBrace - (nextMul + 4);
                    var subString = input.Substring(nextMul + 4, difference);


                    if (closingBrace > nextMul && (difference >= 3 & difference <= 7) && CheckRegex(subString))
                    {
                        var add = GetMultiple(subString);
                        Console.WriteLine($"Adding {add} to {result} to get {add + result}");
                        result += add;
                    }
                }

                nextMul = input.IndexOf("mul", nextMul + 1);
            }

            return result.ToString();
        }

        private int GetMultiple(string subString)
        {
            var elements = subString.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

            if (elements.Length == 2)
            {
                var intParse1 = int.TryParse(elements[0], out var int1);
                var intParse2 = int.TryParse(elements[1], out var int2);

                if (intParse1 && intParse2)
                {
                    return int1 * int2;
                }
            }

            return 0;
        }

        private bool CheckRegex(string input)
        {
            // \([^)]*\)
            // [0-9]+(,[0-9]+)+
            var regex = new Regex("[0-9]+(,[0-9]+)+", RegexOptions.IgnoreCase);
            return regex.IsMatch(input);
        }
    }
}
