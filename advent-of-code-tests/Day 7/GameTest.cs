using advent_of_code.Day_7;
using System.Collections;

namespace advent_of_code_tests.Day_7;

public class GameDataGenerator : IEnumerable<object[]>
{
    private readonly List<object[]> _data =
    [
        [new Hand[] 
        {
            new(['3', '2', 'T', '3', 'K'], 765),
            new(['T', '5', '5', 'J', '5'], 684),
            new(['K', 'K', '6', '7', '7'], 28),
            new(['K', 'T', 'J', 'J', 'T'], 220),
            new(['Q', 'Q', 'Q', 'J', 'A'], 483)
        },
        6440]
    ];

    public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}

public class GameTest
{
    [Theory]
    [ClassData(typeof(GameDataGenerator))]
    public void DetermineTotalWinnings(Hand[] hands, int expectedWinnings)
    {
        Game game = new(hands, false);

        Assert.Equal(expectedWinnings, game.TotalWinnings);
    }

    [Fact]
    public void DetermineTotalWinnings_JokersAreWild()
    {
        var hands = new PlayingCards[]
        {
            new(['3', '2', 'T', '3', 'K'], 765),
            new(['T', '5', '5', 'J', '5'], 684),
            new(['K', 'K', '6', '7', '7'], 28),
            new(['K', 'T', 'J', 'J', 'T'], 220),
            new(['Q', 'Q', 'Q', 'J', 'A'], 483)
        };

        Game game = new(hands, true);

        Assert.Equal(5905, game.TotalWinnings);
    }
}
