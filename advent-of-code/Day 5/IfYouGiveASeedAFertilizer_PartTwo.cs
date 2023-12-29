using advent_of_code.Day_5;

namespace advent_of_code
{
    public static class IfYouGiveASeedAFertilizer_PartTwo
    {
        public static void Run()
        {
            string line;
            List<string> text = [];
            try
            {
                StreamReader sr = new("D:\\Git\\advent-of-code-2023\\advent-of-code\\Day 5\\input-if-you-give-a-seed-a-fertilizer.txt");
                line = sr.ReadLine();

                while (line != null)
                {
                    text.Add(line);
                    line = sr.ReadLine();
                }

                sr.Close();

                TextFormatter formatter = new([.. text]);
                var ranges = formatter.FindSeeds();
                var seedToSoilMap = formatter.FindSeedToSoilMap();
                var soilToFertilizerMap = formatter.FindSoilToFertilizerMap();
                var fertilizerToWaterMap = formatter.FindFertilizerToWaterMap();
                var waterToLightMap = formatter.FindWaterToLightMap();
                var lightToTemperatureMap = formatter.FindLightToTemperatureMap();
                var temperatureToHumidityMap = formatter.FindTemperatureToHumidityMap();
                var humidityToLocationMap = formatter.FindHumidityToLocationMap();

                SeedAnalyzer analyzer = new( 
                    seedToSoilMap, 
                    soilToFertilizerMap, 
                    fertilizerToWaterMap,
                    waterToLightMap,
                    lightToTemperatureMap,
                    temperatureToHumidityMap,
                    humidityToLocationMap);

                Console.WriteLine($"Lowest location number: {analyzer.FindLowestLocationFromRanges(ranges)}");

                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine($"Exception: {e.Message}");
                throw;
            }
            finally
            {
                Console.WriteLine("Executing final block.");
            }
        }
    }
}
