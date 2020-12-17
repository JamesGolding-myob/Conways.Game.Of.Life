using System;
namespace Conways.Game.Of.Life
{
    public class Cell
    {
        public bool IsAlive{get; set;} = false;
        public Tuple<int, int> Location{get; private set;} 

        public Cell(int row, int column)
        {
            Location = new Tuple<int, int>(row, column);
        }
    }
}