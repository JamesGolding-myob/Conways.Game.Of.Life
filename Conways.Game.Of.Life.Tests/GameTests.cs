using Xunit;
namespace Conways.Game.Of.Life
{
    public class GameTests
    {
        InputConverter inputConverter = new InputConverter();

        [Fact]
        public void UserSetsSizeOfGridTo3x4AndSeesA3x4GridDisplayedToThem()
        {
            string expectedLastString = " . " + " . " + " . " + " . \n" +
                                        " . " + " . " + " . " + " . \n" +
                                        " . " + " . " + " . " + " . \n";

            StubUI ui = new StubUI();          
            DisplayFormatter displayFormatter = new DisplayFormatter();

            Game game = new Game(ui, displayFormatter, inputConverter);
            game.Run();
        
            Assert.Equal(expectedLastString, ui.LastString);
        }

        
    }
    public class StubUI : IUI
    {
        public string LastString{get; private set;}
        public string GetUserInput()
        {
           return "3,4";
        }

        public void Print(string output)
        {
            LastString = output;
        }
    }
}