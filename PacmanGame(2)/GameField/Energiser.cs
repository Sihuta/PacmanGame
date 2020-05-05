using System;
using System.Collections.Generic;
using System.Text;

namespace PacmanGame_2_
{
    class Energiser : BasePoint
    {
        private ConsoleColor color = ConsoleColor.Green;
        private char ch = '@';

        public override ConsoleColor Color
        {
            get { return color; }
            set { color = value; }
        }

        public override char Ch
        {
            get { return ch; }
            set { ch = value; }
        }

        public Energiser(int x, int y)
            : base(x, y)
        {
        }

        public DateTime time { get; set; }

        public Energiser(int x, int y, int time_stop)
             : base(x, y)
        {
            time = SetTimeToChange(time_stop);
        }

        public bool ReadyToStop(DateTime timeToChange)
        {
            int differenceTime = DateTime.Compare(timeToChange, DateTime.Now);
            if (differenceTime <= 0)
            {
                return true;
            }
            return false;
        }

        //Добавить времени для задержки
        DateTime SetTimeToChange(double milliseconds)
        {
            DateTime time = DateTime.Now;
            return time.AddMilliseconds(milliseconds);
        }
    }
}
