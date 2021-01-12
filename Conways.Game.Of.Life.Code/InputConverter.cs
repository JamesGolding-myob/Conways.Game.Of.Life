using System;
using System.Collections.Generic;

namespace Conways.Game.Of.Life
{
    public class InputConverter
    {
        public Dimensions ConvertGridRowsAndColumns(string rowsAndColumns)
        {
            var splitRowsAndColumns = rowsAndColumns.Split(",", StringSplitOptions.None);

            return new Dimensions(Int32.Parse(splitRowsAndColumns[0]), Int32.Parse(splitRowsAndColumns[1]));
        }

        public List<Location> ConvertStartingGenerationInputToCoordinates(string input)
        {
            var splitInput = input.Split(" ", StringSplitOptions.None);
           List<Location> coordinateList = new List<Location>();

            foreach (var inputCoordinate in splitInput)
            {
                coordinateList.Add(ConvertToGridLocation(inputCoordinate));
            }
            return coordinateList;
        }

        public Location ConvertToGridLocation(string inputCoordinates)
        {
            var splitRowsAndColumns = inputCoordinates.Split(",", StringSplitOptions.None);

            return new Location(Int32.Parse(splitRowsAndColumns[0]), Int32.Parse(splitRowsAndColumns[1]));
        }

        public int ConvertMaxGenerations(string input)
        {
            return Int32.Parse(input);
        }

    }
}