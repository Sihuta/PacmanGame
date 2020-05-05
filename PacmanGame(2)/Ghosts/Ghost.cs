using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace PacmanGame_2_
{
    abstract class Ghost : BasePoint
    {
        public override ConsoleColor Color { get; set; }
        private char ch = 'A';

        public override char Ch
        {
            get { return ch; }
            set { ch = value; }
        }

        public Ghost(int x, int y)
            : base(x, y)
        {
            Draw();
        }

        public abstract Direction direction { get; set; }
        public abstract double Interval { get; set; }
        public DateTime Time { get; set; }

        public void PacmanHit()
        {
            if (X == Game.Pacman.X && Y == Game.Pacman.Y)
            {
                if (Ch == 'A')
                {
                    Game.Pacman.GhostHit();
                }
                else if (Ch == 'V')
                {
                    Game.Pacman.GetScore('V');
                    Ch = ' ';
                    Game.Pacman.CurrentResults();
                }
            }
        }

        public void Passive()
        {
            if (Ch != ' ')
            {
                Ch = 'V';
                Draw();
            }
        }

        public void Active()
        {
            if (Ch != ' ')
            {
                Ch = 'A';
                Draw();
            }
        }

        public void Move()
        {
            ChangeDirection();
            Clear();
            GetNextPoint();
            Draw();
            DrawPoint();
        }

        public void ChangeDirection()
        {
            
            switch (direction)
            {
                case Direction.LEFT:
                    if (CheckWall(Y, X - 1))
                        direction = Direction.RIGHT;
                    break;
                case Direction.RIGHT:
                    if (CheckWall(Y, X + 1))
                        direction = Direction.LEFT;
                    break;
                case Direction.UP:
                    if (CheckWall(Y - 1, X))
                        direction = Direction.DOWN;
                    break;
                case Direction.DOWN:
                    if (CheckWall(Y + 1, X))
                        direction = Direction.UP;
                    break;
            }
        }

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

        public void DrawPoint()
        {
            switch (direction)
            {
                case Direction.LEFT:
                    DrawPoint(Y, X + 1);
                    break;
                case Direction.RIGHT:
                    DrawPoint(Y, X - 1);
                    break;
                case Direction.UP:
                    DrawPoint(Y + 1, X);
                    break;
                case Direction.DOWN:
                    DrawPoint(Y - 1, X);
                    break;
            }
        }

        public void DrawPoint(int y, int x)
        {
            var matrix = Game.Field;
            if (y < matrix.Rows && x < matrix.Columns)
            {
                if (matrix[y, x].Ch == '.' || matrix[y, x].Ch == '@')
                {
                    matrix[y, x].Draw();
                }
            }
            else
                return;
        }

        public bool CheckWall(int y, int x)
        {
            var matrix = Game.Field;
            if (y < matrix.Rows && x < matrix.Columns)
            {
                if (matrix[y, x].Ch == '#')
                {
                    return true;
                }
            }
            return false;
        }
    }
}
