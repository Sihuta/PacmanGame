using System;
using System.Collections.Generic;
using System.Text;

namespace PacmanGame_2_
{
    class Blinky : Ghost
    {
        private ConsoleColor color = ConsoleColor.Red;
        private Direction control = Direction.LEFT;
        private double interval = Game.Pacman.Interval * 0.7;

        public override ConsoleColor Color
        {
            get { return color; }
            set { color = value; }
        }

        public override Direction direction
        {
            get { return control; }
            set { control = value; }
        }

        public override double Interval
        {
            get { return interval; }
            set { interval = value; }
        }

        public Blinky(int x, int y)
            : base(x, y)
        {
        }
    }
}
