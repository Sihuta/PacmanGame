using Microsoft.SqlServer.Server;
using PacmanGame_WinForms_.Cells;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
//using Newtonsoft.Json;
using System.Numerics;
using System.Text;

namespace PacmanGame_WinForms_
{ 
    public class Field
    {
        public readonly int Columns = 28;
        public readonly int Rows = 25;
        public Level[] Level;
        //private int levelPoint;
        public static int countCoins;
        public static BasePoint[,] Matrix { get; set; }

        public Field()
        {
            //levelPoint = 0;
            //string path = @"level.json";
            //using (StreamReader sr = new StreamReader(path))
            //{
            //    //Level = JsonConvert.DeserializeObject<Level[]>(sr.ReadToEnd());
            //}
            countCoins = 0;
            CreateMatrix();
        }

        public BasePoint this[int i, int j]
        {
            get { return Matrix[i, j]; }
            set { Matrix[i, j] = value; }
        }

        public void CreateMatrix()
        {
            Matrix = new BasePoint[Rows, Columns];
            for (int i = 0; i < Rows; ++i)
            {
                for (int j = 0; j < Columns; ++j)
                {
                    if (i == 0 || i == Rows - 1)
                    {
                        Matrix[i, j] = new Wall(j, i);
                    }

                    else if (j == 0 || j == Columns - 1)
                    {
                        if ((i != 10 && i != 11 && i != 15 && i != 16) || (j != 0 && j != Columns - 1))
                        {
                            Matrix[i, j] = new Wall(j, i);
                        }
                        if (i == 13 && (j == 27 || j == 0))
                        {
                            Matrix[i, j].Image = Properties.Resources.Portal;
                        }
                    }

                    else if (i == 14 && j == 13)
                    {
                        Matrix[i, j] = new EmptyPoint(j, i);
                    }

                    else if ((i == 1 || i == 18) && (j == 13 || j == 14))
                    {
                        Matrix[i, j] = new Wall(j, i);
                    }

                    else if ((i == 2 || i == 4 || i == 19 || i == 20) && ((j >= 2 && j <= 5) || (j >= 7 && j <= 11) || (j >= 13 && j <= 14) || (j >= 16 && j <= 20) || (j >= 22 && j <= 25)))
                    {
                        Matrix[i, j] = new Wall(j, i);
                    }

                    else if (i == 3 && (j == 2 || j == 5 || j == 7 || j == 11 || j == 13 || j == 14 || j == 16 || j == 20 || j == 22 || j == 25))
                    {
                        Matrix[i, j] = new Wall(j, i);
                    }

                    else if (i == 5 && j == 21)
                    {
                        Matrix[i, j] = new Energiser(j, i);
                    }

                    else if ((i == 6 || i == 7) && ((j >= 2 && j <= 5) || j == 7 || (j >= 9 && j <= 18) || j == 20 || (j >= 22 && j <= 25)))
                    {
                        Matrix[i, j] = new Wall(j, i);
                    }

                    else if (i == 8 && (j == 7 || (j >= 12 && j <= 15) || j == 20))
                    {
                        Matrix[i, j] = new Wall(j, i);
                    }

                    else if (i == 9 && ((j >= 1 && j <= 5) || (j >= 7 && j <= 10) || (j >= 12 && j <= 15) || (j >= 17 && j <= 20) || (j >= 22 && j <= Columns - 2)))
                    {
                        Matrix[i, j] = new Wall(j, i);
                    }

                    else if (i == 10 && (j == 5 || (j >= 7 && j <= 10) || (j >= 12 && j <= 15) || (j >= 17 && j <= 20) || j == 22))
                    {
                        Matrix[i, j] = new Wall(j, i);
                    }

                    else if (i == 11 && (j == 5 || j == 7 || j == 20 || j == 22))
                    {
                        Matrix[i, j] = new Wall(j, i);
                    }

                    else if ((i == 12 || i == 14 || i == 17) && ((j >= 1 && j <= 5) || j == 7 || (j >= 9 && j <= 18) || j == 20 || (j >= 22 && j <= Columns - 2)))
                    {
                        Matrix[i, j] = new Wall(j, i);
                    }

                    else if (i == 8 && j == 11)
                    {
                        Matrix[i, j] = new Energiser(j, i);
                    }

                    else if (i == 18 && j == Columns - 2)
                    {
                        Matrix[i, j] = new Energiser(j, i);
                    }

                    else if (i == 13 && j == 13)
                    {
                        //Matrix[i, j] = new Pacman(j, i);
                    }

                    else if (i == 13 && (j == 9 || j == 18))
                    {
                        Matrix[i, j] = new Wall(j, i);
                    }
                    else if (i == 15 && (j == 5 || j == 7 || j == 20 || j == 22))
                    {
                        Matrix[i, j] = new Wall(j, i);
                    }

                    else if (i == 16 && (j == 5 || j == 7 || (j >= 9 && j <= 18) || j == 20 || j == 22))
                    {
                        Matrix[i, j] = new Wall(j, i);
                    }

                    else if (i == 21 && (j == 4 || j == 5 || j == 22 || j == 23))
                    {
                        Matrix[i, j] = new Wall(j, i);
                    }

                    else if (i == 21 && j == 6)
                    {
                        Matrix[i, j] = new Energiser(j, i);
                    }

                    else if ((i == 22) && (j != 3 && j != 6 && j != 9 && j != 18 && j != 21 && j != 24))
                    {
                        Matrix[i, j] = new Wall(j, i);
                    }                    

                    else if ((i == 3 && (j == 3 || j == 8 || j == 9 || j == 18 || j == 19 || j == 24)) || ((i == 10 || i == 11 || i == 15 || i == 16) && (j == 1 || j == 3 || j == Columns - 2 || j == Columns - 4)))
                    {
                        Matrix[i, j] = new EmptyPoint(j, i);
                    }

                    else if ((i == 3 && (j == 10 || j == 17)) || ((i == 11 || i == 15) && (j == 2 || j == 4 || j == 23 || j == 25)))
                    {
                        Matrix[i, j] = new EmptyPoint(j, i);
                    }

                    
                    else if (i == 13 && (j == 0 || j == 27))
                    {
                        Matrix[i, j] = new EmptyPoint(j, i);
                    }

                    else if ((i == 5 && j == Columns - 2)) /*|| (i == 23 && j == 1) || (i == 23 && j == 21) || (i == 1 || j == 6))*/
                    {
                        Matrix[i, j] = new EmptyPoint(j, i);
                    }
                    else if (i == 23 && j == 1)
                    {
                        Matrix[i, j] = new EmptyPoint(j, i);
                    }
                    else if (i == 23 && j == 21)
                    {
                        Matrix[i, j] = new EmptyPoint(j, i);
                    }
                    else if(i == 1 && j == 6)
                    {
                        Matrix[i, j] = new EmptyPoint(j, i);
                    }

                    else
                    {
                        if (i == 1 || i == 5 || i == 8 || i == 18 || i == 11 || i == 13 || i == 14 || i == 15 || i == 21 || i == 23)
                        {
                            countCoins += 1;
                            Matrix[i, j] = new Coin(j, i);
                        }
                        else if (j == 1 || j == 3 || j == 6 || j == 8 || j == 9 || j == 10 || j == 11 || j == 12 || j == 15 || j == 16 || j == 17 || j == 18 || j == 19 || j == 21 || j == Columns - 4 || j == Columns - 2)
                        {
                            countCoins += 1;
                            Matrix[i, j] = new Coin(j, i); 
                        }                       
                    }
                }
            }
        }

        public static void PrintField(Graphics graphics)
        {
            foreach (BasePoint p in Matrix)
            {
                if (p != null)
                {
                    graphics.DrawImage(p.Image, p.X * p.Width, p.Y * p.Height, p.Width, p.Height);
                }
                else
                {
                    Matrix[p.Y, p.X] = new EmptyPoint(p.X, p.Y);
                }
            }            
        }

        public bool Finish()
        {
            if (countCoins <= 0)
            {
                return true;
            }
            return false;
        }

        public bool _Finish()
        {
            foreach (BasePoint p in Matrix)
            {
                if (p is Coin) { return false; }
            }
            return true;
        }

        public bool Checking(int x, int y)
        {
            if (x >= 0 && y >= 0 && x < Columns && y < Rows)
            {
                return true;
            }
            return false;
        }
    }
}