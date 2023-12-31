namespace advent_of_code.Day_7
{
    public class Game(Hand[] hands)
    {
        public int TotalWinnings => DetermineTotalWinnings();

        private int DetermineTotalWinnings()
        {
            int totalWinnings = 0;

            for (int i = 0; i < hands.Length; i++)
            {
                totalWinnings += hands[i].Bid * (i + 1);
            }

            return totalWinnings;
        }
    }

    public class Hand(char[] cards, int bid)
    {
        public char[] Cards { get; } = cards;
        public int Bid { get; } = bid;
    }
}
