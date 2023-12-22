namespace advent_of_code.Day_4
{
    public class LineFormatter
    {
        public List<int> WinningNumbers { get; } = [];
        public List<int> NumbersYouHave { get; } = [];

        public LineFormatter(string line)
        {
            string[] strings = line.Split('|');
            string[] winningNumbersText = strings.First().Split(' ');
            string[] yourNumbersText = strings.Last().Split(' ');

            foreach (string numberText in winningNumbersText)
            {
                if (int.TryParse(numberText, out int value))
                    WinningNumbers.Add(value);
            }

            foreach (string numberText in yourNumbersText)
            {
                if (int.TryParse(numberText, out int value))
                    NumbersYouHave.Add(value);
            }
        }

    }
}
