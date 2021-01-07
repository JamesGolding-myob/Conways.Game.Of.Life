
using Xunit;
using System.Collections.Generic;
using System;
namespace Conways.Game.Of.Life.Tests
{
    public class GridTests
    {
        Grid twoByTwo = new Grid(2, 2);

        [Fact]
        public void GridCanSetSingleCellToInitiallyAlive()
        {
            Grid singleCellGrid = new Grid(1, 1);
            var input = new List<Tuple<int,int>>
            {
                Tuple.Create(0,0)
            };
            singleCellGrid.SetInitialGridState(input);

            Assert.True(singleCellGrid.CurrentGeneration[0, 0].IsAlive);
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
            var input = new List<Tuple<int, int>>
           {
              Tuple.Create(locationRow, locationColumn)
           };

            threeByThree.SetInitialGridState(input);

            Assert.True(threeByThree.CurrentGeneration[locationRow, locationColumn].IsAlive);
        }

        [Fact]
        public void CanSetMultipleCellsInAGridAlive()
        {
            Grid fiveByFive = new Grid(5, 5);
            var input = new List<Tuple<int, int>>
            {
                Tuple.Create(0, 0),
                Tuple.Create(2, 2),
                Tuple.Create(4, 1),
                Tuple.Create(0, 4),
                Tuple.Create(1, 0),
                Tuple.Create(3, 3)
            };

            fiveByFive.SetInitialGridState(input);

            Assert.Equal(6, ManyCellsSetToAlive(fiveByFive));
        }

        [Fact]
        public void SingleLiveCellIn2x2GridDiesDueToLackOfNeighbours()
        {  
            var input = new List<Tuple<int, int>>
            {
                Tuple.Create(0, 0)
            };

            twoByTwo.SetInitialGridState(input);
            twoByTwo.ApplyRulesToGrid();

            Assert.False(twoByTwo.CurrentGeneration[0, 0].IsAlive);
        }

        [Theory]
        [InlineData(new int[]{0, 0, 1, 0})]
        [InlineData(new int[]{0, 0, 0, 1})]
        [InlineData(new int[]{0, 0, 1, 1})]
        [InlineData(new int[]{1, 0, 0, 1})]
        public void TwoCellsInA2x2GridSurviveDueToHavingTwoOrMoreNeighbours(int[] cellIndexes)
        {
            var input = new List<Tuple<int, int>>
            {
                Tuple.Create(cellIndexes[0], cellIndexes[1]),
                Tuple.Create(cellIndexes[2], cellIndexes[3])
            };

            twoByTwo.SetInitialGridState(input);
            twoByTwo.ApplyRulesToGrid();  

            Assert.True(twoByTwo.CurrentGeneration[cellIndexes[0], cellIndexes[1]].IsAlive);
            Assert.True(twoByTwo.CurrentGeneration[cellIndexes[2], cellIndexes[3]].IsAlive);
        }

        [Theory]
        [InlineData(3, 3, 0, 0)]
        [InlineData(4, 5, 1, 0)]
        [InlineData(6, 10, 1, 1)]
        [InlineData(8, 7, 1, 2)]
        [InlineData(100, 100, 0, 2)]
        public void CellInAGridWithOneNeighbourDiesDueToNotEnoughNeighbours(int rows, int columns, int neighbourRow, int neighbourColumn)
        {
            Grid genericGrid = new Grid(rows, columns);
            var input = new List<Tuple<int, int>>
            {
                Tuple.Create(neighbourRow, neighbourColumn),
                Tuple.Create(0, 1)
            };

            genericGrid.SetInitialGridState(input);
            genericGrid.ApplyRulesToGrid();

            Assert.False(genericGrid.CurrentGeneration[neighbourRow, neighbourColumn].IsAlive);
            Assert.False(genericGrid.CurrentGeneration[0, 1].IsAlive);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(2)]
        public void AFullRowOfLiveCellsSurvivesDueToHorizontalWrappingOfNeighbours(int row)
        {
            Grid threeByThree = new Grid(3,3);
            var input = new List<Tuple<int, int>>
            {
                Tuple.Create(row, 0),
                Tuple.Create(row, 1),
                Tuple.Create(row, 2)
            };

            threeByThree.SetInitialGridState(input);
            threeByThree.ApplyRulesToGrid();

            Assert.True(CellsAreAliveAfterTick(input, threeByThree));
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void AFullColumnOfLiveCellsSurvivesDueToVerticalWrappingOfNeighbours(int column)
        {
            Grid fourByFour = new Grid(4, 4);
            var input = new List<Tuple<int, int>>
            {
                Tuple.Create(column, 0),
                Tuple.Create(column, 1),
                Tuple.Create(column, 2),
                Tuple.Create(column, 3)
            };

            fourByFour.SetInitialGridState(input);
            fourByFour.ApplyRulesToGrid();

            Assert.True(CellsAreAliveAfterTick(input, fourByFour));
        }

        [Fact]
        public void ADeadCellWithThreeLiveNeighboursBecomesAlive()
        {
            Grid threeByFour = new Grid(3, 4);
            var input = new List<Tuple<int, int>>
            {
                Tuple.Create(2,1),
                Tuple.Create(1, 0),
                Tuple.Create(1, 2)
            };

            threeByFour.SetInitialGridState(input);
            threeByFour.ApplyRulesToGrid();

            Assert.True(threeByFour.CurrentGeneration[1,1].IsAlive);
            Assert.True(threeByFour.CurrentGeneration[2,1].IsAlive);
        }

        private int ManyCellsSetToAlive(Grid grid)
        {
            int result = 0;

            foreach (var cell in grid.CurrentGeneration)
            {
                if(cell.IsAlive)
                {
                    result += 1;
                }
            }
            return result;
        }

        private bool CellsAreAliveAfterTick(List<Tuple<int, int>> cellsUnderTest, Grid gridUnderTest)
        {
            bool result = false;
            for(int i = 0; i < cellsUnderTest.Count; i++)
            {
                result = gridUnderTest.CurrentGeneration[cellsUnderTest[i].Item1, cellsUnderTest[i].Item2].IsAlive;
                if(result == false)
                {
                    break;
                }
            }
            return result;
        }
        
    }
}
