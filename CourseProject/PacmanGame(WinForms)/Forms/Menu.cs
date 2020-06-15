using PacmanGame_WinForms_.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PacmanGame_WinForms_
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void startGame_MouseUp(object sender, MouseEventArgs e)
        {
            Game Game = new Game();
            Game.Show();
            
        }

        private void help_MouseUp(object sender, MouseEventArgs e)
        {
            Help Help = new Help();
            Help.ShowDialog();
        }

        private void exit_MouseUp(object sender, MouseEventArgs e)
        {
            Application.Exit();
        }

        private void settings_MouseUp(object sender, MouseEventArgs e)
        {
            Program.Set = new Settings();
            Program.Set.ShowDialog();
        }

        private void resultBtn_Click(object sender, EventArgs e)
        {
            Results res = new Results();
            res.Show();
        }
    }
}