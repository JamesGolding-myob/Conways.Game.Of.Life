using Xunit;
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
            Assert.Equal(expectedRowOutput, converter.ConvertGridRowsAndColumns(input).Row);
            Assert.Equal(expectedColumnOutput, converter.ConvertGridRowsAndColumns(input).Column);
        }

        [Fact]
        public void MultipleCoordinatesOfCellIndicesSeperatedBySpacesIsConvertedToCoordinates()
        {
            List<Location> expectedOutput = new List<Location>{new Location(1, 2), new Location(5, 6)};
            var inputString = "1,2 5,6";

            Assert.True(ListValuesAreTheSame(expectedOutput, converter.ConvertStartingGenerationInputToCoordinates(inputString)));
        }

        public bool ListValuesAreTheSame(List<Location> expected, List<Location> converted)
        { bool isSame = true;
            for(int i = 0; i <= 1; i++)
            {
                if(expected[i].Row != converted[i].Row || expected[i].Column != converted[i].Column)
                {
                    isSame = false;
                }
            }
            return isSame;
        }
    }
}