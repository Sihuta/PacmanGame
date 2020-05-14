using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace PacmanGame_WinForms_
{
    public abstract class Ghost : BasePoint
    {
        public Ghost(int x, int y)
            : base(x, y)
        {
            respaunX = x;
            respaunY = y;
        }

        public abstract Direction direction { get; set; }
        public abstract int Interval { get; set; }

        public int ReadyRespaun = 10;
        public int Wait = 0;
        private int respaunX;
        private int respaunY;

        public bool passive = false;
        public bool isEmpty = false;
        public bool pacmanHit = false;

        public void Respaun()
        {
            Wait = 0;
            X = respaunX;
            Y = respaunY;
            isEmpty = false;
        }

        public override void GetScore()
        {
            if (!passive)
                --Form1.Lives;
            else
                Form1.Score += 100;
        }

        public override bool Action()
        {
            if (!passive)
                GetScore();
            else
            {
                GetScore();
                Image = Properties.Resources.Empty;
                isEmpty = true;
                X = 3;
                Y = 3;
                // = new EmptyPoint(Form1.Pacman.X, Form1.Pacman.Y);
            }
            return true;
        }

        public void PacmanHit()
        {
            if (X == Form1.Pacman.X && Y == Form1.Pacman.Y && !Form1.Pacman.ghostHit)
            {
                Action();
                pacmanHit = true;
            }
        }

        public void EnergizerActive()
        { 
            if (Form1.Energisers.Count > 0)
            {
                Image = Properties.Resources.GrayGhost;
                passive = true;
                ChangeInterval(false);
            }
            else
            {
                if (!isEmpty)
                {
                    passive = false;
                    ChangeImage();
                    ChangeInterval(true);
                }
            }

            for (int i = 0; i < Form1.Energisers.Count; ++i)
            {
                if (Form1.Energisers[i].ReadyToStop(Form1.Energisers[i].time))
                {
                    Form1.Energisers.RemoveAt(i);
                }
            }
        }

        public abstract void ChangeInterval(bool active);
        public abstract void ChangeImage();

        public void Move()
        {
            if (!isEmpty)
            {
                PacmanHit();
                ChangeDirection();
                GetNextPoint();
                if (!pacmanHit && !Form1.Pacman.ghostHit)
                {
                    PacmanHit();
                    pacmanHit = false;
                }
            }
            //Form1.UpdatePanel(Form1.Field[Y, X], true);
        }

        public abstract void ChangeDirection();

        public void GetNextPoint()
        {
            switch (direction)
            {
                case Direction.LEFT:
                    X -= 1;
                    break;
                case Direction.RIGHT:
                    X += 1;
                    break;
                case Direction.UP:
                    Y -= 1;
                    break;
                case Direction.DOWN:
                    Y += 1;
                    break;
            }
        }

        public bool CheckWall(int y, int x)
        {
            var matrix = Form1.Field;
            if (y < matrix.Rows && x < matrix.Columns)
            {
                if (matrix[y, x] is Wall)
                {
                    return true;
                }
            }
            return false;
        }
    }  
}
