namespace Conways.Game.Of.Life
{
    public class DisplayFormatter
    {
        public string GridToString(Grid grid)
        {
            int rowsMaximum = grid.Rows - 1;
            int columnsMaximum = grid.Columns - 1;
            string output = "";
            string deadCellSymbol = " . ";
            string aliveCellSymbol = " A ";

            for(int i = rowsMaximum; i >= 0; i--)
            {
                for(int j = 0; j <= columnsMaximum; j++ )
                {
                    string symbolToAdd = deadCellSymbol;
                    if(grid.Board[i, j].IsAlive)
                    {
                        symbolToAdd = aliveCellSymbol;
                    }

                    if(IsLastInColumn(j, columnsMaximum))
                    {
                        output = output + $"{symbolToAdd}\n";
                    }
                    else
                    {
                        output = output + symbolToAdd; 
                    }
                } 
            }

            return output;
        }

        private bool IsLastInColumn(int counter, int columnsMaximum)
        {
            return counter == columnsMaximum;
        }
    }
}