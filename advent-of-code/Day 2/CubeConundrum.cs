namespace advent_of_code
{
    public static class CubeConundrum
    {
        public static void Run()
        {
            string line;
            try
            {
                StreamReader sr = new("D:\\Git\\advent-of-code-2023\\advent-of-code\\Day 2\\sample-cube-conundrum.txt");
                line = sr.ReadLine();
                while (line != null)
                {
                    Console.WriteLine(line);



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
