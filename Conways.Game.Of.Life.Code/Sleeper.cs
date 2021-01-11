using System.Threading;
namespace Conways.Game.Of.Life
{
    public class Sleeper
    {
        private int _sleepTime;
        public Sleeper(int delay = 1000)
        {
            _sleepTime = delay;
        }
        public void delayOutPut()
        {
            Thread.Sleep(_sleepTime);
        }
    }
}