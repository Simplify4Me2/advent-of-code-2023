using System.Text.RegularExpressions;

namespace advent_of_code.Day_3
{
    public partial class EngineSchematic(List<string> list)
    {
        private List<string> List { get; } = list;
        private Regex Regex = MyRegex();

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

                            numbers.Add(new(value, new(valueStartIndex, lineIndex)));
                    };

                lineIndex++;
            }

            return 0;
        }

        private class Number(int value, Coordinates position)
        {
            public int Value { get; set; } = value;

            public int Length = value.ToString().Length;

            public Coordinates Position { get; } = position;
        }

        private class Coordinates(int x, int y)
        {
            public int X { get; } = x;
            public int Y { get; } = y;
        }

        [GeneratedRegex(@"([0-9])\w+")]
        private static partial Regex MyRegex();
    }
}
