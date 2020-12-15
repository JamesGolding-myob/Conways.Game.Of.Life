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

            for(int rowIndex = rowsMaximum; rowIndex >= 0; rowIndex--)
            {
                for(int columnIndex = 0; columnIndex <= columnsMaximum; columnIndex++ )
                {
                    string symbolToAdd = deadCellSymbol;

                    if(grid.Board[rowIndex, columnIndex].IsAlive)
                    {
                        symbolToAdd = aliveCellSymbol;
                    }

                    output += symbolToAdd;  
                } 
                output += "\n";
            }

            return output;
        }

    }
}