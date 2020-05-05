using PacmanGame_2_;
using System;
using System.Drawing;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Timers;
using System.Threading;
using Timer = System.Threading.Timer;
using System.Runtime.InteropServices.WindowsRuntime;

namespace PacmanGame_2_
{
    class Game
    {
        public static string name;
        public static Field Field = new Field();
        public static Pacman Pacman = new Pacman(13, 13);
        public static Ghosts.Ghosts Ghosts; 
        public static Menu Menu = new Menu();

        static void Main(string[] args)
        {
            
            Menu.MainMenu(0, 4);
        }
        
        public static void StartGame()
        {
            Pacman.Name = name;
            Pacman.Restart();
            Console.Clear();
            Field.PrintField();
            Ghosts = new Ghosts.Ghosts();

            Pacman.CurrentResults();
            Menu.Instruction();
        }


        //Задержка (не работает без SetTimeToChange()
        public static bool TimeDelay(DateTime timeToChange)
        {
            int differenceTime = DateTime.Compare(timeToChange, DateTime.Now);
            if (differenceTime <= 0)
            {
                return true;
            }
            return false;
        }

        //Добавить времени для задержки
        public static DateTime SetTimeToChange(double milliseconds)
        {
            DateTime time = DateTime.Now;
            return time.AddMilliseconds(milliseconds);
        }

        public static void GhostMoving(Ghost ghost)
        {
            if (ghost.Ch != ' ')
            {
                ghost.Move();
                ghost.PacmanHit();
            }
        }


        public static void KeyReading()
        {
            for (int i = 0; i < 4; ++i)
            {
                Ghosts[i].Time = SetTimeToChange(Ghosts[i].Interval);
            }
            Pacman.Time = SetTimeToChange(Pacman.Interval);

            bool temp = true;

            while (true)
            {
                if (Pacman.energizers.Count > 0)
                {
                    for (int i = 0; i < 4; ++i)
                    {
                        Ghosts[i].Passive();
                    }
                    temp = true;
                }
                else
                {
                    for (int i = 0; i < 4; ++i)
                    {
                        Ghosts[i].Active();
                    }
                }

                if (temp)
                {
                    for (int i = 0; i < 4; ++i)
                    {
                        if (Ghosts[i].X == Pacman.X && Ghosts[i].Y == Pacman.Y)
                        {
                            Ghosts[i].PacmanHit();
                        }
                    }                   
                    temp = false;
                }

                if (TimeDelay(Pacman.Time))
                {
                    Pacman.Move();
                    Pacman.Time = SetTimeToChange(Pacman.Interval);
                }

                for (int i = 0; i < 4; ++i)
                {
                    if (TimeDelay(Ghosts[i].Time))
                    {
                        GhostMoving(Ghosts[i]);
                        Ghosts[i].Time = SetTimeToChange(Ghosts[i].Interval);
                    }
                }

                for (int i = 0; i < Pacman.energizers.Count; ++i)
                {
                    if (Pacman.energizers[i].ReadyToStop(Pacman.energizers[i].time))
                    {
                        Pacman.energizers.RemoveAt(i);
                    }
                }                

                if (Pacman.GameEnd())
                {
                    for (int i = 0; i < 4; ++i)
                    {
                        Ghosts[i].Clear();
                    }

                    Pacman.Clear();
                    Menu.PressKeys();
                    RestartGame();
                    KeyReading();
                }

                if (Console.KeyAvailable)
                {
                    Console.SetCursorPosition(Pacman.X, Pacman.Y);
                    ConsoleKeyInfo key = Console.ReadKey();
                  
                    if (key.Key == ConsoleKey.Escape)
                    {
                        Pacman.Play = false;

                        for (int i = 0; i < 4; ++i)
                        {
                            Ghosts[i].Clear();
                        }

                        Pacman.GameOver();
                        Pacman.Results();
                        Menu.PressKeys();

                        Pacman.Clear();

                        RestartGame();
                        KeyReading();
                    }

                    else if (key.Key == ConsoleKey.Home)
                    {
                        Pacman.Clear();
                        Menu.MainMenu(0, 4);
                    }

                    else if (key.Key == ConsoleKey.F5)
                    {
                        Pacman.Clear();
                        StartGame();
                        KeyReading();
                    }

                    else if (key.Key == ConsoleKey.DownArrow || key.Key == ConsoleKey.UpArrow || key.Key == ConsoleKey.RightArrow || key.Key == ConsoleKey.LeftArrow)
                    {
                        Pacman.ChangeDirection(key.Key);
                        temp = true;
                    }                    
                }

            }
        }
        
        public static void RestartGame()
        {
            Pacman.Draw();
            while (true)
            {
                Console.SetCursorPosition(Pacman.X - 1, Pacman.Y);
                ConsoleKeyInfo restart = Console.ReadKey();
                if (restart.Key == ConsoleKey.F5)
                {
                    StartGame();
                    break;
                }
                else if (restart.Key == ConsoleKey.Home)
                {
                    Menu.MainMenu(0, 4);
                }
            }
        }       
    }
}
