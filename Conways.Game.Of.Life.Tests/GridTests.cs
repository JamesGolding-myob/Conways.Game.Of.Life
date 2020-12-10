using System;
using Xunit;
using Conways.Game.Of.Life;

namespace Conways.Game.Of.Life.Tests
{
    public class GridTests
    {

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
        // [Fact]
        // public void PlayerSetsTheGridSizeAtBeginingOfTheGame()
        // {
        //     UI ui = new UI();
        //     GOL game = new GOL(ui);
        //     Grid grid = new Grid();

        // }
    }
}
