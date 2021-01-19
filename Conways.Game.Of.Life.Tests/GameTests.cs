using Xunit;
using System.Collections;

namespace Conways.Game.Of.Life
{
    public class GameTests
    {
        InputConverter inputConverter = new InputConverter();
        DisplayFormatter displayFormatter = new DisplayFormatter();
        StubUI ui = new StubUI(); 
        Delayer delayer = new Delayer(1);
        FileReader fileReader = new FileReader();

        [Fact]
        public void UserInitiallySetsTopRowAliveAllCellsAreAliveInNextGeneration()
        {
             var expectedOutput =   " A " + " A " + " A " + " A \n" +
                                    " A " + " A " + " A " + " A \n" +
                                    " A " + " A " + " A " + " A \n" ;
            
 
            Game game = new Game(ui, displayFormatter, inputConverter, delayer, fileReader);
            ui.AddToQueue("3,4");//setting grid dimension input
            ui.AddToQueue("n");//manual initial state entry method chosen
            ui.AddToQueue("2,0 2,1 2,2 2,3");//starting grid pattern inputed
            ui.AddToQueue("1");//number of generation iterations inputed

            game.Run();

            Assert.Equal(expectedOutput, ui.LastString);
        }

        [Fact]
        public void UserInitiallySetsTopRightCentreLeftBottomRightCellsAliveThreeMoreCellsBecomeAlive()
        {
            var expectedOutput = " A " + " . " + " . " + " A \n" +
                                 " A " + " . " + " . " + " A \n" +
                                 " A " + " . " + " . " + " A \n" ;

            Game game = new Game(ui, displayFormatter, inputConverter, delayer, fileReader);
            ui.AddToQueue("3,4");
            ui.AddToQueue("n");
            ui.AddToQueue("2,3 1,0 0,3");
            ui.AddToQueue("1");

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

            Game game = new Game(ui, displayFormatter, inputConverter, delayer, fileReader);
            ui.AddToQueue("4,4");
            ui.AddToQueue("n");
            ui.AddToQueue("2,1 1,1 1,2");
            ui.AddToQueue("4");

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

            Game game = new Game(ui, displayFormatter, inputConverter, delayer, fileReader);
            ui.AddToQueue("4,4");
            ui.AddToQueue("n");
            ui.AddToQueue("2,0 2,1 2,2");
            ui.AddToQueue("1");

            game.Run();

            Assert.Equal(expectedOutput, ui.LastString);
        } 

        [Theory]
        [InlineData("3", 3)]
        [InlineData("1", 1)]
        [InlineData("10", 10)]
       [InlineData("100", 100)] 
        public void MoreThanOneGenerationInGameSetByTheUser(string input, int numberOfGenerations)
       {
            int numberOfPrintsInRunLoop = 1;
            int numberofPrintForGettingGridDems = 1;
            int numberofPrintsInSetUpIntialValues = 2;
            int numberOfPrintsValidateInitialState = 2;
            int numberOfPrintsForValidMaxGens = 1;

           var expectedPrints = numberOfGenerations + numberOfPrintsInRunLoop + numberofPrintForGettingGridDems + numberofPrintsInSetUpIntialValues + numberOfPrintsValidateInitialState + numberOfPrintsForValidMaxGens;
           Game game = new Game(ui, displayFormatter, inputConverter, delayer, fileReader);
          ui.AddToQueue("3,3");
          ui.AddToQueue("n");
          ui.AddToQueue("0,0 1,0 1,1 0,1");
          ui.AddToQueue(input);

          game.Run();

           Assert.Equal(expectedPrints, ui.TimesCalled);
       }

        [Fact]
        public void GameQuitsEarlyWhenAllCellsInAGenerationAreDead()
        {
            int numberOfPrintsInRunLoop = 1;
            int numberofPrintForGettingGridDems = 1;
            int numberofPrintsInSetUpIntialValues = 2;
            int numberPrintsAssociatedWithInvalidInputs = 4;
            int numberOfPrintsValidateInitialState = 2;
            int numberOfPrintsForValidMaxGens = 1;
            int numberOfExpectedGameLoopsBeforeEnding = 1;

            var expectedPrints = numberOfPrintsInRunLoop + numberofPrintForGettingGridDems + numberofPrintsInSetUpIntialValues + numberOfPrintsValidateInitialState + numberOfPrintsForValidMaxGens + numberPrintsAssociatedWithInvalidInputs + numberOfExpectedGameLoopsBeforeEnding;
            Game allDead = new Game(ui, displayFormatter, inputConverter, delayer, fileReader);
            ui.AddToQueue("t");
            ui.AddToQueue(" ");
            ui.AddToQueue("5,4");
            ui.AddToQueue("n");
            ui.AddToQueue("1,1");
            ui.AddToQueue("10");

            allDead.Run();

            Assert.Equal(expectedPrints, ui.TimesCalled);
        }

        [Fact]
        public void GridInitialStateCanBeSetByReadingValidDataFromCSVFile()
        {
            var expectedOutput = " . " + " . " + " . " + " . " + " . \n" +
                                 " . " + " . " + " . " + " . " + " . \n" +
                                 " A " + " A " + " A " + " . " + " . \n" +
                                 " . " + " . " + " . " + " . " + " . \n" +
                                 " . " + " . " + " . " + " . " + " . \n" ;

            Game game = new Game(ui, displayFormatter, inputConverter, delayer, fileReader);
            ui.AddToQueue("5,5");
            ui.AddToQueue("y");
            ui.AddToQueue(@"/Users/James.Golding/Desktop/smallOscillator.csv");
            ui.AddToQueue("5");

            game.Run();

            Assert.Equal(expectedOutput, ui.LastString);
        }

        [Fact]
        public void ThrowingAnExceptionReadingFromCSVFileLoopsBackToFilePathInput()
        {
            var expectedOutput = " . " + " . " + " . " + " . " + " . \n" +
                                 " . " + " . " + " . " + " . " + " . \n" +
                                 " A " + " A " + " A " + " . " + " . \n" +
                                 " . " + " . " + " . " + " . " + " . \n" +
                                 " . " + " . " + " . " + " . " + " . \n" ;

            Game game = new Game(ui, displayFormatter, inputConverter, delayer, fileReader);
            ui.AddToQueue("5,5");
            ui.AddToQueue("y");
            ui.AddToQueue(@"/Users/James.Golding/Desktop/smallOscillator1.csv");
            ui.AddToQueue("y");
            ui.AddToQueue(@"/Users/James.Golding/Desktop/smallOscillator.csv");
            ui.AddToQueue("3");

            game.Run();

            Assert.Equal(expectedOutput, ui.LastString);
        }

        
        
    }

    public class StubUI : IUserInterface
    {
        public string LastString{get; private set;}
        private Queue myQ = new Queue();
        public int TimesCalled {get; set;}
        public StubUI()
        {
            TimesCalled = 0;
        }
        public string GetUserInput()
        {
           return (string)myQ.Dequeue();
        }

        public void Print(string output)
        {
            LastString = output;
            TimesCalled++;
        }

        public void AddToQueue(string input)
        {
            myQ.Enqueue(input);
        }

    }


}