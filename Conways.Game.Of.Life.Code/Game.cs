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
            var gridSize = GetGridSizeFromUser();
            Grid gameGrid = new Grid(gridSize.Item1, gridSize.Item2);
            _ui.Print(_formatter.GridToString(gameGrid));
        }

        private Tuple<int, int> GetGridSizeFromUser()
        {
            _ui.Print(OutputConstants.gridSizeInstructions);
            return _inputConverter.ConvertGridRowsAndColumns(_ui.GetUserInput());
        }
    }
}