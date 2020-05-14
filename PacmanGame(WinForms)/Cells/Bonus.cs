using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacmanGame_WinForms_.Cells
{
    abstract class Bonus : BasePoint
    {
        public Bonus(int x, int y)
          : base(x, y)
        { 

        }

        public bool isEmpty = false;
        private bool tor = false;

        public Direction direction = Direction.LEFT;
        public int Interval = 500;

        public void Move()
        {
            ChangeDirection();
            GetNextPoint();
        }

        public new virtual void Action()
        {
            GetScore();
            Image = Properties.Resources.Empty;
            isEmpty = true;
        }

        public void ChangeDirection()
        {
            switch (direction)
            {
                case Direction.LEFT:
                    if (CheckWall(Y, X - 1))
                    {
                        direction = Direction.RIGHT;
                        
                    }
                    break;
                case Direction.RIGHT:
                    if (CheckWall(Y, X + 1))
                    {
                        direction = Direction.LEFT;
                        
                    }
                    break;
            }
        }

        public void GetNextPoint()
        {
            switch (direction)
            {
                case Direction.LEFT:
                    if (tor)
                    {
                        tor = false;
                        X = 27;
                    }
                    else
                        X -= 1;
                    break;
                case Direction.RIGHT:
                    if (tor)
                    {
                        tor = false;
                        X = 0;
                    }
                    else    
                        X += 1;
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
                    if (y == 13 && (x == 27 || x == 0))
                    {
                        tor = true;
                        return false;
                    }
                    return true;
                }
            }
            return false;
        }
    }
}
