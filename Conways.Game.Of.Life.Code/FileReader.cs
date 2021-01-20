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
                throw new DirectoryNotFoundException(MessageConstants.DirectoryExceptionMessage);
            }
            catch(FileNotFoundException)
            {
                throw new FileNotFoundException(MessageConstants.FileNotFoundExceptionMessage);
            }
            
            return output;
        }
    }
}