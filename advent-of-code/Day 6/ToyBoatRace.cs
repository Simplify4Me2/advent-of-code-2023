

namespace advent_of_code.Day_6
{
    public class ToyBoatRace(Dictionary<int, int> races)
    {
        private readonly Dictionary<int, int> races = races;

        public long DetermineBeatingTheRecord()
        {
            long result = 0;
            
            foreach (var race in races)
            {
                long waysToBeatTheRecord = DetermineNumberOfWaysYouCanBeatTheRecord(race.Key, race.Value);
                if(result == 0) result = waysToBeatTheRecord;
                else result *= waysToBeatTheRecord;
            }

            return result;
        }

        public static long DetermineNumberOfWaysYouCanBeatTheRecord(long timing, long bestDistanceEverRecorded)
        {
            long result = 0;
            for (long i = 0; i < timing; i++)
            {
                long speed = i;
                long timeLeft = timing - i;

                long distance = speed * timeLeft;

                if (distance > bestDistanceEverRecorded) result++;
            }
            return result;
        }
    }
}
