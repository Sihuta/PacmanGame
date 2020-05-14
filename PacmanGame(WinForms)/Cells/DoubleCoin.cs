using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PacmanGame_WinForms_.Cells
{
    class DoubleCoin : Bonus
    {
        public DoubleCoin(int x, int y, bool multipl)
            : base(x, y)
        {
            if (multipl)
                Image = Properties.Resources.MultiplCoin;
            else
                Image = Properties.Resources.AddCoin;
            Multipl = multipl;
        }

        public bool Multipl { get; set; }

        public override void GetScore()
        {
            if (Multipl)
                Form1.Score *= 2;
            else
                Form1.Score += 500;
        }

        //public override void Action()
        //{
        //    base.Action();
        //    if (Multipl)
        //        MessageBox.Show("Your score doubles!)");
        //    else
        //        MessageBox.Show("Plus 500 coins!)");
        //}
    }
}
