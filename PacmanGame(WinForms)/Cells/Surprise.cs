using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacmanGame_WinForms_.Cells
{
    class Surprise : Bonus
    {
        public Surprise(int x, int y)
            : base(x, y)
        {
            Image = Properties.Resources.Surprise;
        }

        public override void GetScore()
        {
            Random run = new Random();
            int num = run.Next(1, 6);

            switch(num % 2)
            {
                case 1:
                    Form1.min -= 10;
                    break;
                case 0:
                    if (num == 2)
                    {
                        Form1.Lives -= 1;
                    }
                    else if (num == 4)
                    {
                        Form1.Score *= 2;
                    }
                    break;
                default:
                    Form1.min -= 10;
                    break;
            }
        }
    }
}
