using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PacmanGame
{
    public struct Point
    {
        public int X { get; set; }
        public int Y { get; set; }
        public char Ch { get; set; }

        public Point(int x, int y, char ch)
        {
            X = x;
            Y = y;
            Ch = ch;
        }

        public void Draw()
        {
            DrawPoint(Ch);
        }
        public void Clear()
        {
            DrawPoint(' ');
        }
        private void DrawPoint(char _ch)
        {
            Console.SetCursorPosition(X, Y);

            if (_ch == 'o')
            {
                Console.ForegroundColor = ConsoleColor.Black;
            }
            if (_ch == '#')
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
            }
            if (_ch == 'A')
            {
                Console.ForegroundColor = ConsoleColor.White;
            }
            if (_ch == '@')
            {
                Console.ForegroundColor = ConsoleColor.Green;
            }
            if (_ch == 'V')
            {
                Console.ForegroundColor = ConsoleColor.Gray;
            }
            if (_ch == '.')
            {
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
    }


    public class Field
    {
        public int Rows { get; set; }
        public int Columns { get; set; }

        public Point[,] Matrix;

        public Field(int rows, int columns)
        {
            if (rows >= 5 && columns >= 5)
            {
                Rows = rows;
                Columns = columns;
            }
            else
                throw new ArgumentException("Указанный размер поля очень мал");
        }

        public Point[,] CreateMatrix()
        {
            Point[,] matrix = new Point[Rows, Columns];
            Point point;

            for (int i = 0; i < Rows; ++i)
            {
                for (int j = 0; j < Columns; ++j)
                {
                    if (i == 0 || i == Rows - 1)
                    {
                        point = new Point(j, i, '#');
                        matrix[i, j] = point;
                    }

                    else if (j == 0 || j == Columns - 1)
                    {
                        point = new Point(j, i, '#');
                        matrix[i, j] = point;
                    }

                    else if (j == 2 && i >= 2 && i <= Rows - 1)
                    {
                        point = new Point(j, i, '#');
                        matrix[i, j] = point;
                    }
                    else if (j == Columns - 3 && i >= 2 && i <= Rows - 1)
                    {
                        point = new Point(j, i, '#');
                        matrix[i, j] = point;
                    }

                    else if (j == 4 && i >= 2 && i <= Rows - 1 && i != Rows / 2)
                    {
                        point = new Point(j, i, '#');
                        matrix[i, j] = point;
                    }

                    else if (j == Columns - 5 && i >= 2 && i <= Rows - 1 && i != Rows / 2)
                    {
                        point = new Point(j, i, '#');
                        matrix[i, j] = point;
                    }

                    else if ((i == 2 || i == Rows - 3) && j > 4 && j < Columns - 4 && j != Columns / 2)
                    {
                        point = new Point(j, i, '#');
                        matrix[i, j] = point;
                    }

                    else if (i == 4 && j > 6 && j < Columns - 6)
                    {
                        point = new Point(j, i, '#');
                        matrix[i, j] = point;
                    }

                    else if ((j == 6 || j == Columns - 7) && i > 4 && i < Rows - 4)
                    {
                        point = new Point(j, i, '#');
                        matrix[i, j] = point;
                    }

                    else if ((i == 6 || i == Rows - 5) && j >= 8 && j <= Columns - 9)
                    {
                        point = new Point(j, i, '#');
                        matrix[i, j] = point;
                    }

                    else if ((j == Columns / 2 - 1 || j == Columns / 2 + 1) && i >= 7 && i < Rows - 6)
                    {
                        point = new Point(j, i, '#');
                        matrix[i, j] = point;
                    }

                    else if (i == 8 && ((j >= 8 && j < Columns / 2 - 2) || (j > Columns / 2 + 2 && j < Columns - 8)))
                    {
                        point = new Point(j, i, '#');
                        matrix[i, j] = point;
                    }

                    else
                    {
                        matrix[i, j] = Random(i, j);
                    }
                }
            }
            var pacman = new Point(Columns / 2, Rows / 2, ' ');
            matrix[Rows / 2, Columns / 2] = pacman;

            return matrix;
        }

        public void PrintField(Point[,] field)
        {
            for (int i = 0; i < Rows; ++i)
            {
                for (int j = 0; j < Columns; ++j)
                {
                    field[i, j].Draw();
                    Console.Write(field[i, j].Ch);
                }
            }
        }

        public void GhostNeutrolise()
        {
            GhostNeutrolise(Matrix);
        }
        public void GhostNeutrolise(Point[,] field)
        {
            for (int i = 1; i < Rows - 1; ++i)
            {
                for (int j = 1; j < Columns - 1; ++j)
                {
                    if (field[i, j].Ch == 'A')
                    {
                        field[i, j].Ch = 'V';
                        field[i, j].Draw();
                        Console.Write(field[i, j].Ch);
                    }
                }
            }
        }
        public void GhostActive()
        {
            GhostActive(Matrix);
        }
        public void GhostActive(Point[,] field)
        {
            for (int i = 1; i < Rows - 1; ++i)
            {
                for (int j = 1; j < Columns - 1; ++j)
                {
                    if (field[i, j].Ch == 'V')
                    {
                        field[i, j].Ch = 'A';
                        field[i, j].Draw();
                        Console.Write(field[i, j].Ch);
                    }
                }
            }
        }

        public async Task GhostControlAsync()
        {
            GhostNeutrolise();
            Task task = Task.Delay(10000);
            await task;
            GhostActive();
        }

        public bool Finish(Point[,] field)
        {
            for (int i = 1; i < Rows - 1; ++i)
            {
                for (int j = 1; j < Columns - 1; ++j)
                {
                    if (field[i, j].Ch == '.')
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private Point Random(int i, int j)
        {
            Point point;
            var random = new Random();
            int value = random.Next(1, 5);
            int num = random.Next(1, 5);

            if (value == num && value == 3)
            {
                point = new Point(j, i, '@');
                return point;
            }
            else if (value % 2 == 0)
            {
                point = new Point(j, i, '.');
                return point;
            }
            else if (value == 3 && value < num)
            {
                point = new Point(j, i, 'A');
                return point;
            }
            point = new Point(j, i, '.');
            return point;
        }
    }
}
