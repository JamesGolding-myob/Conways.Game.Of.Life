using System.Collections.Generic;
using System.Linq;
namespace Conways.Game.Of.Life
{
    public class Grid
    {
        private const bool Alive = true;
        private const bool Dead = false;
        private const int NeighbourLimitToBecomeAlive = 3;
        private const int NeighbourLimitForOverPopulation = 3;
        private const int NeighbourLimitForUnderPopulation = 2;
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

        public void SetInitialGridState(List<Location> locationsToBeAlive)
        {
            foreach (var location in locationsToBeAlive)
            {
                CurrentGeneration[location.Row, location.Column].IsAlive = Alive;   
            }
        }

        public void ApplyRulesToGrid()
        {
            List<Cell> cellsToBeDeadInNextGeneration = new List<Cell>();
            List<Cell> cellsToBecomeAliveInNextGeneration = new List<Cell>();

            foreach(Cell cell in CurrentGeneration)
            {
                List<Cell> liveNeighbours = GetLiveNeighbours(cell);
               if(liveNeighbours.Count < NeighbourLimitForUnderPopulation)
               {
                   cellsToBeDeadInNextGeneration.Add(cell);
               }

               if(liveNeighbours.Count == NeighbourLimitToBecomeAlive)
               {
                   cellsToBecomeAliveInNextGeneration.Add(cell);
               }
               
               if(liveNeighbours.Count > NeighbourLimitForOverPopulation)
               {
                   cellsToBeDeadInNextGeneration.Add(cell);
               }   
            }
            UpdateGeneration(cellsToBeDeadInNextGeneration, cellsToBecomeAliveInNextGeneration);
        }

        public void UpdateGeneration(List<Cell> cellsToBeDeadNextGeneration, List<Cell> cellsToBecomeAlive)
        {
            UpdateCellStatus(cellsToBeDeadNextGeneration, Dead);
            UpdateCellStatus(cellsToBecomeAlive, Alive);
        }

        private void UpdateCellStatus(List<Cell> cellsToChange, bool status)
        {
            foreach (Cell cell in cellsToChange)
            {
                CurrentGeneration[cell.GridLocation.Row, cell.GridLocation.Column].IsAlive = status;
            }
        }

        private List<Cell> GetLiveNeighbours(Cell cellOfInterest)
        {
            
            Cell topLeftNeighbour = GetNeighbour(cellOfInterest.GridLocation, NeighbourLocation.TopLeft);
            Cell topCentreNeighbour = GetNeighbour(cellOfInterest.GridLocation, NeighbourLocation.TopCentre);
            Cell topRightNeighbour = GetNeighbour(cellOfInterest.GridLocation, NeighbourLocation.TopRight);

            Cell rightNeighbour = GetNeighbour(cellOfInterest.GridLocation, NeighbourLocation.Right);
            Cell leftNeighbour = GetNeighbour(cellOfInterest.GridLocation, NeighbourLocation.Left);

            Cell bottomLeftNeighbour = GetNeighbour(cellOfInterest.GridLocation, NeighbourLocation.BottomLeft);
            Cell bottomCentreNeighbour = GetNeighbour(cellOfInterest.GridLocation, NeighbourLocation.BottomCentre);
            Cell bottomRightNeighbour = GetNeighbour(cellOfInterest.GridLocation, NeighbourLocation.BottomRight);

            Cell[] neighbourhood = new Cell[]{
                topLeftNeighbour, 
                topCentreNeighbour,
                topRightNeighbour,
                leftNeighbour,
                rightNeighbour,
                bottomLeftNeighbour,
                bottomRightNeighbour,
                bottomCentreNeighbour};

                var aliveNeighbours = neighbourhood.Where(x => x.IsAlive).ToList();
               
            return aliveNeighbours;
        }

        private Cell GetNeighbour(Location currentPosition, NeighbourLocation interestedPosition)
        {
            Cell neighbour;
            int topRowIndex = NumberOfRows - 1;
            int bottomRowIndex = 0;
            int leftMostColumnIndex = 0;
            int rightMostColumnIndex = NumberOfColumns - 1;

            var columnToTheLeftIndex = currentPosition.Column - 1;
            var columnToTheRightIndex = currentPosition.Column + 1;
            var rowBelowIndex = currentPosition.Row - 1;
            var rowAboveIndex = currentPosition.Row + 1;


            switch (interestedPosition)
            {
                case NeighbourLocation.TopLeft:
                {
                    neighbour = CurrentGeneration[GetUpperIndexWithWrapping(currentPosition.Row, topRowIndex, bottomRowIndex), GetLowerIndexWithWrapping(currentPosition.Column, rightMostColumnIndex, leftMostColumnIndex)];
                    break;
                }
               
                case NeighbourLocation.TopRight:
                {
                    neighbour = CurrentGeneration[GetUpperIndexWithWrapping(currentPosition.Row, topRowIndex, bottomRowIndex), GetUpperIndexWithWrapping(currentPosition.Column, rightMostColumnIndex, leftMostColumnIndex)];
                    break;
                }

                case NeighbourLocation.TopCentre:
                {
                    neighbour = CurrentGeneration[GetUpperIndexWithWrapping(currentPosition.Row, topRowIndex, bottomRowIndex), currentPosition.Column];
                    break;
                }

                case NeighbourLocation.Right:
                {
                    neighbour = CurrentGeneration[currentPosition.Row, GetUpperIndexWithWrapping(currentPosition.Column, rightMostColumnIndex, leftMostColumnIndex)];
                    break;
                }

                case NeighbourLocation.Left:
                {
                    neighbour = CurrentGeneration[currentPosition.Row, GetLowerIndexWithWrapping(currentPosition.Column, rightMostColumnIndex, leftMostColumnIndex)];
                    break; 
                }

                case NeighbourLocation.BottomLeft:
                {
                    neighbour = CurrentGeneration[GetLowerIndexWithWrapping(currentPosition.Row, topRowIndex, bottomRowIndex), GetLowerIndexWithWrapping(currentPosition.Column, rightMostColumnIndex, leftMostColumnIndex)];
                    break;
                }

                 case NeighbourLocation.BottomRight:
                {
                    neighbour = CurrentGeneration[GetLowerIndexWithWrapping(currentPosition.Row, topRowIndex, bottomRowIndex), GetUpperIndexWithWrapping(currentPosition.Column, rightMostColumnIndex, leftMostColumnIndex)];
                    break;
                }

                case NeighbourLocation.BottomCentre:
                {
                    neighbour = CurrentGeneration[GetLowerIndexWithWrapping(currentPosition.Row, topRowIndex, bottomRowIndex), currentPosition.Column];
                    break;
                }
                
                default:
                {
                    neighbour = CurrentGeneration[0,0];
                    break;
                }
            }
            return neighbour;
        } 
       
        private int GetLowerIndexWithWrapping(int location, int upperBound, int lowerBound)
        {
            var locationOfInterest = location - 1;
            return locationOfInterest >= lowerBound ? locationOfInterest : upperBound;
        }

        private int GetUpperIndexWithWrapping(int location, int upperBound, int lowerBound)
        {
            var locationOfInterest = location + 1;
            return locationOfInterest <= upperBound ? locationOfInterest : lowerBound; 
        }
    }
}