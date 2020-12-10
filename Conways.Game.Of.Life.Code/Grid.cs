namespace Conways.Game.Of.Life
{
    public class Grid
    {
        public Cell[,] Board {get; private set;}
        private int _columns;
        private int _rows;
        public Grid(int columns, int rows)
        {
            _columns = columns;
            _rows = rows;

            CreateBoardOfCells();
        }

        private void CreateBoardOfCells()
        {
            Board = new Cell[_rows, _columns];

            for(int i = 0; i < _rows; i++)
            {
                for(int j = 0; j < _columns; j++ )
                {
                    Board[i, j] = new Cell();
                } 
            }
        }
    }
}