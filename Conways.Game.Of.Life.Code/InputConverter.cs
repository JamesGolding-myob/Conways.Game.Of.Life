using System;

namespace Conways.Game.Of.Life
{
    public class InputConverter
    {
        public Tuple<int, int> ConvertGridRowsAndColumns(string rowsAndColumns)
        {
            var splitRowsAndColumns = rowsAndColumns.Split(",", StringSplitOptions.None);

            return new Tuple<int, int>(Int32.Parse(splitRowsAndColumns[0]), Int32.Parse(splitRowsAndColumns[1]));
        }
    }
}