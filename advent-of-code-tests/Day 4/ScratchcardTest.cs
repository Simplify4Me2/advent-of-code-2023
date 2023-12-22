
using advent_of_code.Day_4;
using System.Collections;

namespace advent_of_code_tests.Day_4
{
    public class ScratchcardGenerator : IEnumerable<object[]>
    {
        private readonly List<object[]> _data =
        [
            [new int[] { 41, 48, 83, 86, 17 }, new int[] { 83, 86, 6, 31, 17, 9, 48, 53 }, 8],
            [new int[] { 13, 32, 20, 16, 61 }, new int[] { 61, 30, 68, 82, 17, 32, 24, 19 }, 2],
            [new int[] { 1, 21, 53, 59, 44 }, new int[] { 69, 82, 63, 72, 16, 21, 14, 1 }, 2],
            [new int[] { 41, 92, 73, 84, 69 }, new int[] { 59, 84, 76, 51, 58, 5, 54, 83 }, 1],
            [new int[] { 87, 83, 26, 28, 32 }, new int[] { 88, 30, 70, 12, 93, 22, 82, 36 }, 0],
            [new int[] { 31, 18, 13, 56, 72 }, new int[] { 74, 77, 10, 23, 35, 67, 36, 11 }, 0],
        ];

        public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public class ScratchcardTest
    {
        [Theory]
        [ClassData(typeof(ScratchcardGenerator))]
        public void Points_ReturnsWinningPoints(int[] winningNumbers, int[] yourNumbers, int expected)
        {
            Scratchcard scratchcard = new(winningNumbers, yourNumbers);

            Assert.Equal(expected, scratchcard.Points);
        }
    }
}
