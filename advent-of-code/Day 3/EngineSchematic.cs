using System.Text.RegularExpressions;

namespace advent_of_code.Day_3
{
    public partial class EngineSchematic(List<string> list)
    {
        private List<string> List { get; } = list;
        private Regex NumbersRegex = MatchNumbersRegex();
        private Regex SymbolsRegex = MatchSymbolsRegex();

        public int Sum => GetSum();

        private int GetSum()
        {
            int sum = 0;
            int lineIndex = 0;

            foreach (string line in List)
            {
                if (NumbersRegex.IsMatch(line))
                    foreach (Match match in NumbersRegex.Matches(line).Cast<Match>())
                    {
                        if (int.TryParse(match.Value, out int value))
                        {
                            bool anyNumberAdjacentToSymbol = false;
                            for (int i = 0; i < match.Value.Length; i++)
                            {
                                if (anyNumberAdjacentToSymbol || IsAdjacentToSymbol(match.Index + i, lineIndex))
                                    anyNumberAdjacentToSymbol = true;
                            }

                            if (anyNumberAdjacentToSymbol)
                                sum += value;

                        }
                    };

                lineIndex++;
            }

            // 282674 is wrong!!!
            // 532047 is wrong!!!
            // 532420 is wrong!!!
            // 532445 is correct!!!
            return sum;
        }

        private bool IsAdjacentToSymbol(int x, int y)
        {
            if (y > 0)
            {
                string previousLine = List[y - 1];

                char charAbove = previousLine[x];
                if (SymbolsRegex.IsMatch(charAbove.ToString()))
                    return true;

                if (x > 0)
                {
                    char charDiagonalLeftAbove = previousLine[x - 1];
                    if (SymbolsRegex.IsMatch(charDiagonalLeftAbove.ToString()))
                        return true;
                }
                if (x < previousLine.Length - 1) 
                {
                    char charDiagonalRightAbove = previousLine[x + 1];
                    if (SymbolsRegex.IsMatch(charDiagonalRightAbove.ToString()))
                        return true;
                }
            }

            if (y < List.Count - 1) 
            { 
                string nextLine = List[y + 1];
                char charBelow = nextLine[x];
                if (SymbolsRegex.IsMatch(charBelow.ToString()))
                    return true;

                if (x > 0)
                {
                    char charDiagonalLeftBelow = nextLine[x - 1];
                    if (SymbolsRegex.IsMatch(charDiagonalLeftBelow.ToString()))
                        return true;
                }
                if (x < nextLine.Length - 1)
                {
                    char charDiagonalRightBelow = nextLine[x + 1];
                    if (SymbolsRegex.IsMatch(charDiagonalRightBelow.ToString()))
                        return true;
                }
            }

            string currentLine = List[y];

            if (x > 0)
            {
                char charLeft = currentLine[x - 1];
                if (SymbolsRegex.IsMatch(charLeft.ToString()))
                    return true;
            }
            if (x < currentLine.Length - 1)
            {
                char charRight = currentLine[x + 1];
                if (SymbolsRegex.IsMatch(charRight.ToString()))
                    return true;
            }

            return false;
        }

        [GeneratedRegex(@"([0-9])\w*")]
        private static partial Regex MatchNumbersRegex();

        [GeneratedRegex(@"([^0-9\.])+")]
        private static partial Regex MatchSymbolsRegex();
    }
}
