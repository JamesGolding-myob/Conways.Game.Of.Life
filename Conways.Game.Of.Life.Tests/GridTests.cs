
using Xunit;
using System.Collections.Generic;
namespace Conways.Game.Of.Life.Tests
{
    public class GridTests
    {
        Grid twoByTwo = new Grid(2, 2);

        [Fact]
        public void GridCanSetSingleCellToInitiallyAlive()
        {
            Grid singleCellGrid = new Grid(1, 1);
            var input = new List<Location>
            {
                new Location(0,0)
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
            var input = new List<Location>
           {
              new Location(locationRow, locationColumn)
           };

            threeByThree.SetInitialGridState(input);

            Assert.True(threeByThree.CurrentGeneration[locationRow, locationColumn].IsAlive);
        }

        [Fact]
        public void CanSetMultipleCellsInAGridAlive()
        {
            Grid fiveByFive = new Grid(5, 5);
            var input = new List<Location>
            {
                new Location(0, 0),
                new Location(2, 2),
                new Location(4, 1),
                new Location(0, 4),
                new Location(1, 0),
                new Location(3, 3)
            };

            fiveByFive.SetInitialGridState(input);

            Assert.Equal(6, ManyCellsSetToAlive(fiveByFive));
        }

        [Fact]
        public void SingleLiveCellIn2x2GridDiesDueToLackOfNeighbours()
        {  
            var input = new List<Location>
            {
                new Location(0, 0)
            };

            twoByTwo.SetInitialGridState(input);
            twoByTwo.ApplyRulesToGrid();

            Assert.False(twoByTwo.CurrentGeneration[0, 0].IsAlive);
        }

        [Theory]
        [InlineData(new int[]{0, 0, 1, 0})]
        [InlineData(new int[]{0, 0, 0, 1})]
        [InlineData(new int[]{0, 1, 1, 1})]
        [InlineData(new int[]{1, 0, 1, 1})]
        public void TwoCellsInA2x2GridSurviveDueToHavingTwoLiveNeighbours(int[] cellIndexes)
        {
            var input = new List<Location>
            {
                new Location(cellIndexes[0], cellIndexes[1]),
                new Location(cellIndexes[2], cellIndexes[3])
            };

            twoByTwo.SetInitialGridState(input);
            twoByTwo.ApplyRulesToGrid();  

            Assert.True(twoByTwo.CurrentGeneration[cellIndexes[0], cellIndexes[1]].IsAlive);
            Assert.True(twoByTwo.CurrentGeneration[cellIndexes[2], cellIndexes[3]].IsAlive);
        }

        [Theory]
        [InlineData(new int[]{0, 0, 1, 1})]
        [InlineData(new int[]{1, 0, 0, 1})]
        public void TwoLiveCellsDiagionallyOppositeIn2x2GridDieDueToOverPopulation(int[] cellLocationIndexes)
        {
            var input = new List<Location>
            {
                new Location(cellLocationIndexes[0], cellLocationIndexes[1]),
                new Location(cellLocationIndexes[2], cellLocationIndexes[3])
            };

            twoByTwo.SetInitialGridState(input);
            twoByTwo.ApplyRulesToGrid();  

            Assert.False(twoByTwo.CurrentGeneration[cellLocationIndexes[0], cellLocationIndexes[1]].IsAlive);
            Assert.False(twoByTwo.CurrentGeneration[cellLocationIndexes[2], cellLocationIndexes[3]].IsAlive);   
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
            var input = new List<Location>
            {
                new Location(neighbourRow, neighbourColumn),
                new Location(0, 1)
            };

            genericGrid.SetInitialGridState(input);
            genericGrid.ApplyRulesToGrid();

            Assert.False(genericGrid.CurrentGeneration[neighbourRow, neighbourColumn].IsAlive);
            Assert.False(genericGrid.CurrentGeneration[0, 1].IsAlive);
        }

        [Theory]
        [InlineData(0, 0, 0, 1, 0, 2)]
        [InlineData(0, 0, 1, 0, 2, 0)]
        [InlineData(3, 4, 4, 3, 5, 2)]
        [InlineData(5, 3, 4, 4, 5, 5)]
        public void CellWithTwoNeighboursLivesOn(int firstNeighbourRow, int firstNeighbourColumn, int cellOfInterestRow, int cellOfInterestColumn, int secondNeoighbourRow, int secondNeihbourColumn)
        {
            Grid sixBySix = new Grid(6,6);
            var input = new List<Location>
            {
                new Location(firstNeighbourRow, firstNeighbourColumn),
                new Location(cellOfInterestRow, cellOfInterestColumn),
                new Location(secondNeoighbourRow, secondNeihbourColumn),
            };
            sixBySix.SetInitialGridState(input);
            sixBySix.ApplyRulesToGrid();

            Assert.True(sixBySix.CurrentGeneration[cellOfInterestRow, cellOfInterestColumn].IsAlive);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(2)]
        public void AFullRowOfLiveCellsSurvivesDueToHorizontalWrappingOfNeighbours(int row)
        {
            Grid threeByThree = new Grid(3,3);
            var input = new List<Location>
            {
                new Location(row, 0),
                new Location(row, 1),
                new Location(row, 2)
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
            var input = new List<Location>
            {
                new Location(column, 0),
                new Location(column, 1),
                new Location(column, 2),
                new Location(column, 3)
            };

            fourByFour.SetInitialGridState(input);
            fourByFour.ApplyRulesToGrid();

            Assert.True(CellsAreAliveAfterTick(input, fourByFour));
        }

        [Theory]
        [InlineData()]
        public void ADeadCellWithThreeLiveNeighboursBecomesAlive()
        {
            Grid threeByFour = new Grid(3, 4);
            var input = new List<Location>
            {
                new Location(2, 1),
                new Location(1, 0),
                new Location(1, 2)
            };

            threeByFour.SetInitialGridState(input);
            threeByFour.ApplyRulesToGrid();

            Assert.True(threeByFour.CurrentGeneration[1,1].IsAlive);
            Assert.True(threeByFour.CurrentGeneration[2,1].IsAlive);
        }

        [Fact]
        public void ALiveCellWithMoreThenThreeLiveNeighboursBecomesDead()
        {
            Grid fourByFour = new Grid(8, 8);
            var input = new List<Location>
            {
                new Location(1,2),
                new Location(2,1),
                new Location(2,2),
                new Location(3,2),
                new Location(2,3)
            };
            fourByFour.SetInitialGridState(input);
            fourByFour.ApplyRulesToGrid();

            Assert.False(fourByFour.CurrentGeneration[2,2].IsAlive); 
        }

        [Fact]
        public void GridFullOfLiveCellsAllDieDueToOverpopulation()
        {
            Grid fourByfour = new Grid(4, 4); 
            var input = new List<Location>
            {
                new Location(0,0), new Location(0,1), new Location(0,2), new Location(0,3),
                new Location(1,0), new Location(1,1), new Location(1,2), new Location(1,3),
                new Location(2,0), new Location(2,1), new Location(2,2), new Location(2,3),
                new Location(3,0), new Location(3,1), new Location(3,2), new Location(3,3)
            };
            fourByfour.SetInitialGridState(input);
            fourByfour.ApplyRulesToGrid();

            Assert.True(CellsAreDeadAfterTick(fourByfour));
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

        private bool CellsAreAliveAfterTick(List<Location> cellsUnderTest, Grid gridUnderTest)
        {
            bool result = false;
            for(int i = 0; i < cellsUnderTest.Count; i++)
            {
                result = gridUnderTest.CurrentGeneration[cellsUnderTest[i].Row, cellsUnderTest[i].Column].IsAlive;
                if(result == false)
                {
                    break;
                }
            }
            return result;
        }

        private bool CellsAreDeadAfterTick(Grid gridUnderTest)
        {
            bool result = true;

            foreach(Cell cell in gridUnderTest.CurrentGeneration)
            {
                if(cell.IsAlive)
                {
                    result = false;
                    break;
                }
            }
            return result;
        }
        
    }
}
