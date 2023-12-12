using advent_of_code.Day_2;

namespace advent_of_code_tests.Day_2
{
    public class LineFormatterTest
    {
        [Fact]
        public void FindId_ReturnsId()
        {
            string line = "Game 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red";

            var result = LineFormatter.FindId(line);

            Assert.Equal(4, result);
        }

        [Fact]
        public void ToGame_ReturnsAllGames()
        {
            string line = "Game 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red";

            var result = LineFormatter.FindGames(line);

            Assert.Equal(3, result.Length);
        }

        [Theory]
        [InlineData("red", 3)]
        [InlineData("green", 2)]
        [InlineData("blue", 6)]
        public void FindValue_ReturnsColorValue(string color, int value)
        {
            string line = "2 green, 3 red, 6 blue";

            var result = LineFormatter.FindValue(line, color);

            Assert.Equal(value, result);
        }

        [Fact]
        public void FindValue_Null_ReturnsZero()
        {
            string line = "1 green, 6 blue";

            var result = LineFormatter.FindValue(line, "red");

            Assert.Equal(0, result);
        }
    }
}
