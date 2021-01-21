
namespace Conways.Game.Of.Life
{
    public class Cell
    {
        public bool IsAlive{get; set;} = false;
        
        public Location GridLocation; 

        public Cell(int row, int column)
        { 
            GridLocation = new Location(row, column);
          
        }
    }
}