namespace Conways.Game.Of.Life.Code
{
    class Program
    {
        static void Main(string[] args)
        {
           ConsoleUI ui = new ConsoleUI(); 
           var displayFormatter = new DisplayFormatter();
           var inputConverter = new InputConverter();
           var displayDelayer = new Delayer(milliSecDelay:1500);
           
           Game life = new Game(ui, displayFormatter, inputConverter, displayDelayer);
          
           life.Run();
        }
    }
}
