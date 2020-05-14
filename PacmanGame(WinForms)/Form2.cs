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

        //private void button1_MouseHover(object sender, EventArgs e)
        //{
        //    button1.BackColor = Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
        //}

        private void button1_MouseDown(object sender, MouseEventArgs e)
        {
            button1.BackColor = Color.Green;
            button1.ForeColor = Color.Lime;
        }

        private void button1_MouseUp(object sender, MouseEventArgs e)
        {
            //Hide();
            Form1 Game = new Form1();
            Game.Show();
            
        }

        private void button1_MouseMove(object sender, MouseEventArgs e)
        {
            button1.BackColor = Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = Color.Lime;
        }

        private void button2_MouseEnter(object sender, EventArgs e)
        {
            button2.BackColor = Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.BackColor = Color.Lime;
        }

        private void button2_MouseDown(object sender, MouseEventArgs e)
        {
            button2.BackColor = Color.Green;
            button2.ForeColor = Color.Lime;
        }

        private void button2_MouseUp(object sender, MouseEventArgs e)
        {
            Help Help = new Help();
            Help.ShowDialog();
        }

        private void button4_MouseDown(object sender, MouseEventArgs e)
        {
            button4.BackColor = Color.Green;
            button4.ForeColor = Color.Lime;
        }

        private void button4_MouseUp(object sender, MouseEventArgs e)
        {
            Close();
        }

        private void button4_MouseEnter(object sender, EventArgs e)
        {
            button4.BackColor = Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
        }

        private void button4_MouseLeave(object sender, EventArgs e)
        {
            button4.BackColor = Color.Lime;
        }

        private void button3_MouseDown(object sender, MouseEventArgs e)
        {
            button3.BackColor = Color.Green;
            button3.ForeColor = Color.Lime;
        }

        private void button3_MouseEnter(object sender, EventArgs e)
        {
            button3.BackColor = Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            button3.BackColor = Color.Lime;
        }

        private void button3_MouseUp(object sender, MouseEventArgs e)
        {
            Program.Set = new Settings();
            Program.Set.ShowDialog();
        }
    }
}
