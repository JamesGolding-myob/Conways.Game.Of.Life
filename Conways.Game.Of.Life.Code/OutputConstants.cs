namespace Conways.Game.Of.Life
{
    public static class OutputConstants
    {
        public static string gridSizeInstructions = "Please enter the number of rows and columns (eg, 3,4)";
        public static string startingStateInstructions = "Please enter the location (row,column) for any cells you wish to begin alive eg(1,2 3,4 0,0)";
        public static string maxGenerationInstructions = "Please enter the maximum number of generations you would like to see (eg. 3)";

        public static string rowsColumnsInputErrorMesage = "Error please enter rows and columns again";
        public static string rowsColumnsFormatExceptionMessage = "Input not in a correct format. Please use format: row,column";
        public static string gridDimensionOutOfRangeExceptionMessage = "Please enter two numbers seperated by a comma.";
    }
}