namespace Conways.Game.Of.Life
{
    public static class MessageConstants
    {
        public const string GridSizeInstructions = "Please enter the number of rows and columns (eg, 3,4)";
        public const string StartingStateInstructions = "Please enter the location (row,column) for any cells you wish to begin alive eg(1,2 3,4 0,0)";
        public const string MaxGenerationInstructions = "Please enter the maximum number of generations you would like to see (eg. 3)";
        public const string RowsColumnsInputErrorMesage = "Error please enter rows and columns again";
        public const string RowsColumnsFormatExceptionMessage = "Input not in a correct format. Please use format: row,column";
        public const string GridDimensionOutOfRangeExceptionMessage = "Please enter two numbers seperated by a comma.";
        public const string InitialGridStateOutOfRangeException = "Please enter number pairs seperated by a comma. - index out of range";
        public const string InitialGridStateFormatException = "Input not in a correct format. Please input pairs of numbers seperated by a comma. eg 0,0 1,2";
        public const string MaxGenerationFormatException = "Please enter a number greater than zero.";
        public const string FileEntryQuestion = "File entry y/n?";
        public const string DirectoryExceptionMessage = "Could not find directory";
        public const string FileNotFoundExceptionMessage = "Could not find file";

        public const string  GenericErrorMessage = "Error";
        public const string GenericFileReadErrorMessage = "File Read Error";
        public const string FileReadInstructions = @"Please enter file path (e.g /Users/Desktop/smallOscillator.csv";
        public const string FileReadInputOptionSelected = "y";
    }
}