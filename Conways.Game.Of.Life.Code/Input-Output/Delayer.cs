using System.Threading;
namespace Conways.Game.Of.Life
{
    public class Delayer
    {
        private int _sleepTime;
        public Delayer(int milliSecDelay = 1000)
        {
            _sleepTime = milliSecDelay;
        }
        public void delayOutPut()
        {
            Thread.Sleep(_sleepTime);
        }
    }
}