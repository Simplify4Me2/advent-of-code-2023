using advent_of_code.Day_6;

namespace advent_of_code
{
    public static class WaitForIt_PartTwo
    {
        public static void Run()
        {

            var result = ToyBoatRace.DetermineNumberOfWaysYouCanBeatTheRecord(56977793, 499221010971440);

            Console.WriteLine($"Result: {result}");
            Console.ReadLine();
        }
    }
}
