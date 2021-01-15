using System.IO;
namespace Conways.Game.Of.Life
{
    public class FileReader
    {
        public string[] ReadInputs(string filePath)
        {
            string[] output = File.ReadAllLines(filePath);
            return output;
        }
    }
}