namespace advent_of_code.Day_5
{
    public class SeedAnalyzer(long[][] seedToSoilMap, long[][] soilToFertilizerMap, long[][] fertilizerToWaterMap, long[][] waterToLightMap, long[][] lightToTemperatureMap, long[][] temperatureToHumidityMap, long[][] humidityToLocationMap)
    {
        public long FindLowestLocationFromSeeds(long[] seeds)
        {
            var soil = Map(seeds, seedToSoilMap);
            var fertilizer = Map(soil, soilToFertilizerMap);
            var water = Map(fertilizer, fertilizerToWaterMap);
            var light = Map(water, waterToLightMap);
            var temperature = Map(light, lightToTemperatureMap);
            var humidity = Map(temperature, temperatureToHumidityMap);
            var location = Map(humidity, humidityToLocationMap);

            return location.Min();
        }

        public long FindLowestLocationFromRanges(long[] ranges)
        {
            if (ranges.Length % 2 != 0) throw new ArgumentException("Range length is not an even number");
            long lowestValue = long.MaxValue;

            for (long i = 0; i < ranges.Length; i += 2)
            {
                long start = ranges[i];
                long range = ranges[i + 1];
                List<long> seeds = [];
                for (long j = 0; j < range / 2; j++)
                {
                    seeds.Add(start + j);
                }
                long lowestLocation = FindLowestLocationFromSeeds([.. seeds]);
                if (lowestLocation < lowestValue)
                    lowestValue = lowestLocation;

                seeds = [];
                for (long j = range / 2; j < range; j++)
                {
                    seeds.Add(start + j);
                }
                lowestLocation = FindLowestLocationFromSeeds([.. seeds]);
                if (lowestLocation < lowestValue)
                    lowestValue = lowestLocation;
            }

            return lowestValue;
        }

        private long FindLowestLocation(long[] seeds) 
        {
            var soil = Map(seeds, seedToSoilMap);
            var fertilizer = Map(soil, soilToFertilizerMap);
            var water = Map(fertilizer, fertilizerToWaterMap);
            var light = Map(water, waterToLightMap);
            var temperature = Map(light, lightToTemperatureMap);
            var humidity = Map(temperature, temperatureToHumidityMap);
            var location = Map(humidity, humidityToLocationMap);

            return location.Min();
        }

        private long[] Map(long[] input, long[][] mapping)
        {
            List<long> result = [];

            for (long i = 0; i < input.Length; i++)
            {
                long mappedValue = input[i];
                bool hasBeenMapped = false;
                for (long j = 0; j < mapping.Length; j++)
                {
                    long destinationRangeStart = mapping[j][0];
                    long sourceRangeStart = mapping[j][1];
                    long rangeLength = mapping[j][2];

                    if (!hasBeenMapped && mappedValue >= sourceRangeStart && mappedValue < sourceRangeStart + rangeLength)
                    {
                        mappedValue += (destinationRangeStart - sourceRangeStart);
                        hasBeenMapped = true;
                    }

                }
                result.Add(mappedValue);
            }

            return [.. result];
        }
    }
}
