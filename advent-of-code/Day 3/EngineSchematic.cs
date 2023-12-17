using System.Text.RegularExpressions;

namespace advent_of_code.Day_3
{
    public partial class EngineSchematic(List<string> list)
    {
        private List<string> List { get; } = list;
        private Regex Regex = MatchNumbersRegex();

        public int Sum => GetSum();

        private int GetSum()
        {
            var numbers = new List<Number>();
            int lineIndex = 0;

            foreach (string line in List)
            {
                if (Regex.IsMatch(line))
                    foreach (Match match in Regex.Matches(line).Cast<Match>())
                    {
                        Console.WriteLine(match.Value);
                        var valueStartIndex = line.IndexOf(match.Value);

                        if (int.TryParse(match.Value, out int value))
                        {
                            Number number = new(value, new(valueStartIndex, lineIndex));

                            string previousLine = lineIndex == 0 ? string.Empty : List[lineIndex - 1];
                            string nextLine = lineIndex == List.Count - 1 ? string.Empty : List[lineIndex + 1];

                            if (number.IsAdjacentToASymbol(previousLine, line, nextLine))
                                numbers.Add(number);
                        }
                    };

                lineIndex++;
            }

            return numbers.Sum(number => number.Value);
        }

        public class Number(int value, Coordinates position)
        {
            private Regex Regex = MatchSymbolsRegex();
            public int Value { get; set; } = value;

            public int Length = value.ToString().Length;

            public Coordinates Position { get; } = position;

            public bool IsAdjacentToASymbol(string previousLine, string currentLine, string nextLine)
            {
                if (Regex.IsMatch(previousLine))
                {
                    foreach (Match match in Regex.Matches(previousLine))
                    {
                        int symbolIndex = previousLine.IndexOf(match.Value);
                        if (symbolIndex > Position.X - 2 && symbolIndex < Position.X + Length + 2)
                            return true;
                    }
                }

                if (Regex.IsMatch(currentLine))
                {
                    foreach (Match match in Regex.Matches(currentLine))
                    {
                        int symbolIndex = currentLine.IndexOf(match.Value);
                        if (symbolIndex > Position.X - 1 && symbolIndex < Position.X + Length + 1)
                            return true;
                    }
                }

                    if (Regex.IsMatch(nextLine))
                {
                    foreach (Match match in Regex.Matches(nextLine))
                    {
                        int symbolIndex = nextLine.IndexOf(match.Value);
                        if (symbolIndex > Position.X - 2 && symbolIndex < Position.X + Length + 2)
                            return true;
                    }
                }

                return false;
            }
        }

        public class Coordinates(int x, int y)
        {
            public int X { get; } = x;
            public int Y { get; } = y;
        }

        [GeneratedRegex(@"([0-9])\w+")]
        private static partial Regex MatchNumbersRegex();


        [GeneratedRegex(@"([\#\*\+\$])")]
        private static partial Regex MatchSymbolsRegex();
    }
}
