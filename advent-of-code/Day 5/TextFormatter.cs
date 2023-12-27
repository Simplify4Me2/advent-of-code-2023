namespace advent_of_code.Day_5
{
    public class TextFormatter(string[] text)
    {
        public string[] Text { get; } = text;

        public int[] FindSeeds()
        {
            var firstLine = Text[0];
            string[] numbersAsText = firstLine.Split(':')[1].Split(' ');

            List<int> seeds = [];
            foreach (var number in numbersAsText)
            {
                if (int.TryParse(number, out int value))
                    seeds.Add(value);
            }

            return [.. seeds];
        }

        public int[][] FindSeedToSoilMap() => FindMap("seed-to-soil");

        public int[][] FindSoilToFertilizerMap() => FindMap("soil-to-fertilizer");

        public int[][] FindFertilizerToWaterMap() => FindMap("fertilizer-to-water");

        public int[][] FindWaterToLightMap() => FindMap("water-to-light");

        public int[][] FindLightToTemperatureMap() => FindMap("light-to-temperature");

        public int[][] FindTemperatureToHumidityMap() => FindMap("temperature-to-humidity");

        public int[][] FindHumidityToLocationMap() => FindMap("humidity-to-location");

        private int[][] FindMap(string mapName)
        {
            string definitionLine = Text.First(line => line.Contains(mapName));
            int index = Array.IndexOf(Text, definitionLine);

            List<int[]> map = [];

            string nextLine = Text[index++];
            do
            {
                string[] numbersAsText = nextLine.Split(' ');
                List<int> sequence = [];

                foreach (var number in numbersAsText)
                {
                    if (int.TryParse(number, out int value))
                        sequence.Add(value);
                }
                map.Add([.. sequence]);
                nextLine = Text[index++];
            } while (nextLine != string.Empty);

            return [.. map];
        }
    }
}
