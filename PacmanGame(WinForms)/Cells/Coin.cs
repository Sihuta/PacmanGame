using PacmanGame_WinForms_;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace PacmanGame_WinForms_
{
    class Coin : BasePoint
    {
        public Coin(int x, int y)
            : base(x, y)
        {
            Image = Properties.Resources.Coin;
        }

        public override bool Action()
        {
            GetScore();
            Image = Properties.Resources.Empty;
            Form1.Field[Y, X] = new EmptyPoint(X, Y);

            return true;
        }

        public override void GetScore()
        {
            Field.countCoins -= 1;
            Form1.Score += 10;
        }
    }
}
