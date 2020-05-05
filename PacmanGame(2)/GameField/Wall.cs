using System;
using System.Collections.Generic;
using System.Text;

namespace PacmanGame_2_
{
    class Wall : BasePoint
    {
        private ConsoleColor color = ConsoleColor.Blue;
        private char ch = '#';

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

        public Wall(int x, int y)
            : base(x, y)
        {
        }
    }
}
