

namespace advent_of_code.Day_6
{
    public class ToyBoatRace(Dictionary<int, int> races)
    {
        private readonly Dictionary<int, int> races = races;

        public int DetermineBeatingTheRecord()
        {
            int result = 0;
            
            foreach (var race in races)
            {
                int waysToBeatTheRecord = DetermineNumberOfWaysYouCanBeatTheRecord(race.Key, race.Value);
                if(result == 0) result = waysToBeatTheRecord;
                else result *= waysToBeatTheRecord;
            }

            return result;
        }

        private int DetermineNumberOfWaysYouCanBeatTheRecord(int timing, int bestDistanceEverRecorded)
        {
            int result = 0;
            for (int i = 0; i < timing; i++)
            {
                int speed = i;
                int timeLeft = timing - i;

                int distance = speed * timeLeft;

                if (distance > bestDistanceEverRecorded) result++;
            }
            return result;
        }
    }
}
