using advent_of_code.Day_5;

namespace advent_of_code
{
    public static class IfYouGiveASeedAFertilizer_PartOne
    {
        public static void Run()
        {
            string line;
            List<string> text = [];
            try
            {
                StreamReader sr = new("D:\\Git\\advent-of-code-2023\\advent-of-code\\Day 5\\sample-if-you-give-a-seed-a-fertilizer.txt");
                line = sr.ReadLine();

                while (line != null)
                {
                    text.Add(line);
                    line = sr.ReadLine();
                }

                sr.Close();

                TextFormatter formatter = new([.. text]);

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
