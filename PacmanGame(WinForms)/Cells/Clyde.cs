using System;
using System.Collections.Generic;
using System.Text;

namespace PacmanGame_WinForms_
{
    class Clyde : Ghost
    {
        private Direction control = Direction.DOWN;
        private int interval = Form1.Interval + 100;

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

        public Clyde(int x, int y)
            : base(x, y)
        {
            Image = Properties.Resources.Clyde_D;
        }

        public override void ChangeDirection()
        {
            switch (direction)
            {
                case Direction.UP:
                    if (CheckWall(Y - 1, X))
                    {
                        direction = Direction.DOWN;
                        Image = Properties.Resources.Clyde_D;
                    }
                    break;
                case Direction.DOWN:
                    if (CheckWall(Y + 1, X))
                    {
                        direction = Direction.UP;
                        Image = Properties.Resources.Clyde_UP;
                    }
                    break;
            }
        }

        public override void ChangeImage()
        {
            switch (direction)
            {
                case Direction.UP:
                    Image = Properties.Resources.Clyde_UP;
                    break;
                case Direction.DOWN:
                    Image = Properties.Resources.Clyde_D;
                    break;
            }
        }

        public override void ChangeInterval(bool active = true)
        {
            if (active)
            {
                Form1.timer3.Interval = Interval;
            }
            else
                Form1.timer3.Interval = Interval + 20;
        }
    }
}
