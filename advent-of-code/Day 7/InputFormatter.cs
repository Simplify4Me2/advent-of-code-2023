namespace advent_of_code.Day_7
{
    public class InputFormatter(string[] text)
    {
        public Hand[] Hands => FindHands();

        private Hand[] FindHands() 
        {
            List<Hand> hands = [];
            
            for (int i = 0; i < text.Length; i++)
            {
                string line = text[i];

                List<char> cards = [];
                for (int j = 0; j < 5; j++)
                {
                    cards.Add(line[j]);
                };

                int startIndex = 5;
                string bidText = line.Substring(startIndex, line.Length - startIndex).Trim();
                int.TryParse(bidText, out int bid);

                hands.Add(new([.. cards], bid));
            }

            return [.. hands];
        }
    }
}
