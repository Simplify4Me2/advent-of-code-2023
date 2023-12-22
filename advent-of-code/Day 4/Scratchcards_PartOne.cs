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
                StreamReader sr = new("D:\\Git\\advent-of-code-2023\\advent-of-code\\Day 4\\input-scratch-cards.txt");
                line = sr.ReadLine();

                int sum = 0;
                while (line != null)
                {

                    Console.WriteLine($"{line}");

                    LineFormatter formatter = new(line);

                    Scratchcard scratchcard = new(formatter.WinningNumbers.ToArray(), formatter.NumbersYouHave.ToArray());
                    sum += scratchcard.Points;

                    line = sr.ReadLine();
                }

                sr.Close();

                Console.WriteLine($"Sum: {sum}");
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
