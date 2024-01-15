namespace advent_of_code.Day_8
{
    public class Navigation(char[] instructions, Dictionary<string, Node> nodes)
    {
        private char[] Instructions { get; set; } = instructions;
        private Dictionary<string, Node> Nodes { get; } = nodes;

        public int FindSteps()
        {
            int steps = 0;
            string element = "AAA";

            while (element != "ZZZ")
            {
                for (int i = 0; i < Instructions.Length; i++)
                {
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

        public long FindGhostSteps()
        {
            Dictionary<string, Node> startNodes = Nodes.Where(node => node.Key[2] == 'A').ToDictionary();
            List<long> denominators = [];

            foreach (Node node in startNodes.Values)
            {
                int steps = 0;
                string element = node.Element;

                while (element[2] != 'Z')
                {
                    for (int i = 0; i < Instructions.Length; i++)
                    {
                        steps++;
                        char instruction = Instructions[i];
                        Node currentNode = Nodes[element];

                        if (instruction == 'L')
                            element = currentNode.Left;
                        else
                            element = currentNode.Right;
                    }
                }

                denominators.Add(steps);
            }

            return denominators.Aggregate(Lcm);

        }

        long Lcm(long a, long b) => a * b / Gcd(a, b);
        long Gcd(long a, long b) => b == 0 ? a : Gcd(b, a % b);


    }
}
