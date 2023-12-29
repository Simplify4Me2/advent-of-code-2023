using System.Runtime.CompilerServices;

namespace advent_of_code.Day_5
{
    public class SeedAnalyzer(long[] seeds, long[][] seedToSoilMap, long[][] soilToFertilizerMap, long[][] fertilizerToWaterMap, long[][] waterToLightMap, long[][] lightToTemperatureMap, long[][] temperatureToHumidityMap, long[][] humidityToLocationMap)
    {
        public long LowestLocation => FindLowestLocation();

        private long FindLowestLocation()
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

        public long[] LookUpSoilNumber(long[] seeds)
        {
            return Map(seeds, seedToSoilMap);
        }

        public long[] LookUpFertilizerNumber(long[] soils)
        {
            return Map(soils, soilToFertilizerMap);
        }

        public long[] LookUpWaterNumber(long[] fertilizer)
        {
            List<long> result = [];

            for (int i = 0; i < fertilizer.Length; i++)
            {
                long mappedValue = fertilizer[i];
                bool hasBeenMapped = false;
                for (int j = 0; j < fertilizerToWaterMap.Length; j++)
                {
                    long destinationRangeStart = fertilizerToWaterMap[j][0];
                    long sourceRangeStart = fertilizerToWaterMap[j][1];
                    long rangeLength = fertilizerToWaterMap[j][2];

                    if (!hasBeenMapped && mappedValue >= sourceRangeStart && mappedValue < sourceRangeStart + rangeLength)
                    {
                        mappedValue += (destinationRangeStart - sourceRangeStart);

                        //var foo = mappedValue - sourceRangeStart;
                        //var bar = destinationRangeStart + foo;
                        //mappedValue = bar;
                        hasBeenMapped = true;
                    }

                }
                result.Add(mappedValue);
            }

            return [.. result];

            //return Map(fertilizer, fertilizerToWaterMap);
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
