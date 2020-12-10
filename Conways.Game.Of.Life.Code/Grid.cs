namespace Conways.Game.Of.Life
{
    public class Grid
    {
        public Cell[,] Board {get; private set;}
        public int Columns{get; private set;}
        public int Rows{get; private set;}
        public Grid(int columns, int rows)
        {
            Columns = columns;
            Rows = rows;

            CreateBoardOfCells();
        }

        private void CreateBoardOfCells()
        {
            Board = new Cell[Rows, Columns];

            for(int i = 0; i < Rows; i++)
            {
                for(int j = 0; j < Columns; j++ )
                {
                    Board[i, j] = new Cell();
                } 
            }
        }
    }
}