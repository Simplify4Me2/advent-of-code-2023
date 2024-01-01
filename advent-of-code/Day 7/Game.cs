
namespace advent_of_code.Day_7
{
    public class Game(Hand[] hands)
    {
        public int TotalWinnings => DetermineTotalWinnings();

        private int DetermineTotalWinnings()
        {
            int totalWinnings = 0;

            Array.Sort(hands, new HandComparer());

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

        public Type Type => DetermineType();

        private Type DetermineType()
        {
            int distinctCards = Cards.Distinct().Count();

            if (distinctCards == 1)
                return Type.FiveOfAKind;
            if (distinctCards == 2)
            {
                int occurences = Cards.Where(card => card == Cards[0]).Count();

                if (occurences == 4 || occurences == 1)
                    return Type.FourOfAKind;
                else
                    return Type.FullHouse;
            }
            if (distinctCards == 3)
            {
                int occurences = Cards.Where(card => card == Cards[0]).Count();

                if (occurences == 3)
                    return Type.ThreeOfAKind;
                else if (occurences == 2)
                    return Type.TwoPair;

                occurences = Cards.Where(card => card == Cards[1]).Count();

                if (occurences == 3 || occurences == 1)
                    return Type.ThreeOfAKind;
                else if (occurences == 2)
                    return Type.TwoPair;
            }
            if (distinctCards == 4)
                return Type.OnePair;
            if (distinctCards == 5)
                return Type.HighCard;

            return Type.HighCard;
        }
    }

    public enum Type
    {
        FiveOfAKind = 6,
        FourOfAKind = 5,
        FullHouse = 4,
        ThreeOfAKind = 3,
        TwoPair = 2,
        OnePair = 1,
        HighCard = 0
    }

    public enum Card
    {
        Ace = 12,
        King = 11,
        Queen = 10, 
        Jack = 9,
        Ten = 8,
        Nine = 7,
        Eight = 6,
        Seven = 5,
        Six = 4,
        Five = 3,
        Four = 2,
        Three = 1,
        Two = 0
    }

    public class HandComparer : IComparer<Hand>
    {
        public int Compare(Hand x, Hand y)
        {
            if (x.Type > y.Type) return 1;
            if (x.Type < y.Type) return -1;
            if (x.Type == y.Type)
            {
                if (Map(x.Cards[0]) > Map(y.Cards[0])) return 1;
                else if (Map(x.Cards[0]) < Map(y.Cards[0])) return -1;
                else
                {
                    if (Map(x.Cards[1]) > Map(y.Cards[1])) return 1;
                    else if (Map(x.Cards[1]) < Map(y.Cards[1])) return -1;
                    else
                    {
                        if(Map(x.Cards[2]) > Map(y.Cards[2])) return 1;
                        else if (Map(x.Cards[2]) < Map(y.Cards[2])) return -1;
                        else
                        {
                            if (Map(x.Cards[3]) > Map(y.Cards[3])) return 1;
                            else if (Map(x.Cards[3]) < Map(y.Cards[3])) return -1;
                            else
                            {
                                if (Map(x.Cards[4]) > Map(y.Cards[4])) return 1;
                                else if (Map(x.Cards[4]) < Map(y.Cards[4])) return -1;
                                else return 0;
                            }
                        }
                    }
                }
            }

            return 0;
        }

        private static Card Map(char character)
        {
            return character switch
            {
                'A' => Card.Ace,
                'K' => Card.King,
                'Q' => Card.Queen,
                'J' => Card.Jack,
                'T' => Card.Ten,
                '9' => Card.Nine,
                '8' => Card.Eight,
                '7' => Card.Seven,
                '6' => Card.Six,
                '5' => Card.Five,
                '4' => Card.Four,
                '3' => Card.Three,
                _ => Card.Two,
            };
        }
    }
}
