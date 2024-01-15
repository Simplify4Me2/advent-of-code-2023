using advent_of_code.Day_8;

namespace advent_of_code_tests.Day_8
{
    public class NavigationTest
    {
        [Fact]
        public void FindSteps_RightLeft()
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

            Assert.Equal(2, navigation.FindSteps());
        }

        [Fact]
        public void FindSteps_LeftLeftRight()
        {
            char[] instructions = ['L', 'L', 'R'];
            
            Dictionary<string, Node> nodes = new()
            {
                { "AAA", new("AAA", "BBB", "BBB") },
                { "BBB", new("BBB", "AAA", "ZZZ") },
                { "ZZZ", new("ZZZ", "ZZZ", "ZZZ") }
            };

            Navigation navigation = new(instructions, nodes);

            Assert.Equal(6, navigation.FindSteps());
        }

        [Fact]
        public void FindGhostSteps_LeftRight()
        {
            char[] instructions = ['L', 'R'];

            Dictionary<string, Node> nodes = new()
            {
                { "11A", new("11A", "11B", "XXX") },
                { "11B", new("11B", "XXX", "11Z") },
                { "11Z", new("11Z", "11B", "XXX") },
                { "22A", new("22A", "22B", "XXX") },
                { "22B", new("22B", "22C", "22C") },
                { "22C", new("22C", "22Z", "22Z") },
                { "22Z", new("22Z", "22B", "22B") },
                { "XXX", new("XXX", "XXX", "XXX") }
            };

            Navigation navigation = new(instructions, nodes);

            Assert.Equal(6, navigation.FindGhostSteps());
        }
    }
}
