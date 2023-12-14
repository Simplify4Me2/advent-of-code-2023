using advent_of_code.Day_1;

namespace advent_of_code
{
    public static class Trebuchet_PartTwo
    {


        public static void Run()
        {

            int sum = 0;
            string line;
            try
            {
                StreamReader sr = new("D:\\Git\\advent-of-code-2023\\advent-of-code\\Day 1\\input-trebuchet-part-one.txt");
                line = sr.ReadLine();
                while (line is not null)
                {
                    Console.WriteLine(line);

                    CalibrationLine calibrationLine = new(line);

                    Console.WriteLine($"Calibration value: {calibrationLine.Value}");
                    sum += calibrationLine.Value;

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
