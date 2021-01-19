namespace Conways.Game.Of.Life
{
    public static class OutputConstants
    {
        public const string gridSizeInstructions = "Please enter the number of rows and columns (eg, 3,4)";
        public const string startingStateInstructions = "Please enter the location (row,column) for any cells you wish to begin alive eg(1,2 3,4 0,0)";
        public const string maxGenerationInstructions = "Please enter the maximum number of generations you would like to see (eg. 3)";
        public const string rowsColumnsInputErrorMesage = "Error please enter rows and columns again";
        public const string rowsColumnsFormatExceptionMessage = "Input not in a correct format. Please use format: row,column";
        public const string gridDimensionOutOfRangeExceptionMessage = "Please enter two numbers seperated by a comma.";
        public const string initialGridStateOutOfRangeException = "Please enter number pairs seperated by a comma. - index out of range";
        public const string initialGridStateFormatException = "Input not in a correct format. Please input pairs of numbers seperated by a comma. eg 0,0 1,2";
        public const string maxGenerationFormatException = "Please enter a number greater than zero.";
        public const string fileEntryQuestion = "File entry y/n?";
        public const string directoryExceptionMessage = "Could not find directory";
        public const string fileNotFoundExceptionMessage = "Could not find file";

        public const string  genericErrorMessage = "Error";
        public const string genericFileReadErrorMessage = "File Read Error";
    }
}