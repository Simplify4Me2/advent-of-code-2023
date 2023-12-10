namespace advent_of_code
{
    public static class Trebuchet_PartOne
    {
        public static void Run()
        {
            int sum = 0;
            String line;
            try
            {
                StreamReader sr = new("D:\\Git\\advent-of-code-2023\\advent-of-code\\Day 1\\input-trebuchet-part-one.txt");
                line = sr.ReadLine();
                while (line != null)
                {
                    Console.WriteLine(line);

                    int? firstNumber = null;
                    int? lastNumber = null;
                    foreach (char c in line)
                    {
                        if (int.TryParse(c.ToString(), out int number)) lastNumber = number;

                        firstNumber ??= lastNumber;
                    }

                    Console.WriteLine($"First number: {firstNumber}");
                    Console.WriteLine($"Last number: {lastNumber}");

                    int calibrationValue = (firstNumber.Value * 10) + lastNumber.Value;
                    sum += calibrationValue;
                    Console.WriteLine($"Calibration value: {calibrationValue}");

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
