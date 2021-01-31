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
        private Grid _gameGrid;
        private int _generationCounter;
        private int _numberOfGenerations;
        public Game(IUserInterface ui, DisplayFormatter displayFormatter, InputConverter inputConverter, Delayer delayer, FileReader fileReader)
        {
            _ui = ui;
            _formatter = displayFormatter;
            _inputConverter = inputConverter;
           _displayDelayer = delayer;
           _fileReader = fileReader;
           _generationCounter = 0;
        }

        public void Run()
        {
            SetUpGameInitalValues();
            _ui.Print(_formatter.GridToString(_gameGrid));
            SimulateFollowingGenerations();   
        }
        
        private void SetUpGameInitalValues()
        {   
            var gridDimensions = GetGridDimensionsFromUser();
            _gameGrid = new Grid(gridDimensions.NumberOfRows, gridDimensions.NumberOfColumns);
            var blankStartingGrid = _formatter.GridToString(_gameGrid);
            _ui.Print(blankStartingGrid);
            
            LoopUntilValidInitialStateIsSet();
            _ui.Print(_formatter.GridToString(_gameGrid));

            LoopUntilValidMaxGenerationNumber();
        }

        private void SimulateFollowingGenerations()
        {
            while(_generationCounter < _numberOfGenerations )
            {
                _displayDelayer.delayOutPut();
                Console.Clear();
                _gameGrid.ApplyRulesToGrid();
                _ui.Print(_formatter.GridToString(_gameGrid));
                if(_gameGrid.AllCellsDead())
                {
                    break;
                }
                _generationCounter++;
            }
        }

        private void LoopUntilValidInitialStateIsSet()
        {
            bool initialStateSet = false;
            do
            {
                var initalState = GetInitialStateFromUser(); 
                if(initalState.Length > 0)
                {
                    try
                    {
                        _gameGrid.SeedGridState(_inputConverter.ConvertStartingGenerationInputToLocations(initalState));
                        initialStateSet = true;   
                    }
                    catch (FormatException)
                    {  
                        _ui.Print(MessageConstants.InitialGridStateFormatException); 
                    }
                    catch(IndexOutOfRangeException)
                    {
                        _ui.Print(MessageConstants.InitialGridStateOutOfRangeException);
                    }
                }
                else
                {
                    initialStateSet = true;//no live cells set
                }
                
            } while (!initialStateSet);
        }

        private Dimensions GetGridDimensionsFromUser()
        {      
            do
            {   
                try
                {
                    _ui.Print(MessageConstants.GridSizeInstructions);
                    return _inputConverter.ConvertGridRowsAndColumns(_ui.GetUserInput());     
                }
                catch (SystemException)
                {
                    _ui.Print(MessageConstants.RowsColumnsInputErrorMesage);                         
                }
            } while(true);
        }

        private string GetInitialStateFromUser()
        {
            string initalStateResponse;

            _ui.Print(MessageConstants.FileEntryQuestion);
            var userResponse = _ui.GetUserInput();

            if(userResponse == MessageConstants.FileReadInputOptionSelected)
            {
                try
                {
                    _ui.Print(MessageConstants.FileReadInstructions);
                    string[] fileData = _fileReader.ReadInputs(_ui.GetUserInput());

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
                    _ui.Print(MessageConstants.GenericFileReadErrorMessage);
                    initalStateResponse = " ";//invalid initial state to stay in higher loop
                }
            }
            else
            {
                _ui.Print(MessageConstants.StartingStateInstructions);
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
                    _ui.Print(MessageConstants.MaxGenerationInstructions);
                    _numberOfGenerations = _inputConverter.ConvertMaxGenerations(_ui.GetUserInput());
                    break;
                }
                catch (FormatException)
                {
                    _ui.Print(MessageConstants.MaxGenerationFormatException);
                }
                catch(System.Exception)
                {
                    _ui.Print(MessageConstants.GenericErrorMessage);
                }
            } while (true);
        }

    }
}