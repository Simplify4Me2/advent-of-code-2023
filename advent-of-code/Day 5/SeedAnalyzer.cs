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

        private long FindLowestLocationFromRanges(long[] ranges)
        {
            return 0;
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

            for (int i = 0; i < input.Length; i++)
            {
                long mappedValue = input[i];
                bool hasBeenMapped = false;
                for (int j = 0; j < mapping.Length; j++)
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
