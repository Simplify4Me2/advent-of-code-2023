using advent_of_code.Day_6;

namespace advent_of_code
{
    public static class WaitForIt_PartOne
    {
        public static void Run()
        {
            string line;
            List<string> text = [];

            try
            {
                StreamReader sr = new("D:\\Git\\advent-of-code-2023\\advent-of-code\\Day 6\\input-wait-for-it.txt");
                line = sr.ReadLine();

                while (line != null)
                {
                    text.Add(line);
                    line = sr.ReadLine();
                }

                sr.Close();

                List<int> timings = [];
                List<int> distances = [];
                foreach (string item in text[0].Split(':')[1].Split(' '))
                {
                    if (int.TryParse(item.Trim(), out int value))
                        timings.Add(value);
                }
                foreach (string item in text[1].Split(':')[1].Split(' '))
                {
                    if (int.TryParse(item.Trim(), out int value))
                        distances.Add(value);
                }

                Dictionary<int, int> races = [];
                for (int i = 0; i < timings.Count; i++)
                {
                    races.Add(timings[i], distances[i]);
                }

                ToyBoatRace race = new(races);

                Console.WriteLine($"Result: {race.DetermineBeatingTheRecord()}");
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
