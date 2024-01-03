using advent_of_code.Day_8;

namespace advent_of_code_tests.Day_8
{
    public class NavigationTest
    {
        [Fact]
        public void FindNumberOfSteps_RightLeft()
        {
            char[] instructions = ['R', 'L'];
            Node[] nodes = 
                [
                    new("AAA", "BBB", "CCC"),
                    new("BBB", "DDD", "EEE"),
                    new("CCC", "ZZZ", "GGG"),
                    new("DDD", "DDD", "DDD"),
                    new("EEE", "EEE", "EEE"),
                    new("GGG", "GGG", "GGG"),
                    new("ZZZ", "ZZZ", "ZZZ")

                ];

            Navigation navigation = new(instructions, nodes);

            Assert.Equal(2, navigation.FindNumberOfSteps());
        }

        [Fact]
        public void FindNumberOfSteps_LeftLeftRight()
        {
            char[] instructions = ['L', 'L', 'R'];
            Node[] nodes = 
                [
                    new("AAA", "BBB", "BBB"),
                    new("BBB", "AAA", "ZZZ"),
                    new("ZZZ", "ZZZ", "ZZZ")
                ];

            Navigation navigation = new(instructions, nodes);

            Assert.Equal(2, navigation.FindNumberOfSteps());
        }
    }
}
