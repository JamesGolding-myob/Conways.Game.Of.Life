using System;
namespace Conways.Game.Of.Life
{
    public class Cell
    {
        public bool IsAlive{get; set;} = false;
        
        public Location GridLocation = new Location();

        public Cell(int row, int column)
        {
            GridLocation.Row = row;
            GridLocation.Column = column;
        }
    }
}