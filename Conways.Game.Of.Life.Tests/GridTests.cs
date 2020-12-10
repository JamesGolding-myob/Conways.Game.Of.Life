using System;
using Xunit;
using Conways.Game.Of.Life;

namespace Conways.Game.Of.Life.Tests
{
    public class GridTests
    {
        DisplayFormatter displayFormatter = new DisplayFormatter();

        [Theory]
        [InlineData(3, 3)]
        [InlineData(1, 1)]
        [InlineData(3, 2)]
        [InlineData(10, 20)]
        public void CanCreateAGridOfCellsAnySizeGreaterThanZero(int columns, int rows)
        {
            Grid grid = new Grid(columns, rows);

            Assert.True(CheckEachLocationIsACell(grid));
        }

        [Fact]
        public void NewlyCreatedGridCanBeDisplayedToUser()
        {
            Grid grid = new Grid(3, 3);
            var expectedOutput = " . " + " . " + " . \n" +
                                 " . " + " . " + " . \n" +
                                 " . " + " . " + " . \n" ;

            Assert.Equal(expectedOutput, displayFormatter.GridToString(grid));
        }
        public bool CheckEachLocationIsACell(Grid grid)
        {
            bool result = false;
            foreach (var item in grid.Board)
            {
                if(item is Cell)
                {
                    result = true;
                }
                else
                {
                    result = false;
                }
            }
            return result;
        }
        
    }
}
