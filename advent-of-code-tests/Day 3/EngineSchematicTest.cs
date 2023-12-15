﻿using advent_of_code.Day_3;

namespace advent_of_code_tests.Day_3
{
    public class EngineSchematicTest
    {
        private readonly char[,] SampleGrid = new char[,]
        {
            { '4', '6', '7', '.', '.', '1', '1', '4', '.', '.'},
            { '.', '.', '.', '*', '.', '.', '.', '.', '.', '.'},
            { '.', '.', '3', '5', '.', '.', '6', '3', '3', '.'},
            { '.', '.', '.', '.', '.', '.', '#', '.', '.', '.'},
            { '6', '1', '7', '*', '.', '.', '.', '.', '.', '.'},
            { '.', '.', '.', '.', '.', '+', '.', '5', '8', '.'},
            { '.', '.', '5', '9', '2', '.', '.', '.', '.', '.'},
            { '.', '.', '.', '.', '.', '.', '7', '5', '5', '.'},
            { '.', '.', '.', '$', '.', '*', '.', '.', '.', '.'},
            { '.', '6', '6', '4', '.', '5', '9', '8', '.', '.'},
        };

        private readonly List<string> Sample =
        [
            "467..114..",
            "...*......",
            "..35..633.",
            "......#...",
            "617*......",
            ".....+.58.",
            "..592.....",
            "......755.",
            "...$.*....",
            ".664.598.."
        ];

        [Fact]
        public void Sum_ReturnsTotalOfAllNumbers()
        {
            EngineSchematic engineSchematic = new(Sample);

            Assert.Equal(4361, engineSchematic.Sum);

            //Assert.True(false);
        }
    }
}
