using advent_of_code.Day_7;

namespace advent_of_code_tests.Day_7;

public class GameTest
{
    readonly Hand[] hands = [
        new Hand(['3', '2', 'T', '3', 'K'], 765),
        new Hand(['T', '5', '5', 'J', '5'], 684),
        new Hand(['K', 'K', '6', '7', '7'], 28),
        new Hand(['K', 'T', 'J', 'J', 'T'], 220),
        new Hand(['Q', 'Q', 'Q', 'J', 'A'], 483),
    ];

    [Fact]
    public void DetermineTotalWinnings_ReturnsSumofEachHandsBidMultipliedWithItsRank()
    {
        Game game = new(hands);

        Assert.Equal(6440, game.TotalWinnings);
    }
}
