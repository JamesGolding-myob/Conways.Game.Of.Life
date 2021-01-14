using System;
using System.Collections.Generic;

namespace Conways.Game.Of.Life
{
    public class InputConverter
    {
        public Dimensions ConvertGridRowsAndColumns(string rowsAndColumns)
        {
            string[]splitRowsAndColumns;
            Dimensions output;
            try
            {
                splitRowsAndColumns = rowsAndColumns.Split(",", StringSplitOptions.None);
                output = new Dimensions(Int32.Parse(splitRowsAndColumns[0]), Int32.Parse(splitRowsAndColumns[1]));
            }
            catch (FormatException)
            { 
                throw new FormatException(OutputConstants.rowsColumnsFormatExceptionMessage);
            }
            catch(IndexOutOfRangeException)
            {
                throw new IndexOutOfRangeException(OutputConstants.gridDimensionOutOfRangeExceptionMessage);
            }
            return output;
        }

        public List<Location> ConvertStartingGenerationInputToCoordinates(string input)
        {
            var splitInput = input.Split(" ", StringSplitOptions.None);
           List<Location> coordinateList = new List<Location>();

            foreach (var inputCoordinate in splitInput)
            {
                try
                {
                    coordinateList.Add(ConvertToGridLocation(inputCoordinate));   
                }
                catch (FormatException)
                {  
                    throw;
                }
                catch(IndexOutOfRangeException)
                {
                    throw;
                }
            }
            return coordinateList;
        }

        public Location ConvertToGridLocation(string inputCoordinates)
        {
            Location result;
            string[] splitRowsAndColumns = inputCoordinates.Split(",", StringSplitOptions.None);

            try
            {
                result = new Location(Int32.Parse(splitRowsAndColumns[0]), Int32.Parse(splitRowsAndColumns[1]));
            }
            catch(IndexOutOfRangeException)
            {
                throw new IndexOutOfRangeException(OutputConstants.initialGridStateOutOfRangeException);
            }
            catch (FormatException)
            {
                throw new FormatException(OutputConstants.initialGridStateFormatException);
            }
            return result;
        }

        public int ConvertMaxGenerations(string input)
        {
            return Int32.Parse(input);
        }

    }
}