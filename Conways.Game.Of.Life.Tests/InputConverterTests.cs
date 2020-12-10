using Xunit;
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
    }

}