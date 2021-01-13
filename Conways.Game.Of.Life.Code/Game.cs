using System;
namespace Conways.Game.Of.Life
{
    public class Game
    {
        private IUserInterface _ui;
        private DisplayFormatter _formatter;
        private InputConverter _inputConverter;
        public Game(IUserInterface ui, DisplayFormatter displayFormatter, InputConverter inputConverter)
        {
            _ui = ui;
            _formatter = displayFormatter;
            _inputConverter = inputConverter;
        }

        public void Run()
        {
            _ui.Print(OutputConstants.gridSizeInstructions);
            var rowColumnInputFromUser = _ui.GetUserInput();
            (int row, int column) = _inputConverter.ConvertGridRowsAndColumns(rowColumnInputFromUser);

            Grid gameGrid = new Grid(row, column);
            var emptyStartingGrid = _formatter.GridToString(gameGrid);
            _ui.Print(emptyStartingGrid);

            _ui.Print(OutputConstants.startingStateInstructions);
            var initalState = _ui.GetUserInput();
            var convertedInitialState = _inputConverter.ConvertStartingGenerationInputToCoordinates(initalState);
            gameGrid.SetInitialGridState(convertedInitialState);
            _ui.Print(_formatter.GridToString(gameGrid));

           gameGrid.ApplyRulesToGrid();
            
            _ui.Print(_formatter.GridToString(gameGrid));
        }

    }
}