using static advent_of_code.Day_3.EngineSchematic;

namespace advent_of_code_tests.Day_3
{
    public class NumberTest
    {
        [Fact]
        public void IsAdjacentToASymbol_PreviousLineHasSymbolBeforeNumber_NotAdjacent_ReturnsFalse()
        {
            var number = new Number(633, new(6,2));
            Assert.False(number.IsAdjacentToASymbol("...*......", "..35..633.", string.Empty));
        }

        [Fact]
        public void IsAdjacentToASymbol_PreviousLineHasSymbolAfterNumber_NotAdjacent_ReturnsFalse()
        {
            var number = new Number(35, new(2, 2));
            Assert.False(number.IsAdjacentToASymbol("......#...", "..35..633.", string.Empty));
        }

        [Fact]
        public void IsAdjacentToASymbol_PreviousLineHasNoSymbols_NotAdjacent_ReturnsFalse()
        {
            var number = new Number(633, new(6, 2));
            Assert.False(number.IsAdjacentToASymbol("..........", "..35..633.", string.Empty));
        }

        [Fact]
        public void IsAdjacentToASymbol_PreviousLineHasSymbols_Adjacent_ReturnsTrue()
        {
            var number = new Number(35, new(3, 2));
            Assert.True(number.IsAdjacentToASymbol("...*......", "..35..633.", string.Empty));
        }

        [Fact]
        public void IsAdjacentToASymbol_NextLineHasSymbolBeforeNumber_NotAdjacent_ReturnsFalse()
        {
            var number = new Number(633, new(6, 2));
            Assert.False(number.IsAdjacentToASymbol(string.Empty, "..35..633.", "...*......"));
        }

        [Fact]
        public void IsAdjacentToASymbol_NextLineHasSymbolAfterNumber_NotAdjacent_ReturnsFalse()
        {
            var number = new Number(35, new(2, 2));
            Assert.False(number.IsAdjacentToASymbol(string.Empty, "..35..633.", "......#..."));
        }

        [Fact]
        public void IsAdjacentToASymbol_NextLineHasNoSymbols_NotAdjacent_ReturnsFalse()
        {
            var number = new Number(633, new(6, 2));
            Assert.False(number.IsAdjacentToASymbol(string.Empty, "..35..633.", ".........."));
        }

        [Fact]
        public void IsAdjacentToASymbol_NextLineHasSymbols_Adjacent_ReturnsTrue()
        {
            var number = new Number(35, new(3, 2));
            Assert.True(number.IsAdjacentToASymbol(string.Empty, "..35..633.", "...*......"));
        }

        [Fact]
        public void IsAdjacentToASymbol_CurrentLineHasSymbolsBefore_Adjacent_ReturnsTrue()
        {
            var number = new Number(35, new(3, 2));
            Assert.True(number.IsAdjacentToASymbol(string.Empty, ".*35..633.", string.Empty));
        }

        [Fact]
        public void IsAdjacentToASymbol_CurrentLineHasSymbolsNext_Adjacent_ReturnsTrue()
        {
            var number = new Number(35, new(3, 2));
            Assert.True(number.IsAdjacentToASymbol(string.Empty, "..35*.633.", string.Empty));
        }

        [Fact]
        public void IsAdjacentToASymbol_CurrentLineHasSymbols_NotAdjacent_ReturnsFalse()
        {
            var number = new Number(35, new(3, 2));
            Assert.False(number.IsAdjacentToASymbol(string.Empty, "..35.*633.", string.Empty));
        }

        [Fact]
        public void IsAdjacentToASymbol_CurrentLineHasNoSymbols_ReturnsFalse()
        {
            var number = new Number(35, new(3, 2));
            Assert.False(number.IsAdjacentToASymbol(string.Empty, "..35..633.", string.Empty));
        }
    }
}
