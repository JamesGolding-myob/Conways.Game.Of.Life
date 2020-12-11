namespace Conways.Game.Of.Life
{
    public class DisplayFormatter
    {
        public string GridToString(Grid grid)
        {
            string output = "";

            for(int i = 0; i < grid.Rows; i++)
            {
                for(int j = 0; j < grid.Columns; j++ )
                {

                    if(LastColumn(j, grid.Columns))
                    {
                        output = output + " . \n";
                    }
                    
                    else
                    {
                        output = output + " . ";
                    }
                } 
            }

            return output;
        }

        private bool LastColumn(int counter, int numberOfColumns)
        {
            return counter == numberOfColumns - 1;
        }
    }
}