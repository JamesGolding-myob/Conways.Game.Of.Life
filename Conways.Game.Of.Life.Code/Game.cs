namespace Conways.Game.Of.Life
{
    public class Game
    {
        private IUI _ui;
        private DisplayFormatter _formatter;
        private InputConverter _inputConverter;
        public Game(IUI ui, DisplayFormatter displayFormatter, InputConverter inputConverter)
        {
            _ui = ui;
            _formatter = displayFormatter;
            _inputConverter = inputConverter;
        }

        public void Run()
        {
            
            var gridSize = _inputConverter.ConvertGridRowsAndColumns(_ui.GetUserInput());
            Grid gameGrid = new Grid(gridSize.Item1, gridSize.Item2);
            _ui.Print(_formatter.GridToString(gameGrid));
        }
    }
}