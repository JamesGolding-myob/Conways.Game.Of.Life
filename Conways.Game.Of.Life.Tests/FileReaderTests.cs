using Xunit;

namespace Conways.Game.Of.Life
{
    public class FileReaderTests
    {
        FileReader reader = new FileReader();

        [Fact]
        public void CanReadAStringFromAFile()
        {
            var filePath = @"/Users/James.Golding/Desktop/temp.csv";
            string[] data = reader.ReadInputs(filePath);

            Assert.Equal("1", data[0]); 
        }

    }
}