using advent_of_code.Day_4;

namespace advent_of_code
{
    public static class Scratchcards_PartTwo
    {
        public static void Run()
        {
            List<Scratchcard> allScratchcards = [];
            string line;
            try
            {
                StreamReader sr = new("D:\\Git\\advent-of-code-2023\\advent-of-code\\Day 4\\input-scratch-cards.txt");
                line = sr.ReadLine();

                while (line != null)
                {
                    LineFormatter formatter = new(line);

                    Scratchcard scratchcard = new([.. formatter.WinningNumbers], [.. formatter.NumbersYouHave]);
                    allScratchcards.Add(scratchcard);

                    line = sr.ReadLine();
                }

                sr.Close();

                ScratchcardCollection collection = new([.. allScratchcards]);
                Console.WriteLine($"Total: {collection.Total}");
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
