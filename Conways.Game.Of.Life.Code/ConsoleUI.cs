using System;
namespace Conways.Game.Of.Life
{
    public class ConsoleUI : IUI
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