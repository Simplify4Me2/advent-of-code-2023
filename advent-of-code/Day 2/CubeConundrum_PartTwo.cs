using advent_of_code.Day_2;

namespace advent_of_code
{
    public static class CubeConundrum_PartTwo
    {
        public static void Run()
        {
            string line;
            try
            {
                int sum = 0;
                StreamReader sr = new("D:\\Git\\advent-of-code-2023\\advent-of-code\\Day 2\\input-cube-conundrum.txt");
                line = sr.ReadLine();
                while (line != null)
                {
                    int id = LineFormatter.FindId(line);
                    string[] gamesText = LineFormatter.FindGames(line);
                    Console.WriteLine($"Id: {id}");

                    int redPower = 0;
                    int greenPower = 0;
                    int bluePower = 0;

                    foreach (string text in gamesText)
                    {
                        Console.WriteLine($"Games: {text}");
                        int red = LineFormatter.FindValue(text, "red");
                        int green = LineFormatter.FindValue(text, "green");
                        int blue = LineFormatter.FindValue(text, "blue");

                        if (red > redPower)
                            redPower = red;
                        if (green > greenPower)
                            greenPower = green;
                        if (blue > bluePower)
                            bluePower = blue;
                    }

                    sum += redPower * greenPower * bluePower;

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
