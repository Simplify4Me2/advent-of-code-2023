using advent_of_code.Day_3;

namespace advent_of_code
{
    public class GearRatios_PartTwo
    {
        public static void Run()
        {
            List<string> list = [];
            string line;
            try
            {
                StreamReader sr = new("D:\\Git\\advent-of-code-2023\\advent-of-code\\Day 3\\input-gear-ratios.txt");
                line = sr.ReadLine();


                while (line != null)
                {

                    list.Add(line);

                    line = sr.ReadLine();
                }

                var engineSchematic = new EngineSchematic(list);

                Console.WriteLine($"Sum: {engineSchematic.GearRatios.Sum()}");

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
