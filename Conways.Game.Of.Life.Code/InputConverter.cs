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
                throw new FormatException(MessageConstants.RowsColumnsFormatExceptionMessage);
            }
            catch(IndexOutOfRangeException)
            {
                throw new IndexOutOfRangeException(MessageConstants.GridDimensionOutOfRangeExceptionMessage);
            }
            return output;
        }

        public List<Location> ConvertStartingGenerationInputToLocations(string input)
        {
            var splitInput = input.Split(" ", StringSplitOptions.None);
           List<Location> locationList = new List<Location>();

            foreach (var inputCoordinate in splitInput)
            {
                try
                {
                    locationList.Add(ConvertToGridLocation(inputCoordinate));   
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
            return locationList;
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
                throw new IndexOutOfRangeException(MessageConstants.InitialGridStateOutOfRangeException);
            }
            catch (FormatException)
            {
                throw new FormatException(MessageConstants.InitialGridStateFormatException);
            }
            return result;
        }

        public int ConvertMaxGenerations(string inputFromUser)
        {
            try
            {
                return Int32.Parse(inputFromUser);
            }
            catch (FormatException)
            {
                throw new FormatException(MessageConstants.MaxGenerationFormatException);
            }
        }

    }
}