using System;
namespace Conways.Game.Of.Life
{
    public class ConsoleUI : IUserInterface
    {
        public string GetUserInput()
        {
            return Console.ReadLine();
        }

        public void Print(string output)
        {
            Console.WriteLine(output);
        }
    }
}