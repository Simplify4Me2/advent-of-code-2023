using advent_of_code.Day_7;
using System.Collections;

namespace advent_of_code_tests.Day_7
{
    public class PlayingCardsGenerator : IEnumerable<object[]>
    {
        private readonly List<object[]> _data =
        [
            [new char[] { 'A', 'A', 'A', 'A', 'J' }, Rank.FiveOfAKind],

            [new char[] { 'A', 'A', 'A', 'A', 'K' }, Rank.FourOfAKind],
            [new char[] { 'A', 'A', 'A', 'K', 'A' }, Rank.FourOfAKind],
            [new char[] { 'A', 'A', 'K', 'A', 'A' }, Rank.FourOfAKind],
            [new char[] { 'A', 'K', 'A', 'A', 'A' }, Rank.FourOfAKind],
            [new char[] { 'K', 'A', 'A', 'A', 'A' }, Rank.FourOfAKind],
            [new char[] { 'A', 'A', 'A', 'J', 'K' }, Rank.FourOfAKind],
            [new char[] { 'A', 'A', 'J', 'K', 'A' }, Rank.FourOfAKind],
            [new char[] { 'A', 'J', 'K', 'A', 'A' }, Rank.FourOfAKind],
            [new char[] { 'J', 'K', 'A', 'A', 'A' }, Rank.FourOfAKind],
            [new char[] { 'K', 'A', 'A', 'A', 'J' }, Rank.FourOfAKind],
            [new char[] { 'A', 'A', 'J', 'J', 'K' }, Rank.FourOfAKind],
            [new char[] { 'A', 'J', 'J', 'K', 'A' }, Rank.FourOfAKind],
            [new char[] { 'J', 'J', 'K', 'A', 'A' }, Rank.FourOfAKind],
            [new char[] { 'J', 'K', 'A', 'A', 'J' }, Rank.FourOfAKind],
            [new char[] { 'K', 'A', 'A', 'J', 'J' }, Rank.FourOfAKind],
            [new char[] { 'A', 'J', 'J', 'J', 'K' }, Rank.FourOfAKind],
            [new char[] { 'J', 'J', 'J', 'K', 'A' }, Rank.FourOfAKind],
            [new char[] { 'J', 'J', 'K', 'A', 'J' }, Rank.FourOfAKind],
            [new char[] { 'J', 'K', 'A', 'J', 'J' }, Rank.FourOfAKind],
            [new char[] { 'K', 'A', 'J', 'J', 'J' }, Rank.FourOfAKind],

            [new char[] { 'A', 'A', 'A', 'K', 'K' }, Rank.FullHouse],
            [new char[] { 'A', 'A', 'K', 'K', 'A' }, Rank.FullHouse],
            [new char[] { 'A', 'K', 'K', 'A', 'A' }, Rank.FullHouse],
            [new char[] { 'K', 'K', 'A', 'A', 'A' }, Rank.FullHouse],
            [new char[] { 'K', 'A', 'A', 'A', 'K' }, Rank.FullHouse],
            [new char[] { 'A', 'A', 'J', 'K', 'K' }, Rank.FullHouse],
            [new char[] { 'A', 'J', 'K', 'K', 'A' }, Rank.FullHouse],
            [new char[] { 'J', 'K', 'K', 'A', 'A' }, Rank.FullHouse],
            [new char[] { 'K', 'K', 'A', 'A', 'J' }, Rank.FullHouse],
            [new char[] { 'K', 'A', 'A', 'J', 'K' }, Rank.FullHouse],

            [new char[] { 'A', 'A', 'A', 'K', 'Q' }, Rank.ThreeOfAKind],
            [new char[] { 'A', 'A', 'K', 'Q', 'A' }, Rank.ThreeOfAKind],
            [new char[] { 'A', 'K', 'Q', 'A', 'A' }, Rank.ThreeOfAKind],
            [new char[] { 'K', 'Q', 'A', 'A', 'A' }, Rank.ThreeOfAKind],
            [new char[] { 'Q', 'A', 'A', 'A', 'K' }, Rank.ThreeOfAKind],
            [new char[] { 'A', 'A', 'J', 'K', 'Q' }, Rank.ThreeOfAKind],
            [new char[] { 'A', 'J', 'K', 'Q', 'A' }, Rank.ThreeOfAKind],
            [new char[] { 'J', 'K', 'Q', 'A', 'A' }, Rank.ThreeOfAKind],
            [new char[] { 'K', 'Q', 'A', 'A', 'J' }, Rank.ThreeOfAKind],
            [new char[] { 'Q', 'A', 'A', 'J', 'K' }, Rank.ThreeOfAKind],
            [new char[] { 'A', 'J', 'J', 'K', 'Q' }, Rank.ThreeOfAKind],
            [new char[] { 'J', 'J', 'K', 'Q', 'A' }, Rank.ThreeOfAKind],
            [new char[] { 'J', 'K', 'Q', 'A', 'J' }, Rank.ThreeOfAKind],
            [new char[] { 'K', 'Q', 'A', 'J', 'J' }, Rank.ThreeOfAKind],
            [new char[] { 'Q', 'A', 'J', 'J', 'K' }, Rank.ThreeOfAKind],

            [new char[] { 'A', 'A', 'K', 'K', 'Q' }, Rank.TwoPair],
            [new char[] { 'A', 'K', 'K', 'Q', 'A' }, Rank.TwoPair],
            [new char[] { 'K', 'K', 'Q', 'A', 'A' }, Rank.TwoPair],
            [new char[] { 'K', 'Q', 'A', 'A', 'K' }, Rank.TwoPair],
            [new char[] { 'Q', 'A', 'A', 'K', 'K' }, Rank.TwoPair],

            [new char[] { 'A', 'K', 'Q', 'T', 'J' }, Rank.OnePair],
            [new char[] { 'K', 'Q', 'T', 'J', 'A' }, Rank.OnePair],
            [new char[] { 'Q', 'T', 'J', 'A', 'K' }, Rank.OnePair],
            [new char[] { 'T', 'J', 'A', 'K', 'Q' }, Rank.OnePair],
            [new char[] { 'J', 'A', 'K', 'Q', 'T' }, Rank.OnePair],

            [new char[] { 'A', 'K', 'Q', 'T', '9' }, Rank.HighCard],

            [new char[] { 'J', '5', 'J', '3', '3' }, Rank.FourOfAKind],
        ];

        public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public class PlayingCardsTest
    {
        [Theory]
        [ClassData(typeof(PlayingCardsGenerator))]
        public void Hand_ReturnsRank(char[] cards, Rank expected)
        {
            PlayingCards playingCards = new(cards, 0);

            Assert.Equal(expected, playingCards.Rank);
        }
    }
}
