namespace advent_of_code.Day_4
{
    public class Scratchcard(int[] winningNumbers, int[] yourNumbers)
    {
        private int[] WinningNumbers { get; } = winningNumbers;
        private int[] YourNumbers { get; } = yourNumbers;

        public int Points => GetPoints();

        public int MatchingNumbers => GetMatchingNumbers();

        private int GetPoints()
        {
            int points = 0;

            foreach (int winningNumber in WinningNumbers)
            {
                if (YourNumbers.Contains(winningNumber))
                {
                    if (points == 0) points = 1;
                    else points *= 2;
                }
            }

            return points;
        }

        private int GetMatchingNumbers()
        {
            int matchingNumbers = 0;

            foreach (int winningNumber in WinningNumbers)
                if (YourNumbers.Contains(winningNumber))
                    matchingNumbers++;

            return matchingNumbers;
        }
    }
}
