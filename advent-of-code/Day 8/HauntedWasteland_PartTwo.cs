using advent_of_code.Day_8;

namespace advent_of_code
{
    public static class HauntedWasteland_PartTwo
    {
        public static void Run()
        {
            string line;
            List<string> text = [];

            try
            {
                StreamReader sr = new("D:\\Git\\advent-of-code-2023\\advent-of-code\\Day 8\\input-haunted-wasteland.txt");
                line = sr.ReadLine();

                while (line != null)
                {
                    text.Add(line);
                    line = sr.ReadLine();
                }

                sr.Close();

                InputFormatter formatter = new([.. text]);

                char[] instructions = formatter.GetInstructions();
                Dictionary<string, Node> nodes = formatter.GetNodes();

                Navigation navigation = new(instructions, nodes);

                Console.WriteLine($"Total ghost steps: {navigation.FindGhostSteps()}");
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
