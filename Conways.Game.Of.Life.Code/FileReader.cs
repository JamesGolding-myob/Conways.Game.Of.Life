using System.IO;
namespace Conways.Game.Of.Life
{
    public class FileReader
    {
        public string[] ReadInputs(string filePath)
        {
            string[] output;
            try
            {
                output = File.ReadAllLines(filePath);
                
            }
            catch (DirectoryNotFoundException)
            {
                throw new DirectoryNotFoundException(OutputConstants.directoryExceptionMessage);
            }
            catch(FileNotFoundException)
            {
                throw new FileNotFoundException(OutputConstants.fileNotFoundExceptionMessage);
            }
            
            return output;
        }
    }
}