using PacmanGame_2_;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Numerics;
using System.Text;

namespace PacmanGame_2_
{ 
    class Field
    {
        public readonly int Rows = 25;
        public readonly int Columns = 28;

        public BasePoint[,] Matrix { get; set; }
        public Field()
        {
            Matrix = new BasePoint[Rows, Columns];
        }
        public BasePoint this[int i, int j]
        {
            get { return Matrix[i, j]; }
            set { Matrix[i, j] = value; }
        }

        public void CreateMatrix()
        {
            for (int i = 0; i < Rows; ++i)
            {
                for (int j = 0; j < Columns; ++j)
                {
                    if (i == 0 || i == Rows - 1)
                    {
                        AddWall(i, j);
                    }

                    else if (j == 0 || j == Columns - 1)
                    {
                        if ((i != 10 && i != 11 && i != 15 && i != 16) || (j != 0 && j != Columns - 1))
                        {
                            AddWall(i, j);
                        }
                    }

                    else if ((i == 1 || i == 18) && (j == 13 || j == 14))
                    {
                        AddWall(i, j);
                    }

                    else if ((i == 2 || i == 4 || i == 19 || i == 20) && ((j >= 2 && j <= 5) || (j >= 7 && j <= 11) || (j >= 13 && j <= 14) || (j >= 16 && j <= 20) || (j >= 22 && j <= 25)))
                    {
                        AddWall(i, j);
                    }

                    else if (i == 3 && (j == 2 || j == 5 || j == 7 || j == 11 || j == 13 || j == 14 || j == 16 || j == 20 || j == 22 || j == 25))
                    {
                        AddWall(i, j);
                    }

                    else if (i == 5 && j == 21)
                    {
                        AddEnergiser(i, j);
                    }

                    else if ((i == 6 || i == 7) && ((j >= 2 && j <= 5) || j == 7 || (j >= 9 && j <= 18) || j == 20 || (j >= 22 && j <= 25)))
                    {
                        AddWall(i, j);
                    }

                    else if (i == 8 && (j == 7 || (j >= 12 && j <= 15) || j == 20))
                    {
                        AddWall(i, j);
                    }

                    else if (i == 9 && ((j >= 1 && j <= 5) || (j >= 7 && j <= 10) || (j >= 12 && j <= 15) || (j >= 17 && j <= 20) || (j >= 22 && j <= Columns - 2)))
                    {
                        AddWall(i, j);
                    }

                    else if (i == 10 && (j == 5 || (j >= 7 && j <= 10) || (j >= 12 && j <= 15) || (j >= 17 && j <= 20) || j == 22))
                    {
                        AddWall(i, j);
                    }

                    else if (i == 11 && (j == 5 || j == 7 || j == 20 || j == 22))
                    {
                        AddWall(i, j);
                    }

                    else if ((i == 12 || i == 14 || i == 17) && ((j >= 1 && j <= 5) || j == 7 || (j >= 9 && j <= 18) || j == 20 || (j >= 22 && j <= Columns - 2)))
                    {
                        AddWall(i, j);
                    }

                    else if (i == 8 && j == 11)
                    {
                        AddEnergiser(i, j);
                    }

                    else if (i == 18 && j == Columns - 2)
                    {
                        AddEnergiser(i, j);
                    }

                    else if (i == 13 && j == 13)
                    {
                        AddPacman(i, j);
                    }

                    else if (i == 13 && (j == 9 || j == 18))
                    {
                        AddWall(i, j);
                    }
                    else if (i == 15 && (j == 5 || j == 7 || j == 20 || j == 22))
                    {
                        AddWall(i, j);
                    }

                    else if (i == 16 && (j == 5 || j == 7 || (j >= 9 && j <= 18) || j == 20 || j == 22))
                    {
                        AddWall(i, j);
                    }

                    else if (i == 21 && (j == 4 || j == 5 || j == 22 || j == 23))
                    {
                        AddWall(i, j);
                    }

                    else if (i == 21 && j == 6)
                    {
                        AddEnergiser(i, j);
                    }

                    else if ((i == 22) && (j != 3 && j != 6 && j != 9 && j != 18 && j != 21 && j != 24))
                    {
                        AddWall(i, j);
                    }

                    //else if (i == 5 && j == Columns - 2)
                    //{
                    //    Game.Blinky = new Blinky(Columns - 2, 5);
                    //    Matrix[i, j] = Game.Blinky;
                    //}

                    //else if (i == 23 && j == 1)
                    //{
                    //    Game.Pinky = new Pinky(1, 23);
                    //    Matrix[i, j] = Game.Pinky;
                    //}

                    //else if (i == 23 && j == 21)
                    //{
                    //    Game.Inky = new Inky(21, 23);
                    //    Matrix[i, j] = Game.Inky;
                    //}

                    //else if (i == 1 && j == 6)
                    //{
                    //    Game.Clyde = new Clyde(6, 1);
                    //    Matrix[i, j] = Game.Clyde;
                    //}

                    else if ((i == 3 && (j == 3 || j == 8 || j == 9 || j == 18 || j == 19 || j == 24)) || ((i == 10 || i == 11 || i == 15 || i == 16) && (j == 1 || j == 3 || j == Columns - 2 || j == Columns - 4)))
                    {
                        AddEmpty(i, j);
                    }

                    else if ((i == 3 && (j == 10 || j == 17)) || ((i == 11 || i == 15) && (j == 2 || j == 4 || j == 23 || j == 25)))
                    {
                        AddEmpty(i, j);
                    }

                    else
                    {
                        if (i == 1 || i == 5 || i == 8 || i == 18 || i == 11 || i == 13 || i == 14 || i == 15 || i == 21 || i == 23)
                        {

                            AddPoint(i, j);
                        }
                        else if (j == 1 || j == 3 || j == 6 || j == 8 || j == 9 || j == 10 || j == 11 || j == 12 || j == 15 || j == 16 || j == 17 || j == 18 || j == 19 || j == 21 || j == Columns - 4 || j == Columns - 2)
                        {
                            AddPoint(i, j);
                        }                       
                    }
                }
            }
        }

        public void PrintField()
        {
            CreateMatrix();
            for (int i = 0; i < Rows; ++i)
            {
                for (int j = 0; j < Columns; ++j)
                {
                    if (Matrix[i, j] != null)
                    {
                        if (i == 14 && j == 13)
                        {
                            AddEmpty(i, j);
                        }
                        else
                            Matrix[i, j].Draw();
                        if (i == 13 && (j == 0 || j == 27))
                        {
                            Matrix[i, j].Clear();
                        }                       
                    }
                    else
                    {
                        AddEmpty(i, j);
                    }
                }
            }
        }

        public bool Finish()
        {
            for (int i = 1; i < Rows - 1; ++i)
            {
                for (int j = 1; j < Columns - 1; ++j)
                {
                    if (Matrix[i, j].Ch == '.')
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private void AddWall(int i, int j)
        {
            BasePoint wall = new Wall(j, i);
            Matrix[i, j] = wall;
        }

        private void AddPoint(int i, int j)
        {
            BasePoint point = new Point(j, i);
            Matrix[i, j] = point;
        }

        private void AddPacman(int i, int j)
        {
            Matrix[i, j] = Game.Pacman;
        }

        private void AddEnergiser(int i, int j)
        {
            BasePoint energiser = new Energiser(j, i);
            Matrix[i, j] = energiser;
        }

        private void AddEmpty(int i, int j)
        {
            BasePoint empty = new EmptyPoint(j, i);
            Matrix[i, j] = empty;
        }
    }
}