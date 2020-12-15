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
            var gridDimensions = GetGridSizeFromUser();
            Grid gameGrid = new Grid(gridDimensions.Item1, gridDimensions.Item2);
            _ui.Print(_formatter.GridToString(gameGrid));

            var initalState = _ui.GetUserInput();
            var convertedInitialState = _inputConverter.ConvertStartingGenerationInputToCoordinates(initalState);
            gameGrid.SetInitialGridState(convertedInitialState);
            _ui.Print(_formatter.GridToString(gameGrid));
        }

        private Tuple<int, int> GetGridSizeFromUser()
        {
            _ui.Print(OutputConstants.gridSizeInstructions);
            return _inputConverter.ConvertGridRowsAndColumns(_ui.GetUserInput());
        }
    }
}