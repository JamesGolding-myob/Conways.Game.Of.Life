using System;
using System.Collections.Generic;

namespace Conways.Game.Of.Life
{
    public class InputConverter
    {
        public Tuple<int, int> ConvertGridRowsAndColumns(string rowsAndColumns)
        {
            var splitRowsAndColumns = rowsAndColumns.Split(",", StringSplitOptions.None);

            return new Tuple<int, int>(Int32.Parse(splitRowsAndColumns[0]), Int32.Parse(splitRowsAndColumns[1]));
        }

        public List<Tuple<int, int>> ConvertStartingGenerationInputToCoordinates(string input)
        {
            var splitInput = input.Split(" ", StringSplitOptions.None);
           List<Tuple<int, int>>  coordinateList = new List<Tuple<int, int>>();

            foreach (var inputCoordinate in splitInput)
            {
                var coordinatePair = inputCoordinate.Split(",", StringSplitOptions.None);    
                coordinateList.Add(new Tuple<int, int>(Int32.Parse(coordinatePair[0]), Int32.Parse(coordinatePair[1])));
            }

            return coordinateList;

        }

    }
}