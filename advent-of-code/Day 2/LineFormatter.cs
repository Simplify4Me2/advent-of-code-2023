namespace advent_of_code.Day_2
{
    public static class LineFormatter
    {
        public static int FindId(string line)
        {
            string[] splitText = line.Split(":");

            string textContainingId = splitText.First();
            if (int.TryParse(textContainingId.AsSpan(5, textContainingId.Length - 5), out int id))
                return id;

            return 0;
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
                    if (int.TryParse(newText, out int value)) return value;
                }
            }

            return 0;
        }
    }
}
