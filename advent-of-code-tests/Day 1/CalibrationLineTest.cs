using advent_of_code.Day_1;
using System.Collections;

namespace advent_of_code_tests.Day_1
{
    public class CalbriationDataGenerator : IEnumerable<object[]>
    {
        private readonly List<object[]> _data =
        [
            ["three2fiveonexrllxsvfive", 35],
            [ "8qlhdpxn645nhrjm", 85 ],
            [ "43eightnvdrthree1eightoneggrdmnp", 41 ],
            [ "six6lbbqlttnvfiverxceightwobx", 62 ],
            [ "43eightnvdrthree1eightoneggrdmnp", 41 ],
            [ "ninetwo6hfg", 96 ],
        ];

        public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public class CalibrationLineTest
    {
        [Theory]
        [ClassData(typeof(CalbriationDataGenerator))]
        public void Value_ReturnsFirstAndLastNumber(string line, int expectedResult)
        {
            var sut = new CalibrationLine(line);
            Assert.Equal(expectedResult, sut.Value);
        }
    }
}
