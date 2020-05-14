using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace PacmanGame_WinForms_
{
    public abstract class BasePoint
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Image Image { get; set; }

        public int Width = 50;
        public int Height = 50;

        public BasePoint(int x, int y)
        {

            X = x;
            Y = y;
        }

        public virtual void GetScore()
        {
            Form1.Score += 10;
        }

        public virtual bool Action()
        {
            //GetScore();
            return true;
        }
    }
}
