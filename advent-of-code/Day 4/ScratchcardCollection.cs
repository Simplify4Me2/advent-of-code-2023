namespace advent_of_code.Day_4
{
    public class ScratchcardCollection(Scratchcard[] scratchcards)
    {
        private ScratchcardCounter[] Scratchcards { get; } = scratchcards.Select(card => new ScratchcardCounter(card)).ToArray();

        public int Total => GetTotal();

        private int GetTotal()
        {
            int total = 0;

            for (int i = 0; i < Scratchcards.Length; i++)
            {
                for (int j = 0; j < Scratchcards[i].Amount; j++)
                {
                    total++;
                    int matchingNumbers = Scratchcards[i].MatchingNumbers;

                    for (int h = 1; h < matchingNumbers; h++)
                    {
                        if ((i + h) < Scratchcards.Length)
                            Scratchcards[i + h].AddCard();
                    }
                }
            }

            return total;
        }

        private class ScratchcardCounter(Scratchcard scratchcard)
        {
            public int Amount = 1;
            //private Scratchcard Scratchcard { get; } = scratchcard;

            public int MatchingNumbers { get; } = scratchcard.MatchingNumbers;

            public void AddCard()
            {
                Amount++;
                //return this;
            }
        }
    }
}
