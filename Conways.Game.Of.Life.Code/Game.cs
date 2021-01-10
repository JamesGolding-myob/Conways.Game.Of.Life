using System.Threading;
using System;
namespace Conways.Game.Of.Life
{
    public class Game
    {
        private const int _SleepTime = 1000;
        private IUserInterface _ui;
        private DisplayFormatter _formatter;
        private InputConverter _inputConverter;
        private int _numberOfTicks;
        public Game(IUserInterface ui, DisplayFormatter displayFormatter, InputConverter inputConverter)
        {
            _ui = ui;
            _formatter = displayFormatter;
            _inputConverter = inputConverter;
           
        }

        public void Run()
        {
            var counter = 0;
            _ui.Print(OutputConstants.gridSizeInstructions);
            var rowColumnInputFromUser = _ui.GetUserInput();
            var gridDimensions = _inputConverter.ConvertGridRowsAndColumns(rowColumnInputFromUser);

            Grid gameGrid = new Grid(gridDimensions.Row, gridDimensions.Column);
            var emptyStartingGrid = _formatter.GridToString(gameGrid);
            _ui.Print(emptyStartingGrid);

            _ui.Print(OutputConstants.startingStateInstructions);
            var initalState = _ui.GetUserInput();
            var convertedInitialState = _inputConverter.ConvertStartingGenerationInputToCoordinates(initalState);
            gameGrid.SetInitialGridState(convertedInitialState);
            _ui.Print(_formatter.GridToString(gameGrid));

            _ui.Print(OutputConstants.maxGenerationInstructions);
            _numberOfTicks = _inputConverter.ConvertMaxGenerations(_ui.GetUserInput());
            while(counter < _numberOfTicks )
            {
                Thread.Sleep(_SleepTime);
                Console.Clear();
                gameGrid.ApplyRulesToGrid();
                _ui.Print(_formatter.GridToString(gameGrid));
                  
                counter++;
            }
        }

    }
}