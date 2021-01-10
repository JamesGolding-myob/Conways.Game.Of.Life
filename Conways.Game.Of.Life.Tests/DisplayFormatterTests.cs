using Xunit;
using System.Collections.Generic;
namespace Conways.Game.Of.Life
{
    public class DisplayFormatterTests
    {
        DisplayFormatter displayFormatter =  new DisplayFormatter();
        
        [Fact]
        public void NewlyCreated3x3GridCanBeFormattedReadyToBeDisplayed()
        {
            Grid grid = new Grid(3, 3);
            var expectedOutput = " . " + " . " + " . \n" +
                                 " . " + " . " + " . \n" +
                                 " . " + " . " + " . \n" ;

            Assert.Equal(expectedOutput, displayFormatter.GridToString(grid));
        }

        [Fact]
        public void  ZeroZeroCellIsLocatedInBottomLeftCornerAfterFormatting()
        {
            var expectedOutput = " .  .  . \n A  .  . \n";
            Location origin = new Location(0, 0);
            
            List<Location> zeroZeroAliveIntialState = new List<Location>();
            zeroZeroAliveIntialState.Add(origin);

            Grid grid = new Grid(2, 3);

            grid.SetInitialGridState(zeroZeroAliveIntialState);

            Assert.Equal(expectedOutput, displayFormatter.GridToString(grid));
        }
    }
}