namespace Conways.Game.Of.Life
{
    public struct Dimensions
    {
        public int NumberOfRows{get; set;}
        public int NumberOfColumns{get; set;}

         public Dimensions(int wantedRows, int wantedColumns)
        {
           NumberOfRows = wantedRows;
           NumberOfColumns = wantedColumns;
        }
    }
}