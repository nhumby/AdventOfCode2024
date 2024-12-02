internal class PuzzleSolver
{
    string[]? reports;
    bool[]? safety;

    internal PuzzleSolver(string input)
    {
        var lines = input.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
        reports = new string[lines.Length];
        safety = new bool[lines.Length];

        for (int i = 0; i < lines.Length; i++)
        {
            reports[i] = lines[i];
            safety[i] = false;
        }
    }

    internal string Solve(bool isPartTwo)
    {
        var total = 0;

        for (int i = 0; i < reports.Length; i++)
        {
            var values = reports[i].Split(' ').Select(x => int.Parse(x.Trim())).ToArray();
            safety[i] = CheckSafety(values, reports[i], isPartTwo);
        }

        foreach (var result in safety)
        {
            if (result)
            {
                ++total;
            }
        }

        return total.ToString();
    }

    private bool CheckSafety(int[] values, string value, bool isPartTwo)
    {
        string direction = "";
        Console.WriteLine($"{string.Join(" ", values)} {isPartTwo}");

        for (var i = 1; i < values.Length; i++)
        {
            var difference = Math.Abs(values[i] - values[i - 1]);
            var inRange = (difference >= 1) && (difference <= 3);

            if (isPartTwo && !inRange)
            {
                Console.WriteLine("yo");
                var newValues = new int[values.Length - 1];
                var newValues2 = new int[values.Length - 1];
                
                for (var j = 0; j < i; j++)
                {
                    newValues[j] = values[j];
                }

                for (var j = i + 1; j < values.Length; j++)
                {
                    newValues[j - 1] = values[j];
                }

                if (!CheckSafety(newValues, string.Join(" ", newValues), false))
                {
                    Console.WriteLine("STILL FALSE");
                    return false;
                }
                else
                {
                    Console.WriteLine("NOW TRUE");
                }
            }
            else if (values[i] < values[i - 1] && inRange)
            {
                if (direction == "")
                {
                    direction = "down";
                }
                else if (direction != "down")
                {
                    return false;
                }
            }
            else if (values[i] > values[i - 1] && inRange)
            {
                if (direction == "")
                {
                    direction = "up";
                }
                else if (direction != "up")
                {
                    return false;
                }
            }
            else
            {
                // // Console.WriteLine($"{value} is false");
                return false;
            }
        }

        // // Console.WriteLine($"{value} is true");

        return true;
    }
}