using advent_of_code.Day_2;
using System.Collections;

namespace advent_of_code_tests.Day_2
{
    public class CalbriationDataGenerator : IEnumerable<object[]>
    {
        private readonly List<object[]> _data = new List<object[]>
        {
            new object[] { "three2fiveonexrllxsvfive", 35 },
            new object[] { "8qlhdpxn645nhrjm", 85 },
            new object[] { "43eightnvdrthree1eightoneggrdmnp", 41 },
            new object[] { "six6lbbqlttnvfiverxceightwobx", 62 },
            new object[] { "43eightnvdrthree1eightoneggrdmnp", 41 },
            new object[] { "ninetwo6hfg", 96 },
        };

        public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public class CalibrationLineTest
    {
        [Fact]
        public void FirstNumberIsDigit_ReturnsFirstNumber()
        {
            var line = "4nineeightseven2";

            var sut = new CalibrationLine(line);

            Assert.Equal(42, sut.Value);
        }

        [Fact]
        public void FirstValueIsSpelledOutWithLetters_ReturnsFirstNumber()
        {
            var line = "zoneight234";

            var sut = new CalibrationLine(line);

            Assert.Equal(14, sut.Value);
        }

        [Fact]
        public void LastNumberIsDigit_ReturnsLastNumber()
        {
            var line = "4nineeightseven2";

            var sut = new CalibrationLine(line);

            Assert.Equal(42, sut.Value);
        }

        [Fact]
        public void LastNumberIsSpelledOutWithLetters_ReturnsLastNumber()
        {
            var line = "three2fiveonexrllxsvfive";

            var sut = new CalibrationLine(line);

            Assert.Equal(35, sut.Value);
        }

        [Theory]
        [ClassData(typeof(CalbriationDataGenerator))]
        public void Value_ReturnsFirstAndLastNumber(string line, int expectedResult)
        {
            var sut = new CalibrationLine(line);
            Assert.Equal(expectedResult, sut.Value);
        }
    }
}
