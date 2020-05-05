using System;
using System.Collections.Generic;
using System.Text;

namespace PacmanGame_2_
{
    class Inky : Ghost
    {
        private ConsoleColor color = ConsoleColor.Cyan;
        private Direction control = Direction.UP;
        private double interval = Game.Pacman.Interval * 1.5;

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

        public Inky(int x, int y)
            : base(x, y)
        {
        }
    }
}
