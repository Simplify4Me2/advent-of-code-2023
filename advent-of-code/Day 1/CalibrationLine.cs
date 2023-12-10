namespace advent_of_code.Day_1
{
    public class CalibrationLine(string input)
    {
        private readonly string _input = input;
        private static readonly Dictionary<string, int> SpelledOutLetters = new()
        {
            { "one", 1 },
            { "two", 2 },
            { "three", 3 },
            { "four", 4 },
            { "five", 5 },
            { "six", 6 },
            { "seven", 7 },
            { "eight", 8 },
            { "nine", 9 }
        };

        public int Value => GetCalibrationValue();

        private KeyValuePair<int, int>? FirstNumberOrDefault()
        {
            for (int i = 0; i < _input.Length; i++)
            {
                if (int.TryParse(_input[i].ToString(), out int number)) return new(i, number);
            }

            return null;
        }

        private KeyValuePair<int, int>? LastNumberOrDefault()
        {
            KeyValuePair<int, int>? result = null;
            for (int i = 0; i < _input.Length; i++)
            {
                if (int.TryParse(_input[i].ToString(), out int number)) result = new(i, number);
            }

            return result;
        }

        private KeyValuePair<int, string>? FirstSpelledOutWordOrDefault()
        {
            //KeyValuePair<int, int>? result = null;
            //for (int i = 0; i < _input.Length; i++)
            //{
            //    if (int.TryParse(_input[i].ToString(), out int number)) result = new(i, number);
            //}


            int? index = null;
            string result = string.Empty;

            foreach (var word in SpelledOutLetters.Keys)
            {
                if (_input.Contains(word))
                {
                    int firstLetterIndex = _input.IndexOf(word);
                    if (index == null || firstLetterIndex < index)
                    {
                        index = firstLetterIndex;
                        result = _input.Substring(firstLetterIndex, word.Length);
                    }
                }
            }

            if (index != null && result != string.Empty) return new(index.Value, result);

            return null;
        }

        private KeyValuePair<int, string>? LastSpelledOutWordOrDefault()
        {
            int? index = null;
            string result = string.Empty;

            foreach (var word in SpelledOutLetters.Keys)
            {
                if (_input.Contains(word))
                {
                    int firstLetterIndex = _input.LastIndexOf(word);
                    if (index == null || firstLetterIndex > index)
                    {
                        index = firstLetterIndex;
                        result = _input.Substring(firstLetterIndex, word.Length);
                    }
                }
            }

            if (index != null && result != string.Empty) return new(index.Value, result);

            return null;
        }

        private int GetCalibrationValue()
        {
            int firstValue;
            int lastValue;

            KeyValuePair<int, int>? firstNumber = FirstNumberOrDefault();
            KeyValuePair<int, int>? lastNumber = LastNumberOrDefault();
            KeyValuePair<int, string>? firstSpelledOutWord = FirstSpelledOutWordOrDefault();
            KeyValuePair<int, string>? lastSpelledOutWord = LastSpelledOutWordOrDefault();

            if (!firstNumber.HasValue && !lastNumber.HasValue) return (SpelledOutLetters[firstSpelledOutWord.Value.Value] * 10) + SpelledOutLetters[lastSpelledOutWord.Value.Value];
            if (!firstSpelledOutWord.HasValue && !lastSpelledOutWord.HasValue) return (firstNumber!.Value.Value * 10) + lastNumber!.Value.Value;

            //int firstNumberIndex = _input.IndexOf(firstNumber.Value.ToString());
            //int lastNumberIndex = _input.IndexOf(lastNumber.Value.ToString());
            //int firstSpelledOutWordIndex = _input.IndexOf(firstSpelledOutWord);
            //int lastSpelledOutWordIndex = _input.IndexOf(lastSpelledOutWord);

            if (firstNumber.Value.Key < firstSpelledOutWord.Value.Key)
                firstValue = firstNumber.Value.Value;
            else
                firstValue = SpelledOutLetters[firstSpelledOutWord.Value.Value];

            if (lastNumber.Value.Key > lastSpelledOutWord.Value.Key)
                lastValue = lastNumber.Value.Value;
            else
                lastValue = SpelledOutLetters[lastSpelledOutWord.Value.Value];

            return (firstValue * 10) + lastValue;
        }
    }
}
