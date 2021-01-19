using System;

namespace Conways.Game.Of.Life
{
    public class Game
    {

        private IUserInterface _ui;
        private DisplayFormatter _formatter;
        private InputConverter _inputConverter;
        private Delayer _displayDelayer;
        private FileReader _fileReader;
        private int _counter;
        private Grid _gameGrid;
        private int _numberOfGenerations;
        public Game(IUserInterface ui, DisplayFormatter displayFormatter, InputConverter inputConverter, Delayer delayer, FileReader fileReader)
        {
            _ui = ui;
            _formatter = displayFormatter;
            _inputConverter = inputConverter;
           _displayDelayer = delayer;
           _fileReader = fileReader;
           _counter = 0;
        }

        public void Run()
        {
            SetUpGameInitalValues();

            _ui.Print(_formatter.GridToString(_gameGrid));
            SimulateFollowingGenerations();   
        }

        private void SimulateFollowingGenerations()
        {
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
            
            LoopUntilValidInitialStateIsSet();

            _ui.Print(_formatter.GridToString(_gameGrid));

            LoopUntilValidMaxGenerationNumber();
        }

        private void LoopUntilValidInitialStateIsSet()
        {
            bool inputIsValid = false;
            do
            {
                var initalState = GetInitialStateFromUser(); 
                if(initalState.Length > 0)
                {
                    try
                    {
                        _gameGrid.SeedInitialGridState(_inputConverter.ConvertStartingGenerationInputToCoordinates(initalState));
                        inputIsValid = true;   
                    }
                    catch (FormatException)
                    {  
                        _ui.Print(OutputConstants.initialGridStateFormatException); 
                    }
                    catch(IndexOutOfRangeException)
                    {
                        _ui.Print(OutputConstants.initialGridStateOutOfRangeException);
                    }
                }
                else
                {
                    inputIsValid = true;
                }
                
            } while (!inputIsValid);
        }

        private Dimensions GetGridDimensionsFromUser()
        {      
            string rowColumnInputFromUser; 
            do
            {   
                try
                {
                    _ui.Print(OutputConstants.gridSizeInstructions);
                    rowColumnInputFromUser = _ui.GetUserInput();
                    return _inputConverter.ConvertGridRowsAndColumns(rowColumnInputFromUser);     
                }
                catch (SystemException)
                {
                    _ui.Print(OutputConstants.rowsColumnsInputErrorMesage);                         
                }
            } while(true);
        }

        private string GetInitialStateFromUser()
        {
            string initalStateResponse;

            _ui.Print(OutputConstants.fileEntryQuestion);
            var userResponse = _ui.GetUserInput();

            if(userResponse == "y")
            {
                try
                {
                    _ui.Print(@"Please enter file path (e.g /Users/Desktop/smallOscillator.csv");
                    var filePath = _ui.GetUserInput();
                    string[] fileData = _fileReader.ReadInputs(filePath);

                    string entriesFromFile = "";
                    int lastEntry = fileData.Length - 1;

                    for(int fileEntry = 0; fileEntry <= lastEntry; fileEntry++)
                    {
                        if(fileEntry == lastEntry)
                        {
                            entriesFromFile = entriesFromFile + fileData[fileEntry];
                        }
                        else
                        {
                            entriesFromFile = entriesFromFile + fileData[fileEntry] + " ";
                        }
                    }
                    initalStateResponse = entriesFromFile;
                    
                }
                catch(System.Exception)
                {
                    _ui.Print(OutputConstants.genericFileReadErrorMessage);
                    initalStateResponse = " ";
                }
            }
            else
            {
                _ui.Print(OutputConstants.startingStateInstructions);
                initalStateResponse = _ui.GetUserInput();
            }
            return initalStateResponse;      
        }

        private void LoopUntilValidMaxGenerationNumber()
        {
            do
            {
                try
                {
                    _ui.Print(OutputConstants.maxGenerationInstructions);
                    _numberOfGenerations = _inputConverter.ConvertMaxGenerations(_ui.GetUserInput());
                    break;
                }
                catch (FormatException)
                {
                    _ui.Print(OutputConstants.maxGenerationFormatException);
                }
                catch(System.Exception)
                {
                    _ui.Print(OutputConstants.genericErrorMessage);
                }
            } while (true);
        }

    }
}