using System;
using System.Collections.Generic;
using System.Text;

namespace PacmanGame_WinForms_
{
    public class Energiser : BasePoint
    {
        public Energiser(int x, int y)
            : base(x, y)
        {
            Image = Properties.Resources.Energizer;
        }

        public DateTime time { get; set; }

        public Energiser(int x, int y, int time_stop)
             : base(x, y)
        {
            time = SetTimeToChange(time_stop);
        }

        public override bool Action()
        {
            GetScore();
            Image = Properties.Resources.Empty;
            Form1.Field[Y, X] = new EmptyPoint(X, Y);

            return true;
        }

        public override void GetScore()
        {
            Form1.Score += 50;
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
