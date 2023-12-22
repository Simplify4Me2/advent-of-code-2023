using advent_of_code.Day_4;

namespace advent_of_code
{
    public static class Scratchcards_PartOne
    {
        public static void Run()
        {
            string line;
            try
            {
                StreamReader sr = new("D:\\Git\\advent-of-code-2023\\advent-of-code\\Day 4\\sample-scratch-cards.txt");
                line = sr.ReadLine();


                while (line != null)
                {

                    Console.WriteLine($"{line}");

                    LineFormatter formatter = new(line);
                    


                    line = sr.ReadLine();
                }

                sr.Close();

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
