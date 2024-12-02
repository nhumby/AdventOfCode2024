using AdventOfCodeDay1;

var puzzleSolver = new PuzzleSolver(await new PuzzleInputFetcher().FetchInput());
Console.WriteLine(puzzleSolver.SolvePart1());
Console.WriteLine(puzzleSolver.SolvePart2());