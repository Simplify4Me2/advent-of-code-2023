using advent_of_code.Day_2;

namespace advent_of_code_tests.Day_2
{
    public class GameTest
    {
        [Theory]
        [InlineData(20, 8, 6, false)]
        [InlineData(4, 13, 5, true)]
        [InlineData(14, 3, 15, false)]
        [InlineData(6, 0, 1, true)]
        public void IsPossible_AllColorValuesAreLowerThanTheAmountAvailable(int red, int green, int blue, bool expected)
        {
            var result = new Game(red, green, blue);

            Assert.Equal(expected, result.IsPossible);
        }
    }
}
