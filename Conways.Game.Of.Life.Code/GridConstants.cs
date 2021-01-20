namespace Conways.Game.Of.Life
{
    public static class GridConstants
    {
        public const bool Alive = true;
        public const bool Dead = false;
        public const int NeighbourLimitToBecomeAlive = 3;
        public const int NeighbourLimitForOverPopulation = 3;
        public const int NeighbourLimitForUnderPopulation = 2;
        public const int SmallestGridDimension = 2;
    }
}