using System;
using System.Collections.Generic;
using System.Text;

namespace PacmanGame_WinForms_
{
    class Blinky : Ghost
    {
        private Direction control = Direction.LEFT;
        public int interval = Form1.Interval - 30;

        public override Direction direction
        {
            get { return control; }
            set { control = value; }
        }

        public override int Interval
        {
            get { return interval; }
            set { interval = value; }
        }

        public Blinky(int x, int y)
            : base(x, y)
        {
            Image = Properties.Resources.Blinky_L;
        }

        public override void ChangeDirection()
        {
            switch (direction)
            {
                case Direction.LEFT:
                    if (CheckWall(Y, X - 1))
                    {
                        direction = Direction.RIGHT;
                        Image = Properties.Resources.Blinky_R;
                    }
                    break;
                case Direction.RIGHT:
                    if (CheckWall(Y, X + 1))
                    {
                        direction = Direction.LEFT;
                        Image = Properties.Resources.Blinky_L;
                    }
                    break;
            }
        }

        public override void ChangeImage()
        {
            switch (direction)
            {
                case Direction.LEFT:
                    Image = Properties.Resources.Blinky_L;
                    break;
                case Direction.RIGHT:
                    Image = Properties.Resources.Blinky_R;
                    break;
            }
        }

        public override void ChangeInterval(bool active = true)
        {
            if (active)
            {
                Form1.timer2.Interval = Interval;
            }
            else
                Form1.timer2.Interval = Interval + 20;
        }
    }
}
