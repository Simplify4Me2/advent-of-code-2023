namespace advent_of_code.Day_2
{
    public class Game(int red, int green, int blue)
    {
        private const int AvailableRedCubes = 12;
        private const int AvailableGreenCubes = 13;
        private const int AvailableBlueCubes = 14;
        private int Red { get; } = red;
        private int Green { get; } = green;
        private int Blue { get; } = blue;

        public bool IsPossible => CheckPossibility();

        private bool CheckPossibility() 
        { 
            if(Red > AvailableRedCubes) return false;
            if(Green > AvailableGreenCubes) return false;
            if(Blue > AvailableBlueCubes) return false;

            return true; 
        }
    }
}
