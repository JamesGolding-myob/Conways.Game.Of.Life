using Xunit;
using System;
using System.Collections.Generic;
namespace Conways.Game.Of.Life
{
    public class DisplayFormatterTests
    {
        DisplayFormatter displayFormatter =  new DisplayFormatter();
        
        [Fact]
        public void  ZeroZeroCellIsLocatedInBottomLeftCornerAfterFormatting()
        {
            var expectedOutput = " .  .  . \n A  .  . \n";
            List<Tuple<int, int>> zeroZeroAliveIntialState = new List<Tuple<int, int>>();
            zeroZeroAliveIntialState.Add(Tuple.Create(0,0));

            Grid grid = new Grid(2, 3);

            grid.SetInitialGridState(zeroZeroAliveIntialState);

            Assert.Equal(expectedOutput, displayFormatter.GridToString(grid));
        }
    }
}