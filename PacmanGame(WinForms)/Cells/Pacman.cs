using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace PacmanGame_WinForms_
{
    public class Pacman : BasePoint
    {
        public Pacman(int x, int y)
            : base(x, y)
        {
            Image = Form1.Pacman_r;           
        }

        private Direction direction = Direction.UP;
        private Direction next_direction = 0;
        //public int Steps = 0;

        public DateTime Time { get; set; }
        public bool ghostHit = false;

        public void Move()
        {
            ghostHit = false;
            if (CheckPoint(next_direction))
            {
                GetNextPoint(next_direction);
                ++Form1.Steps;

                direction = next_direction;
                next_direction = 0;

                
            }

            if (CheckPoint(direction) && direction != next_direction)
            {
                GetNextPoint(direction);
                ++Form1.Steps;

                
            }

            for (int i = 0; i < 4; ++i)
            {
                if (X == Form1.Ghosts[i].X && Y == Form1.Ghosts[i].Y && !Form1.Ghosts[i].pacmanHit)
                {
                    Form1.Ghosts[i].pacmanHit = false;
                    ghostHit = true;
                    Form1.Ghosts[i].Action();
                    Form1.UpdateEnemy(Form1.Ghosts[i], i, true);
                    Form1.UpdateInfo();
                }
            }
        }

        private void ChangeImage(Direction direction)
        {
            switch (direction)
            {
                case Direction.RIGHT:
                    Image = Properties.Resources.Pacman_R;
                    break;
                case Direction.LEFT:
                    Image = Properties.Resources.Pacman_L;
                    break;
                case Direction.DOWN:
                    Image = Properties.Resources.Pacman_D;
                    break;
                case Direction.UP:
                    Image = Properties.Resources.Pacman_UP;
                    break;
            }
        }

        public bool tor_ability = false;

        internal void GetNextPoint(Direction direction)
        {
            switch (direction)
            {
                case Direction.LEFT:
                    if (tor_ability)
                    {
                        X = 27;
                        tor_ability = false;
                    }
                    else
                        X -= 1;
                    break;
                case Direction.RIGHT:
                    if (tor_ability)
                    {
                        X = 0;
                        tor_ability = false;
                    }
                    else
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

        public void ChangeDirection(KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Right:
                    if (CheckPoint(Direction.RIGHT))
                    {
                        direction = Direction.RIGHT;
                    }
                    else
                        next_direction = Direction.RIGHT;
                    break;
                case Keys.Left:
                    if (CheckPoint(Direction.LEFT))
                    {
                        direction = Direction.LEFT;
                    }
                    else
                        next_direction = Direction.LEFT;
                    break;
                case Keys.Down:
                    if (CheckPoint(Direction.DOWN))
                    {
                        direction = Direction.DOWN;
                    }
                    else
                        next_direction = Direction.DOWN;
                    break;
                case Keys.Up:
                    if (CheckPoint(Direction.UP))
                    {
                        direction = Direction.UP;
                    }
                    else
                        next_direction = Direction.UP;
                    break;
            }
            ChangeImage(direction);
        }

        private bool CheckPoint(Direction direction)
        {
            switch (direction)
            {
                case Direction.LEFT:
                    if (CheckPoint(Y, X - 1)) 
                    {
                        ChangeImage(direction);
                        return true; 
                    }
                    break;
                case Direction.RIGHT:
                    if (CheckPoint(Y, X + 1))
                    {
                        ChangeImage(direction);
                        return true;
                    }
                    break;
                case Direction.UP:
                    if (CheckPoint(Y - 1, X))
                    {
                        ChangeImage(direction);
                        return true;
                    }
                    break;
                case Direction.DOWN:
                    if (CheckPoint(Y + 1, X))
                    {
                        ChangeImage(direction);
                        return true;
                    }
                    break;
            }
            return false;
        }

        private bool CheckPoint(int y, int x)
        {
            var matrix = Form1.Field;
            if (y < matrix.Rows && x < matrix.Columns)
            {
                if (matrix[y, x] is EmptyPoint)
                {
                    return true;
                }

                else if (matrix[y, x] is Coin)
                {
                    matrix[y, x].Action();
                    Form1.UpdatePanel(matrix[y, x], true);
                    return true;
                }

                else if (matrix[y, x] is Energiser)
                {
                    matrix[y, x].Action();
                    Form1.UpdatePanel(matrix[y, x], true);
                    Form1.Energisers.Add(new Energiser(x, y, Form1.time_active));
                    return true;
                }

                else if (matrix[y, x] is Wall)
                {
                    if (y == 13 && (x == 27 || x == 0))
                    {

                        tor_ability = true;
                        return true;
                    }
                }
            }

            //for (int i = 0; i < Form1.Ghosts.List.Count; ++i)
            //{
            //    if (Form1.Ghosts[i].X == x && Form1.Ghosts[i].Y == y)
            //    {
            //        Form1.Ghosts[i].Action();
            //        Form1.UpdateEnemy(Form1.Ghosts[i], i, true);
            //        return true;
            //    }
            //}

            return false;
        }
    }
}

