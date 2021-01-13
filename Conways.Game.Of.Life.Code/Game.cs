using System;

namespace Conways.Game.Of.Life
{
    public class Game
    {

        private IUserInterface _ui;
        private DisplayFormatter _formatter;
        private InputConverter _inputConverter;
        private Delayer _displayDelayer;
        private int _counter;
        private Grid _gameGrid;
        private int _numberOfGenerations;
        public Game(IUserInterface ui, DisplayFormatter displayFormatter, InputConverter inputConverter, Delayer delayer)
        {
            _ui = ui;
            _formatter = displayFormatter;
            _inputConverter = inputConverter;
           _displayDelayer = delayer;
           _counter = 0;
        }

        public void Run()
        {
            SetUpGameInitalValues();

            _ui.Print(_formatter.GridToString(_gameGrid));
            while(_counter < _numberOfGenerations )
            {
                _displayDelayer.delayOutPut();
                Console.Clear();
                _gameGrid.ApplyRulesToGrid();
                _ui.Print(_formatter.GridToString(_gameGrid));
                if(_gameGrid.AllCellsDead())
                {
                    break;
                }
                _counter++;
            }
        }

        private void SetUpGameInitalValues()
        {   
            var gridDimensions = GetGridDimensionsFromUser();
             _gameGrid = new Grid(gridDimensions.NumberOfRows, gridDimensions.NumberOfColumns);
            var emptyStartingGrid = _formatter.GridToString(_gameGrid);
            _ui.Print(emptyStartingGrid);

            var initalState = GetInitialStateFromUser(); 
             if(initalState.Length > 0)
            {
                _gameGrid.SetInitialGridState(_inputConverter.ConvertStartingGenerationInputToCoordinates(initalState));
            }
            _ui.Print(_formatter.GridToString(_gameGrid));

            _ui.Print(OutputConstants.maxGenerationInstructions);
            _numberOfGenerations = _inputConverter.ConvertMaxGenerations(_ui.GetUserInput());

        }

        private Dimensions GetGridDimensionsFromUser()//should be dimension
        {
            
            Dimensions output;
            string rowColumnInputFromUser; 
            
            while(true)
            {   
                try
                {
                    _ui.Print(OutputConstants.gridSizeInstructions);
                    rowColumnInputFromUser = _ui.GetUserInput();
                    output = _inputConverter.ConvertGridRowsAndColumns(rowColumnInputFromUser);  
                    break; 
                }
                catch (SystemException)
                {
                    _ui.Print("Error please enter rows and columns agian");                    
                    
                }
            } 

            return output;
        }

        private string GetInitialStateFromUser()
        {
            _ui.Print(OutputConstants.startingStateInstructions);
            return _ui.GetUserInput();

            
        }

    }
}