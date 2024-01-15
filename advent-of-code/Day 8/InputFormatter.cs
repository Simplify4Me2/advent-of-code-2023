namespace advent_of_code.Day_8
{
    public class InputFormatter(string[] text)
    {
        public char[] GetInstructions()
        {
            var firstLine = text[0];

            return firstLine.ToCharArray();
        }

        public Dictionary<string, Node> GetNodes()
        {
            Dictionary<string, Node> nodes = [];

            for (int i = 2; i < text.Length; i++)
            {
                string element = text[i][..3];
                string left = text[i].Substring(7, 3);
                string right = text[i].Substring(12, 3);
                nodes.Add(element, new Node(element, left, right));
            }

            return nodes;
        }
    }

    public class Node(string element, string left, string right)
    {
        public string Element { get; set; } = element;
        public string Left { get; set; } = left;
        public string Right { get; set; } = right;
    }
}
