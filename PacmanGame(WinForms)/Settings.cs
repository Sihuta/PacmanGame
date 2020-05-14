using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PacmanGame_WinForms_
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
        }

        private void Settings_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Home)
            {
                Program.Menu.button3.BackColor = Color.Lime;
                Program.Menu.button3.ForeColor = SystemColors.ControlText;
                Close();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Program.Name = textBox1.Text;
            textBox1.Enabled = false;
            Enabled = true;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            Form1.Interval = 150;
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            Form1.Interval = 100;
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            Form1.Interval = 70;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            Sounds.sound = new SoundPlayer(Properties.Resources.game1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Program.Menu.button3.BackColor = Color.Lime;
            Program.Menu.button3.ForeColor = SystemColors.ControlText;
            Close();
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            Sounds.SoundOff();
        }
    }
}
