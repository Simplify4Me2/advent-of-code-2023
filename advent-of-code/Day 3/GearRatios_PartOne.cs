namespace advent_of_code
{
    public class GearRatios_PartOne
    {
        public static void Run()
        {
            char[,] grid = new char[10, 10];
            string line;
            try
            {
                StreamReader sr = new("D:\\Git\\advent-of-code-2023\\advent-of-code\\Day 3\\sample-gear-ratios.txt");
                line = sr.ReadLine();
                while (line != null)
                {
                    Console.WriteLine($"Line: {line}");


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
