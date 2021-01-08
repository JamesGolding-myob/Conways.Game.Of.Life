using System;

namespace Conways.Game.Of.Life.Code
{
    class Program
    {
        static void Main(string[] args)
        {
           ConsoleUI ui = new ConsoleUI(); 
           var displayFormatter = new DisplayFormatter();
           var inputConverter = new InputConverter();
           
           Game life = new Game(ui, displayFormatter, inputConverter, 3);

           life.Run();
        }
    }
}
