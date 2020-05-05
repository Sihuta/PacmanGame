using System;
using System.Collections.Generic;
using System.Text;

namespace PacmanGame_2_
{
    class Pinky : Ghost
    {
        private ConsoleColor color = ConsoleColor.Magenta;
        private Direction control = Direction.RIGHT;
        private double interval = Game.Pacman.Interval;

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

        public Pinky(int x, int y)
            : base(x, y)
        {
        }
    }
}
