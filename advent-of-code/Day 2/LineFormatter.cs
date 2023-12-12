namespace advent_of_code.Day_2
{
    public static class LineFormatter
    {
        public static int FindId(string line)
        {
            string[] splitText = line.Split(":");

            string textContainingId = splitText.First();
            int.TryParse(textContainingId.Substring(5, textContainingId.Length - 5), out int id);

            return id;
        }

        public static string[] FindGames(string line)
        {
            string[] splitText = line.Split(":");

            string textContainingGames = splitText.Last();

            return textContainingGames.Split(";");
        }

        public static int FindValue(string gameText, string colorText)
        {
            string[] foo = gameText.Split(",");

            foreach (string text in foo) 
            {
                if (text.Contains(colorText))
                {
                    string newText = text.TrimEnd(colorText.ToCharArray()).Trim();
                    int.TryParse(newText, out int value);
                    return value;
                }
            }

            return 0;
        }

        public static int FindGreenValue(string gameText)
        {
            return 1;
        }

        public static int FindBlueValue(string gameText)
        {
            return 1;
        }
    }
}
