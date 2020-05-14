using System;
using System.Collections.Generic;
using System.Text;

namespace PacmanGame_WinForms_
{
    class Pinky : Ghost
    {
        private Direction control = Direction.RIGHT;
        private int interval = Form1.Interval;
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

        public Pinky(int x, int y)
            : base(x, y)
        {
            Image = Properties.Resources.Pinky_R;
        }

        public override void ChangeImage()
        {
            switch(direction)
            {
                case Direction.LEFT:
                    Image = Properties.Resources.Pinky_L;
                    break;
                case Direction.RIGHT:
                    Image = Properties.Resources.Pinky_R;
                    break;
            }
        }

        public override void ChangeDirection()
        {
            switch (direction)
            {
                case Direction.LEFT:
                    if (CheckWall(Y, X - 1))
                    {
                        direction = Direction.RIGHT;
                        Image = Properties.Resources.Pinky_R;
                    }
                    break;
                case Direction.RIGHT:
                    if (CheckWall(Y, X + 1))
                    {
                        direction = Direction.LEFT;
                        Image = Properties.Resources.Pinky_L;
                    }
                    break;
            }
        }

        public override void ChangeInterval(bool active = true)
        {
            if (active)
            {
                Form1.timer5.Interval = Interval;
            }
            else
                Form1.timer5.Interval = Interval + 20;
        }
    }
}
