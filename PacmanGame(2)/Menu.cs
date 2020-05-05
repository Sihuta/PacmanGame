using System;
using System.Collections.Generic;
using System.Text;

namespace PacmanGame_2_
{
    class Menu
    {
        private string[] menu = new string[4] { "Start Game", "Help", "Choose Pac-Man's speed", "Exit" };

        public int energizer_active = 3000;

        public void MainMenu(int index, int y)
        {
            Console.Title = "Pac-Man";
            Console.Clear();
            Console.CursorVisible = false;

            PrintMenu(index);

            while (true)
            {
                if (Console.KeyAvailable)
                {
                    Console.SetCursorPosition(70, 0);
                    ConsoleKeyInfo key = Console.ReadKey();

                    if (key.Key == ConsoleKey.DownArrow)
                    {

                        if (index < menu.Length - 1)
                        {
                            PrintItem(menu, index, y);
                            ++index;
                            ++y;
                            PrintActiveItem(menu, index, y);
                        }
                    }
                    else if (key.Key == ConsoleKey.Enter)
                    {
                        switch (index)
                        {
                            case 0:
                                Console.Clear();
                                Console.SetCursorPosition(6, 2);
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.Write("Please, enter your name: ");
                                Game.name = Console.ReadLine();
                                Game.StartGame();
                                Game.KeyReading();
                                break;
                            case 1:
                                Help();
                                Home(index, y);
                                break;
                            case 2:
                                ChooseSpeed();
                                Home(index, y);
                                break;
                            case 3:
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.White;
                                Environment.Exit(0);
                                break;
                        }
                    }
                    else if (key.Key == ConsoleKey.UpArrow)
                    {

                        if (index > 0)
                        {
                            PrintItem(menu, index, y);
                            --index;
                            --y;
                            PrintActiveItem(menu, index, y);
                        }
                    }
                }
            }
        }

        private string[] speed = new string[3] { "Low", "Medium", "High" };

        public void ChooseSpeed()
        {
            Console.Clear();
            Console.SetCursorPosition(12, 2);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("CHOOSE PAC-MAN's SPEED");

            PrintSpeed();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("*Medium - default speed");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Press Home to return to the Main Menu...");

            int index = 1;
            int y = 5;
            while (true)
            {
                if (Console.KeyAvailable)
                {
                    Console.SetCursorPosition(70, 0);
                    ConsoleKeyInfo key = Console.ReadKey();

                    if (key.Key == ConsoleKey.DownArrow)
                    {

                        if (index < speed.Length - 1)
                        {
                            PrintItem(speed, index, y);
                            ++index;
                            ++y;
                            PrintActiveItem(speed, index, y);
                        }
                    }
                    else if (key.Key == ConsoleKey.Enter)
                    {
                        switch (index)
                        {
                            case 0:
                                Game.Pacman.Interval = 150;
                                energizer_active = 4000;
                                MainMenu(2, 6);
                                break;
                            case 1:
                                MainMenu(2, 6);
                                break;
                            case 2:
                                Game.Pacman.Interval = 70;                              
                                energizer_active = 2000;
                                MainMenu(2, 6);
                                break;
                        }
                    }
                    else if (key.Key == ConsoleKey.UpArrow)
                    {

                        if (index > 0)
                        {
                            PrintItem(speed, index, y);
                            --index;
                            --y;
                            PrintActiveItem(speed, index, y);
                        }
                    }
                    else if (key.Key == ConsoleKey.Home)
                    {
                        MainMenu(2, 6);
                    }
                }
            }
        }

        public void PrintSpeed()
        {
            Console.SetCursorPosition(0, 4);
            Console.ForegroundColor = ConsoleColor.White;

            for (int i = 0; i < 3; ++i)
            {
                if (i == 1)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(" " + speed[1]);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(speed[i]);
                }
            }
        }


        public void Help()
        {
            Console.Clear();
            Console.SetCursorPosition(38, 2);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("HELP");

            Console.SetCursorPosition(0, 4);
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("You need to eat all the points on the game field and at the same time not to get caught by");
            Console.WriteLine("ghosts which can be neutralized for some time with the help of energi-zers");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("O");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" - a Pac-Man");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("#");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" - a wall");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(".");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" - a point");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("A");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(" A");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write(" A");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(" A");
            Console.WriteLine(" - active ghosts");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("V");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(" V");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write(" V");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(" V");
            Console.WriteLine(" - neutrolised ghosts");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("@");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" - an energizer");
            Console.WriteLine();
            Console.Write("Control the Pac-Man by pressing ");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("keybord arrow keys");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Press ");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write("F5");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" to restart the game");
            Console.Write("Press ");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write("Esc");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" to quit the game but then you'll lose");
            Console.WriteLine();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("Press ");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("Home");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(" to return to the Main Menu...");
        }

        public void PrintMenu(int index)
        {
            Console.Clear();
            Console.SetCursorPosition(6, 2);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("MENU");

            Console.SetCursorPosition(0, 4);
            Console.ForegroundColor = ConsoleColor.White;

            for (int i = 0; i < 4; ++i)
            {
                if (i == index)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(" " + menu[index]);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(menu[i]);
                }
            }
            Console.SetCursorPosition(0, 11);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("Press ");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write("keybord arrow keys");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(" to choose the menu item");
        }

        public void Instruction()
        {
            Console.SetCursorPosition(36, 2);
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write("F5");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write(" - to restart");
            Console.SetCursorPosition(36, 3);
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write("Esc");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write(" - to quit");
            Console.SetCursorPosition(36, 4);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("Home");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write(" - to return to the Menu");
        }

        public void PressKeys()
        {
            Console.SetCursorPosition(3, 21);
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write("F5");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write(" - to restart");
            Console.SetCursorPosition(3, 22);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("Home");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write(" - to return to the Menu");
        }

        public void PrintActiveItem(string[] Menu, int index, int y)
        {
            if (index < Menu.Length)
            {
                Console.SetCursorPosition(0, y);
                Console.ForegroundColor = ConsoleColor.Red;

                Console.WriteLine(" " + Menu[index]);
            }
        }

        public void PrintItem(string[] Menu, int index, int y)
        {
            if (index < Menu.Length)
            {
                Console.SetCursorPosition(0, y);
                Console.ForegroundColor = ConsoleColor.White;

                Console.WriteLine(Menu[index] + " ");
            }
        }

        public void Home(int index, int y)
        {
            while (true)
            {
                ConsoleKeyInfo key = Console.ReadKey();
                if (key.Key == ConsoleKey.Home)
                {
                    MainMenu(index, y);
                }
            }
        }
    }
}
