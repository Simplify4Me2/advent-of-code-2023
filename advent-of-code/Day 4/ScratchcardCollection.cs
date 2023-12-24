namespace advent_of_code.Day_4
{
    public class ScratchcardCollection(Scratchcard[] scratchcards)
    {
        //private ScratchcardCounter[] Scratchcards { get; } = scratchcards.Select(card => new ScratchcardCounter(card)).ToArray();

        //private Dictionary<int, Scratchcard[]> Scratchcards { get; } = scratchcards.Select((card, index) => new { ScratchCard = card, Index = index }).ToDictionary(x => x.Index, x => new Scratchcard[] { x.ScratchCard });

        private List<Scratchcard> Scratchcards = new List<Scratchcard>(scratchcards);

        public int Total => GetTotal();

        private int GetTotal()
        {
            int total = 0;

            //while(Scratchcards.Count > 0)
            //{
            //    total++;
            //    Scratchcard scratchcard = Scratchcards.First();
            //    int matchingNumbers = scratchcard.MatchingNumbers;
            //    for (int i = 1; i < matchingNumbers; i++)
            //    {
            //        Scratchcards.Add(Scratchcards[i]);
            //    }
            //    Scratchcards.Remove(scratchcard);
            //}

            //for (int i = 0; i < Scratchcards.Length; i++)
            //{
            //    for (int j = 0; j < Scratchcards[i].Amount; j++)
            //    {
            //        total++;
            //        int matchingNumbers = Scratchcards[i].MatchingNumbers;

            //        for (int h = 1; h < matchingNumbers; h++)
            //        {
            //            if ((i + h) < Scratchcards.Length)
            //                Scratchcards[i + h].AddCard();
            //        }
            //    }
            //}

            //for (int i = 0; i < Scratchcards.Count; i++)
            //{
            //    foreach (Scratchcard scratchcard in Scratchcards[i])
            //    {
            //        total++;
            //        int matchingNumbers = scratchcard.MatchingNumbers;
            //        for (int j = 1; j < matchingNumbers; j++)
            //        {
            //            Scratchcards[j] = [.. Scratchcards[j], Scratchcards[j].First()];
            //        }
            //    }
            //}

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
