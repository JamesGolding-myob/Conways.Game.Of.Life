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
        public const string initialGridStateOutOfRangeException = "Please enter two numbers seperated by a comma.";
        public const string initialGridStateFormatException = "Input not in a correct format. Please input pairs of numbers seperated by a comma. eg 0,0 1,2";
        public const string maxGenerationFormatException = "Please enter a number greater than zero.";
    }
}