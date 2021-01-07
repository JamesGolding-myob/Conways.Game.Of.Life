namespace Conways.Game.Of.Life
{
    public class Location
    {
        public Location(int row, int column)
        {
            Row = row;
            Column = column;
        }
        public int Row {get; set;}
        public int Column{get; set;}
    }
}