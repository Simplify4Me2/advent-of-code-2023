namespace advent_of_code.Day_8
{
    public class Navigation(char[] instructions, Node[] nodes)
    {
        private char[] Instructions { get; set; } = instructions;
        private Node[] Nodes { get; set; } = nodes;

        public int FindNumberOfSteps()
        {
            int steps = 0;
            string element = Nodes[0].Element;

            while (element != Nodes.Last().Element)
            {
                for (int i = 0; i < Instructions.Length; i++)
                {
                    if (element == Nodes.Last().Element) continue;

                    steps++;
                    char instruction = Instructions[i];
                    Node node = Nodes.First(node => node.Element == element);

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
