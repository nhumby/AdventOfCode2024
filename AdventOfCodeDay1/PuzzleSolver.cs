namespace AdventOfCodeDay1
{
    internal class PuzzleSolver
    {
        int[]? locationListLeft;
        int[]? locationListRight;

        internal PuzzleSolver(string input)
        {
            var lines = input.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            locationListLeft = new int[lines.Length];
             locationListRight = new int[lines.Length];
            string[] components;
            
            for (int i = 0; i < lines.Length; i++)
            {
                components = lines[i].Split(" ", StringSplitOptions.RemoveEmptyEntries);
                locationListLeft[i] = int.Parse(components[0]);
                locationListRight[i] = int.Parse(components[1]);
            }            
        }

        internal string SolvePart1()
        {
            int totalApart = 0;
            var sortedLocationListLeft = locationListLeft.Order().ToArray();
            var sortedLocationListRight = locationListRight.Order().ToArray();

            for (int i = 0; i < sortedLocationListLeft.Length; i++)
            {
                totalApart += Math.Abs(sortedLocationListLeft[i] - sortedLocationListRight[i]);
            }

            return totalApart.ToString();
        }

        internal string SolvePart2()
        {
            var numberCounts = new Dictionary<int, int>(locationListLeft.Length);
            var similarityTotal = 0;
            int value;

            foreach (var valueLeft in locationListLeft)
            {
                foreach (var valueRight in locationListRight)
                {
                    if (valueLeft == valueRight)
                    {
                        if (numberCounts.ContainsKey(valueLeft))
                        {
                            numberCounts[valueLeft] += 1;
                        }
                        else
                        {
                            numberCounts.Add(valueLeft, 1);
                        }
                    }
                }
            }

            // // foreach (var key in numberCounts.Keys)
            // // {
            // //     value = numberCounts[key];
            // //     similarityTotal += key * value;
            // //     Console.WriteLine($"{key} * {value} = {key*value}, similarity total is {similarityTotal}");
            // // }

            return numberCounts.Select(x => x.Key * x.Value).Sum().ToString();
        }
    }
}