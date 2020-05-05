using System;
using System.Collections.Generic;
using System.Text;

namespace PacmanGame_2_
{
    class Clyde : Ghost
    {
        private ConsoleColor color = ConsoleColor.White;
        private Direction control = Direction.DOWN;
        private double interval = Game.Pacman.Interval * 2;

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

        public Clyde(int x, int y)
            : base(x, y)
        {
        }
    }
}
