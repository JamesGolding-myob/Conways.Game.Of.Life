namespace Conways.Game.Of.Life
{
    public struct Dimensions
    {
        public int NumberOfRows{get;}
        public int NumberOfColumns{get;}

         public Dimensions(int wantedRows, int wantedColumns)
        {
           NumberOfRows = wantedRows;
           NumberOfColumns = wantedColumns;
        }
    }
}