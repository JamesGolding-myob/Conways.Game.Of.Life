using Xunit;
using System;
using System.Collections.Generic;
namespace Conways.Game.Of.Life
{
    public class InputConverterTests
    {
        InputConverter converter = new InputConverter();

        [Theory]
        [InlineData("1,1", 1, 1)]
        [InlineData("5,4", 5, 4)]
        [InlineData("6,20", 6, 20)]
        [InlineData("10,2", 10, 2)]
        public void CommaSeperatednumbersAreConvertedForNumberOfColumnsAndRows(string input, int expectedRowOutput, int expectedColumnOutput)
        {
            Assert.Equal(expectedRowOutput, converter.ConvertGridRowsAndColumns(input).Item1);
            Assert.Equal(expectedColumnOutput, converter.ConvertGridRowsAndColumns(input).Item2);
        }

        [Fact]
        public void MultipleCoordinatesOfCellIndicesSeperatedBySpacesIsConvertedToCoordinates()
        {
            List<Tuple<int, int>> expectedOutput = new List<Tuple<int, int>>{Tuple.Create(1, 2), Tuple.Create(5, 6)};
            var inputString = "1,2 5,6";

            Assert.Equal(expectedOutput, converter.ConvertStartingGenerationInputToCoordinates(inputString));
        }

    }

}