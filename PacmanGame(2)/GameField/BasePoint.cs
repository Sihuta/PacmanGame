using System;
using System.Collections.Generic;
using System.Text;

namespace PacmanGame_2_
{
    abstract class BasePoint
    {
        public int X { get; set; }
        public int Y { get; set; }
        public abstract ConsoleColor Color { get; set; }
        public abstract char Ch { get; set; }

        public BasePoint(int x, int y)
        {
            X = x;
            Y = y;
        }

        public void Draw()
        {
            Console.SetCursorPosition(X, Y);
            Console.ForegroundColor = Color;
            Console.Write(Ch);
        }

        public void Clear()
        {
            Console.SetCursorPosition(X, Y);
            Console.Write(" ");
        }
    }
}
