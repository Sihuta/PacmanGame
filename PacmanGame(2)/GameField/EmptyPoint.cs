﻿using System;
using System.Collections.Generic;
using System.Text;

namespace PacmanGame_2_
{
    class EmptyPoint : BasePoint
    {
        private ConsoleColor color = ConsoleColor.Black;
        private char ch = ' ';

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

        public EmptyPoint(int x, int y)
            : base(x, y)
        {
        }
    }
}
