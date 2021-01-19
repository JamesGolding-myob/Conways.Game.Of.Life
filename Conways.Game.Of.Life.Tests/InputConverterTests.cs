using Xunit;
using System.Collections.Generic;
using System;
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
        public void CommaSeperatedNumbersAreConvertedForNumberOfColumnsAndRows(string input, int expectedRowOutput, int expectedColumnOutput)
        {
            Assert.Equal(expectedRowOutput, converter.ConvertGridRowsAndColumns(input).NumberOfRows);
            Assert.Equal(expectedColumnOutput, converter.ConvertGridRowsAndColumns(input).NumberOfColumns);
        }

        [Fact]
        public void MultipleCoordinatesOfCellIndicesSeperatedBySpacesIsConvertedToCoordinates()
        {
            List<Location> expectedOutput = new List<Location>{new Location(1, 2), new Location(5, 6)};
            var inputString = "1,2 5,6";

            Assert.True(ListValuesAreTheSame(expectedOutput, converter.ConvertStartingGenerationInputToCoordinates(inputString)));
        }

        [Fact]
        public void MaxGenerationsInputIsParsedToIntegerValue()
        {
            var input = "3";
            var expectedOutput = 3;

            Assert.Equal(expectedOutput, converter.ConvertMaxGenerations(input));
        }

         [Fact]
       public void EmptyStringGridDimensionFormatCauseExcpetionToBeThrown()
       {
           var expectedErrorMessage = "Input not in a correct format. Please use format: row,column";
            
           var ex = Assert.Throws<FormatException>(() => converter.ConvertGridRowsAndColumns(""));
           Assert.Equal(expectedErrorMessage, ex.Message);
       } 

       [Fact]
       public void LetterInsteadOfNumberStringForGridDimensionCausesExceptionToBeThrown()
       {
           var expectedErrorMessage = "Input not in a correct format. Please use format: row,column";
            
           var ex = Assert.Throws<FormatException>(() => converter.ConvertGridRowsAndColumns("r"));
           Assert.Equal(expectedErrorMessage, ex.Message);
       }

       [Fact]
       public void OnlyOneNumberEnteredFormatExceptionisThrown()
       {
           var expectedErrorMessage = "Please enter two numbers seperated by a comma.";
            
           var ex = Assert.Throws<IndexOutOfRangeException>(() => converter.ConvertGridRowsAndColumns("11"));
           Assert.Equal(expectedErrorMessage, ex.Message);
       }

       [Fact]
       public void EmptyInitialStateStringFormatExecpetionIsThrown()
       {
           var expectedErrorMessage = "Input not in a correct format. Please input pairs of numbers seperated by a comma. eg 0,0 1,2";
            
           var ex = Assert.Throws<FormatException>(() => converter.ConvertStartingGenerationInputToCoordinates(" "));
           Assert.Equal(expectedErrorMessage, ex.Message);
       }

       [Fact]
       public void OnlyOneNumberWhenSettingInitialStateThrowsIndexOutOfRangeException()
       {
            var expectedErrorMessage = "Please enter number pairs seperated by a comma. - index out of range";
            
            var ex = Assert.Throws<IndexOutOfRangeException>(() => converter.ConvertStartingGenerationInputToCoordinates("1"));
            Assert.Equal(expectedErrorMessage, ex.Message);
       }

       [Fact]
       public void FormatExceptionsAreThrownForConvertingMaxGeneratinsString()
       {
            var expectedErrorMessage = "Please enter a number greater than zero.";
            
            var ex = Assert.Throws<FormatException>(() => converter.ConvertMaxGenerations(""));
            Assert.Equal(expectedErrorMessage, ex.Message);
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