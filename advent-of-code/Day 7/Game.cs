
namespace advent_of_code.Day_7;

public class Game(IHand[] hands, bool jokerIsWild)
{
    public int TotalWinnings => DetermineTotalWinnings();

    private int DetermineTotalWinnings()
    {
        int totalWinnings = 0;

        IComparer<IHand> comparer;

        if (jokerIsWild) comparer = new HandComparerJokerIsWild();
        else comparer = new HandComparer();

        Array.Sort(hands, comparer);

        for (int i = 0; i < hands.Length; i++)
        {
            totalWinnings += hands[i].Bid * (i + 1);
        }

        return totalWinnings;
    }
}

public interface IHand
{
    char[] Cards { get; }
    int Bid { get; }
    Rank Rank { get; }
}

public class Hand(char[] cards, int bid) : IHand
{
    public char[] Cards { get; } = cards;
    public int Bid { get; } = bid;

    public Rank Rank => DetermineType();

    private Rank DetermineType()
    {
        int distinctCards = Cards.Distinct().Count();

        if (distinctCards == 1)
            return Rank.FiveOfAKind;
        if (distinctCards == 2)
        {
            int occurences = Cards.Where(card => card == Cards[0]).Count();

            if (occurences == 4 || occurences == 1)
                return Rank.FourOfAKind;
            else
                return Rank.FullHouse;
        }
        if (distinctCards == 3)
        {
            int occurences = Cards.Where(card => card == Cards[0]).Count();

            if (occurences == 3)
                return Rank.ThreeOfAKind;
            else if (occurences == 2)
                return Rank.TwoPair;

            occurences = Cards.Where(card => card == Cards[1]).Count();

            if (occurences == 3 || occurences == 1)
                return Rank.ThreeOfAKind;
            else if (occurences == 2)
                return Rank.TwoPair;
        }
        if (distinctCards == 4)
            return Rank.OnePair;
        if (distinctCards == 5)
            return Rank.HighCard;

        return Rank.HighCard;
    }
}

public enum CardDeck
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

public class HandComparer : IComparer<IHand>
{
    public int Compare(IHand x, IHand y)
    {
        if (x.Rank > y.Rank) return 1;
        if (x.Rank < y.Rank) return -1;
        if (x.Rank == y.Rank)
        {
            if (Map(x.Cards[0]) > Map(y.Cards[0])) return 1;
            else if (Map(x.Cards[0]) < Map(y.Cards[0])) return -1;
            else
            {
                if (Map(x.Cards[1]) > Map(y.Cards[1])) return 1;
                else if (Map(x.Cards[1]) < Map(y.Cards[1])) return -1;
                else
                {
                    if (Map(x.Cards[2]) > Map(y.Cards[2])) return 1;
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

    private static CardDeck Map(char character)
    {
        return character switch
        {
            'A' => CardDeck.Ace,
            'K' => CardDeck.King,
            'Q' => CardDeck.Queen,
            'J' => CardDeck.Jack,
            'T' => CardDeck.Ten,
            '9' => CardDeck.Nine,
            '8' => CardDeck.Eight,
            '7' => CardDeck.Seven,
            '6' => CardDeck.Six,
            '5' => CardDeck.Five,
            '4' => CardDeck.Four,
            '3' => CardDeck.Three,
            _ => CardDeck.Two,
        };
    }
}

public class HandComparerJokerIsWild : IComparer<IHand>
{
    public int Compare(IHand x, IHand y)
    {
        if (x.Rank > y.Rank) return 1;
        if (x.Rank < y.Rank) return -1;
        if (x.Rank == y.Rank)
        {
            if (Map(x.Cards[0]) > Map(y.Cards[0])) return 1;
            else if (Map(x.Cards[0]) < Map(y.Cards[0])) return -1;
            else
            {
                if (Map(x.Cards[1]) > Map(y.Cards[1])) return 1;
                else if (Map(x.Cards[1]) < Map(y.Cards[1])) return -1;
                else
                {
                    if (Map(x.Cards[2]) > Map(y.Cards[2])) return 1;
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

    private static Rank Map(char character)
    {
        return character switch
        {
            'A' => Rank.Ace,
            'K' => Rank.King,
            'Q' => Rank.Queen,
            'J' => Rank.Jack,
            'T' => Rank.Ten,
            '9' => Rank.Nine,
            '8' => Rank.Eight,
            '7' => Rank.Seven,
            '6' => Rank.Six,
            '5' => Rank.Five,
            '4' => Rank.Four,
            '3' => Rank.Three,
            _ => Rank.Two,
        };
    }

    private enum Rank
    {
        Ace = 12,
        King = 11,
        Queen = 10,
        Ten = 9,
        Nine = 8,
        Eight = 7,
        Seven = 6,
        Six = 5,
        Five = 4,
        Four = 3,
        Three = 2,
        Two = 1,
        Jack = 0,
    }
}
