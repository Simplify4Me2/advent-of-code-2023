namespace advent_of_code.Day_5
{
    public class TextFormatter(string[] text)
    {
        public string[] Text { get; } = text;

        public long[] FindSeeds()
        {
            var firstLine = Text[0];
            string[] numbersAsText = firstLine.Split(':')[1].Split(' ');

            List<long> seeds = [];
            foreach (var number in numbersAsText)
            {
                if (Int64.TryParse(number, out long value))
                    seeds.Add(value);
            }

            return [.. seeds];
        }

        public long[][] FindSeedToSoilMap() => FindMap("seed-to-soil");

        public long[][] FindSoilToFertilizerMap() => FindMap("soil-to-fertilizer");

        public long[][] FindFertilizerToWaterMap() => FindMap("fertilizer-to-water");

        public long[][] FindWaterToLightMap() => FindMap("water-to-light");

        public long[][] FindLightToTemperatureMap() => FindMap("light-to-temperature");

        public long[][] FindTemperatureToHumidityMap() => FindMap("temperature-to-humidity");

        public long[][] FindHumidityToLocationMap() => FindMap("humidity-to-location");

        private long[][] FindMap(string mapName)
        {
            string definitionLine = Text.First(line => line.Contains(mapName));
            int index = Array.IndexOf(Text, definitionLine) + 1;

            List<long[]> map = [];

            string nextLine = Text[index++];
            do
            {
                string[] numbersAsText = nextLine.Split(' ');
                List<long> sequence = [];

                foreach (var number in numbersAsText)
                {
                    if (Int64.TryParse(number, out long value))
                        sequence.Add(value);
                }
                if (sequence.Count != 3) throw new ArgumentException($"Sequence doesn't contain 3 values: {sequence}");
                map.Add([.. sequence]);
                nextLine = index < Text.Length ? Text[index++] : string.Empty;
            } while (nextLine != string.Empty);

            return [.. map];
        }
    }
}
