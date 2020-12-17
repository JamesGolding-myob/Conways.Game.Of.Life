using System.Collections.Generic;
using System;
namespace Conways.Game.Of.Life
{
    public class Grid
    {
        public Cell[,] CurrentGeneration {get; private set;}
        public int NumberOfColumns{get; private set;}
        public int NumberOfRows{get; private set;}
        public Grid(int rows, int columns)
        {
            NumberOfColumns = columns;
            NumberOfRows = rows;

            CreateBoardOfCells();
        }

        private void CreateBoardOfCells()
        {
            CurrentGeneration = new Cell[NumberOfRows, NumberOfColumns];

            for(int row = 0; row < NumberOfRows; row++)
            {
                for(int column = 0; column < NumberOfColumns; column++ )
                {
                    CurrentGeneration[row, column] = new Cell(row, column);
                } 
            }
        }

        public void SetInitialGridState(List<Tuple<int, int>> locationsToBeAlive)
        {
            foreach (var location in locationsToBeAlive)
            {
                CurrentGeneration[location.Item1, location.Item2].IsAlive = true;   
            }
        }

        public List<Cell> ApplyRules()
        {
            List<Cell> cellsToBeDeadInNextGeneration = new List<Cell>();

            foreach(Cell cell in CurrentGeneration)
            {
                List<Cell> liveNeighbours = GetLiveNeighbours(cell);
               if(liveNeighbours.Count < 2)
               {
                   cellsToBeDeadInNextGeneration.Add(cell);
               }   
            }

            return cellsToBeDeadInNextGeneration;
        }

        public void UpdateGeneration(List<Cell> cellsToBeDeadNextGeneration)
        {
            foreach (Cell cell in cellsToBeDeadNextGeneration)
            {
                CurrentGeneration[cell.Location.Item1, cell.Location.Item2].IsAlive = false;
            }

        }

        private List<Cell> GetLiveNeighbours(Cell cellOfInterest)
        {
            var topRowIndex = NumberOfRows - 1;
            var bottomRowIndex = 0;
            var leftMostColumnIndex = 0;
            var rightMostColumnIndex = NumberOfColumns - 1;
            
            var rowAboveIndex = cellOfInterest.Location.Item1 + 1;
            var rowBelowIndex = cellOfInterest.Location.Item1 - 1;

            var columnToTheLeftIndex = cellOfInterest.Location.Item2 - 1;
            var columnToTheRightIndex = cellOfInterest.Location.Item2 + 1;

            var currentColumnIndex = cellOfInterest.Location.Item2;
            var currentRowIndex = cellOfInterest.Location.Item1;

            Cell topLeftNeighbour = CurrentGeneration[rowAboveIndex <= topRowIndex ? rowAboveIndex : bottomRowIndex, columnToTheLeftIndex >= leftMostColumnIndex ? columnToTheLeftIndex: rightMostColumnIndex];
            Cell topCenterNeighbour = CurrentGeneration[rowAboveIndex <= topRowIndex ? rowAboveIndex : bottomRowIndex, currentColumnIndex];
            Cell topRightNeighbour = CurrentGeneration[rowAboveIndex <= topRowIndex ? rowAboveIndex : bottomRowIndex, columnToTheRightIndex < NumberOfColumns ? columnToTheRightIndex : leftMostColumnIndex];

            Cell leftNeighbour = CurrentGeneration[currentRowIndex, columnToTheLeftIndex >= leftMostColumnIndex ? columnToTheLeftIndex : rightMostColumnIndex];
            Cell rightNeighbour = CurrentGeneration[currentRowIndex, columnToTheRightIndex < NumberOfColumns ? columnToTheRightIndex : leftMostColumnIndex];

            Cell bottomLeftNeighbour = CurrentGeneration[rowBelowIndex >= bottomRowIndex ? rowBelowIndex : topRowIndex, columnToTheLeftIndex >= leftMostColumnIndex ? columnToTheLeftIndex : rightMostColumnIndex];
            Cell bottomCentreNeighbour = CurrentGeneration[rowBelowIndex >= bottomRowIndex ? rowBelowIndex : topRowIndex, currentColumnIndex];
            Cell bottomRightNeighbour = CurrentGeneration[rowBelowIndex >= bottomRowIndex ? rowBelowIndex : topRowIndex, columnToTheRightIndex < NumberOfColumns ? columnToTheRightIndex : leftMostColumnIndex];
            
            Cell[] neighbourhood = new Cell[]{
                topLeftNeighbour, 
                topCenterNeighbour,
                topRightNeighbour,
                leftNeighbour,
                rightNeighbour,
                bottomLeftNeighbour,
                bottomRightNeighbour,
                bottomCentreNeighbour};

            List<Cell> AliveNeighbours = new List<Cell>();

            foreach (Cell cell in neighbourhood)
            {
                if(cell.IsAlive)
                {
                    AliveNeighbours.Add(cell);
                }
            }
            
            return AliveNeighbours;
        }
       
    }
}