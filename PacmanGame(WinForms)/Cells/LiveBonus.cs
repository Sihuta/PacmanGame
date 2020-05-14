using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PacmanGame_WinForms_.Cells
{
    class LiveBonus : Bonus
    {
        public LiveBonus(int x, int y, bool bonus)
            : base(x, y)
        {
            if (bonus)
                Image = Properties.Resources.Heart;
            else
                Image = Properties.Resources.breakHeart;
            Bonus = bonus;
        }

        public bool Bonus { get; set; }

        public override void GetScore()
        {
            if (Bonus)
                Form1.Lives += 1;
            else
                Form1.Lives -= 1;
        }

        //public override void Action()
        //{
        //    base.Action();
        //    if (Bonus)
        //        MessageBox.Show("Extra life!)");
        //    else
        //        MessageBox.Show("Minus life!(");
        //}
    }
}
