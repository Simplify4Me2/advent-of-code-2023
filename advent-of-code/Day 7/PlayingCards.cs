
namespace advent_of_code.Day_7;

public class PlayingCards(char[] cards, int bid) : IHand
{
    public char[] Cards { get; } = cards;
    public int Bid { get; } = bid;
    public Rank Rank => DetermineRank(cards);

    private static Rank DetermineRank(char[] cards)
    {
        int distinctCards = cards.Distinct().Count();

        if (distinctCards == 1 || (distinctCards == 2 && cards.Contains('J')))
            return Rank.FiveOfAKind;

        if (distinctCards == 2 || (distinctCards == 3 && cards.Contains('J')))
        {
            int index = Array.IndexOf(cards, cards.FirstOrDefault(card => card != 'J'));

            int occurences = cards.Where(card => card == cards[index]).Count();

            if (occurences == 4)
                return Rank.FourOfAKind;

            occurences = cards.Where(card => card == cards[index] || card == 'J').Count();
            if (occurences == 4)
                return Rank.FourOfAKind;

            if (index + 1 < cards.Length)
            {
                occurences = cards.Where(card => card == cards[index + 1]).Count();
                if (occurences == 4)
                    return Rank.FourOfAKind;

                occurences = cards.Where(card => card == cards[index + 1] || card == 'J').Count();
                if (occurences == 4)
                    return Rank.FourOfAKind;
            }

            index = Array.IndexOf(cards, cards.LastOrDefault(card => card != 'J'));
            occurences = cards.Where(card => card == cards[index] || card == 'J').Count();
            if (occurences == 4)
                return Rank.FourOfAKind;

            return Rank.FullHouse;
        }

        if (distinctCards == 3 || (distinctCards == 4 && cards.Contains('J')))
        {
            int occurences = cards.Where(card => card == cards[0]).Count();

            if (occurences == 3)
                return Rank.ThreeOfAKind;

            occurences = cards.Where(card => card == cards[0] || card == 'J').Count();
            if (occurences == 3)
                return Rank.ThreeOfAKind;

            occurences = cards.Where(card => card == cards[1]).Count();
            if (occurences == 3)
                return Rank.ThreeOfAKind;

            occurences = cards.Where(card => card == cards[1] || card == 'J').Count();
            if (occurences == 3)
                return Rank.ThreeOfAKind;

            occurences = cards.Where(card => card == cards[2]).Count();
            if (occurences == 3)
                return Rank.ThreeOfAKind;

            occurences = cards.Where(card => card == cards[2] || card == 'J').Count();
            if (occurences == 3)
                return Rank.ThreeOfAKind;

            occurences = cards.Where(card => card == cards[3]).Count();
            if (occurences == 3)
                return Rank.ThreeOfAKind;

            occurences = cards.Where(card => card == cards[3] || card == 'J').Count();
            if (occurences == 3)
                return Rank.ThreeOfAKind;

            return Rank.TwoPair;
        }

        if (distinctCards == 4 || (distinctCards == 5 && cards.Contains('J')))
            return Rank.OnePair;

        return Rank.HighCard;
    }
}
