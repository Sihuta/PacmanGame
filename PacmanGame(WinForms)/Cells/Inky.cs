using System;
using System.Collections.Generic;
using System.Text;

namespace PacmanGame_WinForms_
{
    class Inky : Ghost
    {
        private Direction control = Direction.UP;
        private int interval = Form1.Interval + 50;

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

        public Inky(int x, int y)
            : base(x, y)
        {
            Image = Properties.Resources.Inky_UP;
        }

        public override void ChangeDirection()
        {
            switch (direction)
            {
                case Direction.UP:
                    if (CheckWall(Y - 1, X))
                    {
                        direction = Direction.DOWN;
                        Image = Properties.Resources.Inky_D;
                    }
                    break;
                case Direction.DOWN:
                    if (CheckWall(Y + 1, X))
                    {
                        direction = Direction.UP;
                        Image = Properties.Resources.Inky_UP;
                    }
                    break;
            }
        }

        public override void ChangeImage()
        {
            switch (direction)
            {
                case Direction.UP:
                    Image = Properties.Resources.Inky_UP;
                    break;
                case Direction.DOWN:
                    Image = Properties.Resources.Inky_D;
                    break;
            }
        }

        public override void ChangeInterval(bool active)
        {
            if (active)
            {
                Form1.timer4.Interval = Interval;
            }
            else
                Form1.timer4.Interval = Interval + 20;
        }
    }
}
