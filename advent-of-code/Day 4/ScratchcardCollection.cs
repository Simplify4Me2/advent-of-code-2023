namespace advent_of_code.Day_4
{
    public class ScratchcardCollection(Scratchcard[] scratchcards)
    {
        private readonly List<Scratchcard> Scratchcards = new(scratchcards);
        private readonly Dictionary<int, ScratchcardCounter> Counters = [];

        public int Total => GetTotal();

        private int GetTotal()
        {
            for (int i = 0; i < Scratchcards.Count; i++)
            {
                Counters.Add(i, new(Scratchcards[i]));
            }


            for (int i = 0; i < Counters.Count; i++)
            {
                var counter = Counters[i];

                while (counter.Balance > 0)
                {
                    int matchingNumbers = counter.MatchingNumbers;
                    for (int j = 1; j <= matchingNumbers; j++)
                    {
                        if(i + j < Counters.Count)
                        {
                            Counters[i + j].AddCard();
                        }
                    }
                    counter.RemoveCard();
                }
            }

            return Counters.Sum(counter => counter.Value.Total);
        }

        private class ScratchcardCounter(Scratchcard scratchcard)
        {
            public int Balance = 1;
            public int Total = 1;

            public int MatchingNumbers { get; } = scratchcard.MatchingNumbers;

            public void AddCard()
            {
                Total++;
                Balance++;
            }

            public void RemoveCard()
            {
                Balance--;
            }
        }
    }
}
