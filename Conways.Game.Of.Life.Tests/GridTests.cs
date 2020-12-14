
using Xunit;
using System.Collections.Generic;

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
        public void NewlyCreated3x3GridCanBeDisplayedToUser()
        {
            Grid grid = new Grid(3, 3);
            var expectedOutput = " . " + " . " + " . \n" +
                                 " . " + " . " + " . \n" +
                                 " . " + " . " + " . \n" ;

            Assert.Equal(expectedOutput, displayFormatter.GridToString(grid));
        }

        [Fact]
        public void GridCanSetSingleCellToInitiallyAlive()
        {
            Grid singleCellGrid = new Grid(1, 1);
            var input = new List<(int,int)>
            {
                (0,0)
            };
            singleCellGrid.SetInitialGridState(input);

            Assert.True(singleCellGrid.Board[0, 0].IsAlive);
        }

        [Theory]
        [InlineData(2,2)]
        [InlineData(2,1)]
        [InlineData(2,0)]
        [InlineData(1,2)]
        [InlineData(1,1)]
        [InlineData(1,0)]
        [InlineData(0,2)]
        [InlineData(0,1)]
        [InlineData(0,0)]
        public void CanSetAnyCellInsideTheGridToAlive(int locationRow, int locationColumn)
        {
            Grid threeByThree = new Grid(3,3);
            var input = new List<(int, int)>
           {
              (locationRow, locationColumn)
           };

            threeByThree.SetInitialGridState(input);

            Assert.True(threeByThree.Board[locationRow, locationColumn].IsAlive);
        }

        [Fact]
        public void CanSetMultipleCellsInAGridAlive()
        {
            Grid fiveByfive = new Grid(5, 5);
            var input = new List<(int, int)>
            {
                (0, 0),
                (2, 2),
                (4, 1),
                (0, 4),
                (1, 0),
                (3, 3)
            };

            fiveByfive.SetInitialGridState(input);

            Assert.True(ManyCellsAlive(fiveByfive, input));
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
                    break;
                }
            }
            return result;
        }

        private bool ManyCellsAlive(Grid grid, List<(int, int)> inputs)
        {
            bool result = false;

            foreach (var item in inputs)
            {
                result = grid.Board[item.Item1, item.Item2].IsAlive;
            }
            return result;
        }
        
    }
}
