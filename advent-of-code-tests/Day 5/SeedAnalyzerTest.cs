using advent_of_code.Day_5;

namespace advent_of_code_tests.Day_5
{
    public class SeedAnalyzerTest
    {
        private readonly long[] _seeds = [79, 14, 55, 13];
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
        public void MapsSeedToSoil()
        {
            SeedAnalyzer analyzer = new(_seeds, _seedToSoilMap, null, null, null, null, null, null);

            var result = analyzer.LookUpSoilNumber(_seeds);

            Assert.NotEmpty(result);
            Assert.Equal(4, _seeds.Length);
            Assert.Equal(81, result[0]);
            Assert.Equal(14, result[1]);
            Assert.Equal(57, result[2]);
            Assert.Equal(13, result[3]);
        }

        [Fact]
        public void MapsSoilToFertilizer()
        {
            SeedAnalyzer analyzer = new(_seeds, null, _soilToFertilizerMap, null, null, null, null, null);
            var soils = new long[] { 81, 14, 57, 13 };

            var result = analyzer.LookUpFertilizerNumber(soils);

            Assert.NotEmpty(result);
            Assert.Equal(4, soils.Length);
            Assert.Equal(81, result[0]);
            Assert.Equal(53, result[1]);
            Assert.Equal(57, result[2]);
            Assert.Equal(52, result[3]);
        }

        [Fact]
        public void MapsFertilizerToWater()
        {
            SeedAnalyzer analyzer = new(_seeds, null, null, _fertilizerToWaterMap, null, null, null, null);
            var fertilizer = new long[] { 81, 53, 57, 52 };

            var result = analyzer.LookUpWaterNumber(fertilizer);

            Assert.NotEmpty(result);
            Assert.Equal(4, fertilizer.Length);
            Assert.Equal(81, result[0]);
            Assert.Equal(49, result[1]);
            Assert.Equal(53, result[2]);
            Assert.Equal(41, result[3]);
        }

        [Fact]
        public void MapsFertilizerToWaterWithZeroMappingValue()
        {
            SeedAnalyzer analyzer = new(_seeds, null, null, _fertilizerToWaterMap, null, null, null, null);
            var fertilizer = new long[] { 53, 57, 52 };

            var result = analyzer.LookUpWaterNumber(fertilizer);

            Assert.NotEmpty(result);
            Assert.Equal(3, fertilizer.Length);
            Assert.Equal(49, result[0]);
            Assert.Equal(53, result[1]);
            Assert.Equal(41, result[2]);
        }

        [Fact]
        public void LowestLocation_CorrespondsToAnyOfTheInitialSeeds()
        {
            SeedAnalyzer analyzer = new(_seeds, _seedToSoilMap, _soilToFertilizerMap, _fertilizerToWaterMap, _waterToLightMap, _lightToTemperatureMap, _temperatureToHumidityMap, _humidityToLocationMap);
            Assert.Equal(35, analyzer.LowestLocation);
        }
    }
}
