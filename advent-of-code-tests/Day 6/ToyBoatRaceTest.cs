using advent_of_code.Day_6;

namespace advent_of_code_tests.Day_6
{
    public class ToyBoatRaceTest
    {
        private readonly Dictionary<int, int> _races = new()
        {
            { 7, 9 },
            { 15, 40 },
            { 30, 200 }
        };


        [Fact]
        public void DetermineBeatingTheRecord_ReturnsTheNumberOfWaysMultiplied()
        {
            ToyBoatRace race = new(_races);

            long result = race.DetermineBeatingTheRecord();

            Assert.Equal(288, result);
        }

        [Fact]
        public void DetermineNumberOfWaysYouCanBeatTheRecord()
        {
            long time = 71530;
            long distance = 940200;

            var result = ToyBoatRace.DetermineNumberOfWaysYouCanBeatTheRecord(time, distance);

            Assert.Equal(71503, result);
        }
    }
}
