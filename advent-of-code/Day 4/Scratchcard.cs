namespace advent_of_code.Day_4
{
    public class Scratchcard(int[] winningNumbers, int[] yourNumbers)
    {
        private int[] WinningNumbers { get; } = winningNumbers;
        private int[] YourNumbers { get; } = yourNumbers;

        public int Points => GetPoints();

        private int GetPoints() 
        {
            return 0;
        }
    }
}
