using Xunit;

namespace Conways.Game.Of.Life
{
    public class FileReaderTests
    {
        FileReader reader = new FileReader();

        [Fact]
        public void CanReadACellLocationString()
        {
            var filePath = @"/Users/James.Golding/Desktop/temp.csv";
            string[] data = reader.ReadInputs(filePath);

            Assert.Equal("1,1", data[0]); 
            Assert.Equal("0,0", data[1]); 
        }

        [Fact]
        public void BadFilePath_DirectoryExceptionReadingInitialStateFromCSVFile()
        {
            var expectedErrorMessage = "Could not find directory";
            var ex = Assert.Throws<System.IO.DirectoryNotFoundException>(() => reader.ReadInputs(@"/Users/James.Golding/Desktop2/temp.csv"));
            Assert.Equal(expectedErrorMessage, ex.Message);    
        }

        [Fact]
        public void BadFilePath_CouldNotFindFileExceptionReadingInitialStateFromCSVFile()
        {
            var expectedErrorMessage = "Could not find file";
            var ex = Assert.Throws<System.IO.FileNotFoundException>(() => reader.ReadInputs(@"/Users/James.Golding/Desktop/temp2.csv"));
            Assert.Equal(expectedErrorMessage, ex.Message);    
        }
 

    }
}