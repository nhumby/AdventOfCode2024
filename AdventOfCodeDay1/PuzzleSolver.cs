namespace AdventOfCodeDay1
{
    internal class PuzzleSolver
    {
        internal string Solve(string input)
        {
            var lines = input.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            var locationListLeft = new int[lines.Length];
            var locationListRight = new int[lines.Length];
            string[] components;
            int totalApart = 0;

            for (int i = 0; i < lines.Length; i++)
            {
                components = lines[i].Split(" ", StringSplitOptions.RemoveEmptyEntries);
                locationListLeft[i] = int.Parse(components[0]);
                locationListRight[i] = int.Parse(components[1]);
            }

            var sortedLocationListLeft = locationListLeft.Order().ToArray();
            var sortedLocationListRight = locationListRight.Order().ToArray();

            for (int i = 0; i < lines.Length; i++)
            {
                totalApart += Math.Abs(sortedLocationListLeft[i] - sortedLocationListRight[i]);
            }

            return totalApart.ToString();
        }
    }
}