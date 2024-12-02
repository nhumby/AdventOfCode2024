using AdventOfCodeDay2;

var puzzleSolver = new PuzzleSolver(await new PuzzleInputFetcher().FetchInput());
Console.WriteLine($"Part 1: {puzzleSolver.Solve(false)}");
Console.WriteLine($"Part 2: {puzzleSolver.Solve(true)}");