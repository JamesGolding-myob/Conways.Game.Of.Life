
using Xunit;
using System.Collections.Generic;
using System;
namespace Conways.Game.Of.Life.Tests
{
    public class GridTests
    {
        Grid twoByTwo = new Grid(2, 2);
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
        public void NewlyCreated3x3GridCanBeFormattedReadyToBeDisplayed()
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
            Grid fiveByfive = new Grid(5, 5);
            var input = new List<Tuple<int, int>>
            {
                Tuple.Create(0, 0),
                Tuple.Create(2, 2),
                Tuple.Create(4, 1),
                Tuple.Create(0, 4),
                Tuple.Create(1, 0),
                Tuple.Create(3, 3)
            };

            fiveByfive.SetInitialGridState(input);

            Assert.True(ManyCellsAlive(fiveByfive, input));
        }

        [Fact]
        public void SingleLiveCellIn2x2GridDiesDueToLackOfNeighbours()
        {  
            var input = new List<Tuple<int, int>>
            {
                Tuple.Create(0, 0)
            };

            twoByTwo.SetInitialGridState(input);
            var dyingCells = twoByTwo.ApplyRules();
            twoByTwo.UpdateGeneration(dyingCells);

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
            var dyingCells = twoByTwo.ApplyRules();
            twoByTwo.UpdateGeneration(dyingCells);

            Assert.True(twoByTwo.CurrentGeneration[cellIndexes[0], cellIndexes[1]].IsAlive);
            Assert.True(twoByTwo.CurrentGeneration[cellIndexes[2], cellIndexes[3]].IsAlive);
        }

        [Theory]
        [InlineData(3,3)]
        [InlineData(4,5)]
        [InlineData(6,10)]
        [InlineData(8,7)]
        [InlineData(100,100)]
        public void CellInAGridWithOneNeighbourDiesDueToNotEnoughNeighbours(int rows, int columns)
        {
            Grid genericGrid = new Grid(rows, columns);
            var input = new List<Tuple<int, int>>
            {
                Tuple.Create(0, 0),
                Tuple.Create(0, 1)
            };

            genericGrid.SetInitialGridState(input);
            var dyingCells = genericGrid.ApplyRules();
            genericGrid.UpdateGeneration(dyingCells);

            Assert.False(genericGrid.CurrentGeneration[0, 0].IsAlive);
            Assert.False(genericGrid.CurrentGeneration[0, 1].IsAlive);
        }


        public bool CheckEachLocationIsACell(Grid grid)
        {
            bool result = false;
            foreach (var item in grid.CurrentGeneration)
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

        private bool ManyCellsAlive(Grid grid, List<Tuple<int, int>> inputs)
        {
            bool result = false;

            foreach (var item in inputs)
            {
                result = grid.CurrentGeneration[item.Item1, item.Item2].IsAlive;
            }
            return result;
        }
        
    }
}
