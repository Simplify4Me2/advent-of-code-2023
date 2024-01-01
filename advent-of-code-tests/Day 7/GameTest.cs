using advent_of_code.Day_7;
using System.Collections;

namespace advent_of_code_tests.Day_7;

public class GameDataGenerator : IEnumerable<object[]>
{
    private readonly List<object[]> _data =
    [
        [new Hand[] 
        {
            new Hand(['3', '2', 'T', '3', 'K'], 765),
            new Hand(['T', '5', '5', 'J', '5'], 684),
            new Hand(['K', 'K', '6', '7', '7'], 28),
            new Hand(['K', 'T', 'J', 'J', 'T'], 220),
            new Hand(['Q', 'Q', 'Q', 'J', 'A'], 483)
        },
        6440]
    ];

    public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}

public class GameTest
{
    readonly Hand[] hands = [
        new Hand(['3', '2', 'T', '3', 'K'], 765),
        new Hand(['T', '5', '5', 'J', '5'], 684),
        new Hand(['K', 'K', '6', '7', '7'], 28),
        new Hand(['K', 'T', 'J', 'J', 'T'], 220),
        new Hand(['Q', 'Q', 'Q', 'J', 'A'], 483),
    ];

    [Theory]
    [ClassData(typeof(GameDataGenerator))]
    public void DetermineTotalWinnings_ReturnsSumofEachHandsBidMultipliedWithItsRank(Hand[] hands, int expectedWinnings)
    {
        Game game = new(hands);

        Assert.Equal(expectedWinnings, game.TotalWinnings);
    }
}
