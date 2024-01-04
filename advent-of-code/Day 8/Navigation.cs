namespace advent_of_code.Day_8
{
    public class Navigation(char[] instructions, Dictionary<string, Node> nodes)
    {
        private char[] Instructions { get; set; } = instructions;
        private Dictionary<string, Node> Nodes { get; } = nodes;

        public int FindNumberOfSteps()
        {
            int steps = 0;
            string element = "AAA";

            while (element != "ZZZ")
            {
                for (int i = 0; i < Instructions.Length; i++)
                {
                    //if (element == Nodes.Last().Key) continue;

                    steps++;
                    char instruction = Instructions[i];
                    Node node = Nodes[element];

                    if (instruction == 'L')
                        element = node.Left;
                    else 
                        element = node.Right;
                }
            }

            return steps;
        }
    }
}
