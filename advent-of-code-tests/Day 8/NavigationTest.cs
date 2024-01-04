using advent_of_code.Day_8;

namespace advent_of_code_tests.Day_8
{
    public class NavigationTest
    {
        [Fact]
        public void FindNumberOfSteps_RightLeft()
        {
            char[] instructions = ['R', 'L'];

            Dictionary<string, Node> nodes = new()
            {
                { "AAA", new("AAA", "BBB", "CCC") },
                { "BBB", new("BBB", "DDD", "EEE") },
                { "CCC", new("CCC", "ZZZ", "GGG") },
                { "DDD", new("DDD", "DDD", "DDD") },
                { "EEE", new("EEE", "EEE", "EEE") },
                { "GGG", new("GGG", "GGG", "GGG") },
                { "ZZZ", new("ZZZ", "ZZZ", "ZZZ") }
            };

            Navigation navigation = new(instructions, nodes);

            Assert.Equal(2, navigation.FindNumberOfSteps());
        }

        [Fact]
        public void FindNumberOfSteps_LeftLeftRight()
        {
            char[] instructions = ['L', 'L', 'R'];
            
            Dictionary<string, Node> nodes = new()
            {
                { "AAA", new("AAA", "BBB", "BBB") },
                { "BBB", new("BBB", "AAA", "ZZZ") },
                { "ZZZ", new("ZZZ", "ZZZ", "ZZZ") }
            };

            Navigation navigation = new(instructions, nodes);

            Assert.Equal(6, navigation.FindNumberOfSteps());
        }
    }
}
