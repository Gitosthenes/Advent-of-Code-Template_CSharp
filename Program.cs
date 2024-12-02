namespace AdventOfCode;

public static class Program
{
    public static void Main(string[] args)
    {
        var solutions = BuildSolutionMap();
        
        while (true)
        {
            Console.Write("Which day? (1-25, 'e': Exit): ");
            var input = Console.ReadLine();
            
            if (input is null)  continue;
            if (input.Equals("e", StringComparison.OrdinalIgnoreCase)) break;
            if (!int.TryParse(input, out var day) || day is < 1 or > 25) continue;
            
            Console.WriteLine("TEST(S):");
            (string p1, string p2) answer;
            foreach (var testInput in solutions[day].testInputs)
            {
                if (string.IsNullOrWhiteSpace(testInput)) continue;
                
                answer = solutions[day].Solve(testInput);
                
                Console.WriteLine($"""
                                   Part 1: {answer.p1}
                                   Part 2: {answer.p2}
                                   -----
                                   """);
            }
            
            Console.WriteLine("PUZZLE:");
            var projectDirectory = Directory.GetParent(Environment.CurrentDirectory)!.Parent!.Parent!.FullName;
            var filePath = Path.Join(projectDirectory, "inputs", $"d{day}.txt");

            if (!File.Exists(filePath))
            {
                Console.WriteLine($"{filePath} does not exist.");
                continue;
            }
            
            var puzzleInput = new StreamReader(filePath).ReadToEnd();
            if (string.IsNullOrWhiteSpace(puzzleInput)) continue;
            
            answer = solutions[day].Solve(puzzleInput);
            
            Console.WriteLine($"""
                               Part 1: {answer.p1}
                               Part 2: {answer.p2}
                               -----
                               """);
        }
        
        Console.WriteLine("Exiting...");
        Environment.Exit(0);
    }

    /// <summary>
    /// Maps the day number entered by the user to the test inputs and solution function for that day.
    /// </summary>
    /// <returns>The map.</returns>
    private static Dictionary<int, (string[] testInputs, Func<string, (string, string)> Solve)> BuildSolutionMap()
    {
        return new Dictionary<int, (string[], Func<string, (string, string)>)>
        {
            {1, (TestInputs.Day01, Solutions.Day01)},
            {2, (TestInputs.Day02, Solutions.Day02)},
            {3, (TestInputs.Day03, Solutions.Day03)},
            {4, (TestInputs.Day04, Solutions.Day04)},
            {5, (TestInputs.Day05, Solutions.Day05)},
            {6, (TestInputs.Day06, Solutions.Day06)},
            {7, (TestInputs.Day07, Solutions.Day07)},
            {8, (TestInputs.Day08, Solutions.Day08)},
            {9, (TestInputs.Day09, Solutions.Day09)},
            {10, (TestInputs.Day10, Solutions.Day10)},
            {11, (TestInputs.Day11, Solutions.Day11)},
            {12, (TestInputs.Day12, Solutions.Day12)},
            {13, (TestInputs.Day13, Solutions.Day13)},
            {14, (TestInputs.Day14, Solutions.Day14)},
            {15, (TestInputs.Day15, Solutions.Day15)},
            {16, (TestInputs.Day16, Solutions.Day16)},
            {17, (TestInputs.Day17, Solutions.Day17)},
            {18, (TestInputs.Day18, Solutions.Day18)},
            {19, (TestInputs.Day19, Solutions.Day19)},
            {20, (TestInputs.Day20, Solutions.Day20)},
            {21, (TestInputs.Day21, Solutions.Day21)},
            {22, (TestInputs.Day22, Solutions.Day22)},
            {23, (TestInputs.Day23, Solutions.Day23)},
            {24, (TestInputs.Day24, Solutions.Day24)},
            {25, (TestInputs.Day25, Solutions.Day25)}
        };
    }
}