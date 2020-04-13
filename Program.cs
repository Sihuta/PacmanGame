using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;

namespace PacmanGame
{
    class Game
    {
        public static Field field = new Field(15, 30);
        static Pacman pacman;
        static string name = Console.ReadLine();

        public static void Main(string[] args)
        {
            Console.Write("Enter your name: ");

            Console.CursorVisible = false;

            StartGame();

            while (true)
                PacmanControl();
        }

        public static void StartGame()
        {
            pacman = new Pacman(field.Columns / 2, field.Rows / 2)
            {
                Name = name
            };
            Console.Clear();
            field.Matrix = field.CreateMatrix();
            field.PrintField(field.Matrix);
            pacman.Draw();
            pacman.CurrentResults();
        }       

        public static bool GameOver()
        {
            var matrix = field.Matrix;
            if (field.Finish(matrix) || pacman.Lives == 0) { return true; }
            
            return false;
        }

        public static void RestartGame()
        {
            pacman.Draw();
            while (true)
            {
                Console.SetCursorPosition(pacman.X - 1, pacman.Y);
                ConsoleKeyInfo restart = Console.ReadKey();
                if (restart.Key == ConsoleKey.F5)
                {
                    StartGame();
                    break;
                }
                else
                    pacman.Draw();
            }
        }

        public static void PacmanControl()
        {            
            while (pacman.Play)
            {
                if (Console.KeyAvailable)
                {
                    Console.SetCursorPosition(pacman.X, pacman.Y);
                    ConsoleKeyInfo key = Console.ReadKey();

                    if (key.Key == ConsoleKey.RightArrow)
                    {
                        if (CheckFood("right"))
                            pacman.Move("right");
                        else if (GameOver())
                        {
                            RestartGame();
                        }
                        else 
                            pacman.Draw();                       
                    }

                    else if (key.Key == ConsoleKey.LeftArrow)
                    {
                        if (CheckFood("left"))
                            pacman.Move("left");
                        else if (GameOver())
                        {
                            RestartGame();
                        }
                        else 
                            pacman.Draw();                       
                    }

                    else if (key.Key == ConsoleKey.UpArrow)
                    {
                        if (CheckFood("up"))
                            pacman.Move("up");
                        else if (GameOver())
                        {
                            RestartGame();
                        }
                        else 
                            pacman.Draw();                       
                    }

                    else if (key.Key == ConsoleKey.DownArrow)
                    {
                        if (CheckFood("down"))
                            pacman.Move("down");
                        else if (GameOver())
                        {
                            RestartGame();
                        }
                        else 
                            pacman.Draw();                        
                    }

                    else if (key.Key == ConsoleKey.Escape)
                    {
                        pacman.Play = false;
                        pacman.Clear();
                        pacman.GameOver();
                        pacman.Results();
                        RestartGame();
                    }

                    else if (key.Key == ConsoleKey.F5)
                    {

                        StartGame();
                    }                   
                }                
            }
        }

        public static bool CheckFood(string key)
        {
            var matrix = field.Matrix;
            switch (key)
            {
                case "left":
                    if (CheckFoodAndSetScore(matrix, pacman.Y, pacman.X - 1)) { return true; }
                    break;
                case "right":
                    if (CheckFoodAndSetScore(matrix, pacman.Y, pacman.X + 1)) { return true; }
                    break;
                case "up":
                    if (CheckFoodAndSetScore(matrix, pacman.Y - 1, pacman.X)) { return true; }
                    break;
                case "down":
                    if (CheckFoodAndSetScore(matrix, pacman.Y + 1, pacman.X)) { return true; }
                    break;
            }
            return false;
        }

        public static bool CheckFoodAndSetScore(Point[,] matrix, int y, int x)
        {
            if (y < matrix.GetLength(0) && x < matrix.GetLength(1))
            {
                if (matrix[y, x].Ch == '@')
                {
                    pacman.GetScore('@');
                    _ = field.GhostControlAsync();
                    matrix[y, x].Ch = ' ';
                    return true;
                }
                else if (matrix[y, x].Ch == '.')
                {
                    pacman.GetScore('.');
                    matrix[y, x].Ch = ' ';
                    if (field.Finish(matrix))
                    {
                        ++pacman.Steps;
                        pacman.Play = false;
                        pacman.Clear();
                        pacman.YouWin();
                        pacman.Results();                      
                    }
                    else
                        return true;
                }
                else if (matrix[y, x].Ch == ' ')
                {
                    return true;
                }
                else if (matrix[y, x].Ch == 'V')
                {
                    pacman.GetScore('V');
                    matrix[y, x].Ch = ' ';
                    return true;
                }
                else if (matrix[y, x].Ch == 'A')
                {
                    pacman.GetScore('A');
                    if (pacman.Lives == 0)
                    {
                        pacman.Clear();
                        ++pacman.Steps;
                        pacman.Play = false;
                        pacman.GameOver();
                        pacman.Results();
                    }
                    else
                    {
                        matrix[y, x].Ch = ' ';
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
