using advent_of_code.Day_5;

namespace advent_of_code_tests.Day_5
{
    public class SeedAnalyzerTest
    {
        private readonly long[] _seeds = [79, 14, 55, 13]; 
        private readonly long[] _ranges = [79, 14, 55, 13]; 
        private readonly long[][] _seedToSoilMap =
            [
                [50, 98, 2],
                [52, 50, 48]
            ];
        private readonly long[][] _soilToFertilizerMap =
            [
                [0, 15, 37],
                [37, 52, 2],
                [39, 0, 15]
            ];
        private readonly long[][] _fertilizerToWaterMap =
            [
                [49, 53, 8],
                [0, 11, 42],
                [42, 0, 7],
                [57, 7, 4]
            ];
        private readonly long[][] _waterToLightMap =
            [
                [88, 18, 7],
                [18, 25, 70]
            ];
        private readonly long[][] _lightToTemperatureMap =
            [
                [45, 77, 23],
                [81, 45, 19],
                [68, 64, 13]
            ];
        private readonly long[][] _temperatureToHumidityMap =
            [
                [0, 69, 1],
                [1, 0, 69]
            ];
        private readonly long[][] _humidityToLocationMap =
            [
                [60, 56, 37],
                [56, 93, 4]
            ];

        [Fact]
        public void LowestLocationFromSeeds_ReturnsLowestMappedValue()
        {
            SeedAnalyzer analyzer = new(_seedToSoilMap, _soilToFertilizerMap, _fertilizerToWaterMap, _waterToLightMap, _lightToTemperatureMap, _temperatureToHumidityMap, _humidityToLocationMap);
            Assert.Equal(35, analyzer.FindLowestLocationFromSeeds(_seeds));
        }

        [Fact]
        public void LowestLocationFromRanges_ReturnsLowestMappedValue()
        {
            SeedAnalyzer analyzer = new(_seedToSoilMap, _soilToFertilizerMap, _fertilizerToWaterMap, _waterToLightMap, _lightToTemperatureMap, _temperatureToHumidityMap, _humidityToLocationMap);
            Assert.Equal(46, analyzer.FindLowestLocationFromRanges(_ranges));
        }
    }
}
