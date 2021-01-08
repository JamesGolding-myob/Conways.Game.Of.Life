using Xunit;
using System.Collections;
namespace Conways.Game.Of.Life
{
    public class GameTests
    {
        InputConverter inputConverter = new InputConverter();
        DisplayFormatter displayFormatter = new DisplayFormatter();
        StubUI ui = new StubUI(); 

        [Fact]
        public void UserInitiallySetsTopRowAliveAllCellsAreAliveInNextGeneration()
        {
             var expectedOutput =   " A " + " A " + " A " + " A \n" +
                                    " A " + " A " + " A " + " A \n" +
                                    " A " + " A " + " A " + " A \n" ;
            
 
            Game game = new Game(ui, displayFormatter, inputConverter);
            ui.AddToQueue("3,4");
            ui.AddToQueue("2,0 2,1 2,2 2,3");

            game.Run();

            Assert.Equal(expectedOutput, ui.LastString);
        }

        [Fact]
        public void UserInitiallySetsTopRightCentreLeftBottomRightCellsAliveThreeMoreCellsBecomeAlive()
        {
            var expectedOutput = " A " + " . " + " . " + " A \n" +
                                 " A " + " . " + " . " + " A \n" +
                                 " A " + " . " + " . " + " A \n" ;

            Game game = new Game(ui, displayFormatter, inputConverter);
            ui.AddToQueue("3,4");
            ui.AddToQueue("2,3 1,0 0,3");

            game.Run();

            Assert.Equal(expectedOutput, ui.LastString);
        }

        [Fact]
        public void FourByFourGridWith3CellsAliveInLShapeConfiguarationBecomeABlock()
        {
            var expectedOutput = " . " + " . " + " . " + " . \n" +
                                 " . " + " A " + " A " + " . \n" +
                                 " . " + " A " + " A " + " . \n" +
                                 " . " + " . " + " . " + " . \n" ;

            Game game = new Game(ui, displayFormatter, inputConverter);
            ui.AddToQueue("4,4");
            ui.AddToQueue("1,1 2,1 1,2");

            game.Run();

            Assert.Equal(expectedOutput, ui.LastString);
        }

        [Fact]
        public void ThreeCellOscillatorIn4x4Grid()
        {
            var expectedOutput = " . " + " A " + " . " + " . \n" +
                                 " . " + " A " + " . " + " . \n" +
                                 " . " + " A " + " . " + " . \n" +
                                 " . " + " . " + " . " + " . \n" ;

            Game game = new Game(ui, displayFormatter, inputConverter);
            ui.AddToQueue("4,4");
            ui.AddToQueue("2,0 2,1 2,2");
            game.Run();

            Assert.Equal(expectedOutput, ui.LastString);
        } 
    }

    
    
    public class StubUI : IUserInterface
    {
        public string LastString{get; private set;}
        private Queue myQ = new Queue();
        public string GetUserInput()
        {
           return (string)myQ.Dequeue();
        }

        public void Print(string output)
        {
            LastString = output;
        }

        public void AddToQueue(string input)
        {
            myQ.Enqueue(input);
        }

    }


}