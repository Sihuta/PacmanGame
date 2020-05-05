using PacmanGame_2_;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace PacmanGame_2_
{
    class Pacman : BasePoint
    {
        private ConsoleColor color = ConsoleColor.Yellow;
        private char ch = 'O';

        public List<Energiser> energizers = new List<Energiser>();

        public override ConsoleColor Color
        {
            get { return color; }
            set { color = value; }
        }

        public override char Ch
        {
            get { return ch; }
            set { ch = value; }
        }

        public Pacman(int x, int y)
            : base(x, y)
        {
        }

        public void Restart()
        {
            X = 13;
            Y = 13;
            direction = Direction.UP;
            Lives = 3;
            Score = 0;
        }
        
        private Direction direction = Direction.UP;
        private Direction next_direction = 0;

        public int prev_X = 13;
        public int prev_Y = 13;


        public int Lives = 3;
        public int Score = 0;
        public int Steps = 0;
        public bool Play = true;

        public int Interval = 100;
        public DateTime Time { get; set; }

        public string Name;

        public bool GameEnd()
        {
            var matrix = Game.Field;
            if (matrix.Finish() || Lives == 0) { return true; }
            return false;
        }

        public void ChangeDirection(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.RightArrow:
                    if (CheckPoint(Direction.RIGHT))
                    {
                        direction = Direction.RIGHT;

                    }
                    else
                        next_direction = Direction.RIGHT;
                    break;
                case ConsoleKey.LeftArrow:
                    if (CheckPoint(Direction.LEFT))
                    {
                        direction = Direction.LEFT;

                    }
                    else
                        next_direction = Direction.LEFT;
                    break;
                case ConsoleKey.DownArrow:
                    if (CheckPoint(Direction.DOWN))
                    {
                        direction = Direction.DOWN;

                    }
                    else
                        next_direction = Direction.DOWN;
                    break;
                case ConsoleKey.UpArrow:
                    if (CheckPoint(Direction.UP))
                    {
                        direction = Direction.UP;

                    }
                    else
                        next_direction = Direction.UP;
                    break;
            }
        }

        public void Move()
        {
            if (CheckPoint(next_direction))
            {
                Clear();
                GetNextPoint(next_direction);
                Draw();
                ++Steps;
                CurrentResults();

                direction = next_direction;
                next_direction = 0;
            }
            else
            {
                Draw();
            }
            if (CheckPoint(direction) && direction != next_direction)
            {
                Clear();
                GetNextPoint(direction);
                Draw();
                ++Steps;
                CurrentResults();

            }           
        }

        public void GetNextPoint(Direction direction)
        {
            switch (direction)
            {
                case Direction.LEFT:
                    if (tor_ability)
                    {
                        X = 26;
                        tor_ability = false;
                    }
                    else 
                        X -= 1;
                    prev_X += 1;
                    break;
                case Direction.RIGHT:
                    if (tor_ability)
                    {
                        X = 1;
                        tor_ability = false;
                    }
                    else
                        X += 1;
                    prev_X -= 1;
                    break;
                case Direction.UP:
                    Y -= 1;
                    prev_Y += 1;
                    break;
                case Direction.DOWN:
                    Y += 1;
                    prev_Y -= 1;
                    break;
            }
        }

        public bool CheckPoint(Direction direction)
        {
            switch (direction)
            {
                case Direction.LEFT:
                    if (CheckPointAndSetScore(Y, X - 1)) { return true; }
                    break;
                case Direction.RIGHT:
                    if (CheckPointAndSetScore(Y, X + 1)) { return true; }
                    break;
                case Direction.UP:
                    if (CheckPointAndSetScore(Y - 1, X)) { return true; }
                    break;
                case Direction.DOWN:
                    if (CheckPointAndSetScore(Y + 1, X)) { return true; }
                    break;
            }
            return false;
        }

        private bool tor_ability = false;

        public bool CheckPointAndSetScore(int y, int x)
        {
            var matrix = Game.Field;
            if (y < matrix.Rows && x < matrix.Columns)
            {
                if ((matrix[y, x].Ch == '#' && ((y == 13 && x == 27) || (y == 13 && x == 0))))
                {
                    tor_ability = true;
                    return true;
                }
                else if (matrix[y, x].Ch == '@')
                {
                    energizers.Add(new Energiser(x, y, Game.Menu.energizer_active));
                    GetScore('@');
                    matrix[y, x].Ch = ' ';
                    return true;
                }
                else if (matrix[y, x].Ch == 'O')
                {
                    return true;
                }
                else if (matrix[y, x].Ch == '.')
                {
                    GetScore('.');
                    matrix[y, x].Ch = ' ';
                    if (matrix.Finish())
                    {
                        ++Steps;
                        YouWin();
                        Results();
                    }
                    else
                        return true;
                }
                else if (matrix[y, x].Ch == ' ')
                {
                    return true;
                }
            }
            return false;
        }

        public void GhostHit()
        {
            GetScore('A');
            if (Lives == 0)
            {
                ++Steps;
                Play = false;
                GameOver();
                Results();
                Game.Menu.PressKeys();
                Game.RestartGame();
            }
            else
                CurrentResults();
        }


        public void GetScore(char key)
        {
            switch (key)
            {
                case '.':
                    Score += 10;
                    break;
                case '@':
                    Score += 50;
                    break;
                case 'V':
                    Score += 100;
                    break;
                case 'A':
                    Lives -= 1;
                    break;
            }
        }

        public void CurrentResults()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(36, 12);
            Console.Write($"Score: {Score}");
            Console.SetCursorPosition(36, 14);
            Console.Write($"Lives: {Lives}");
        }

        public void Results()
        {
            X = 36;
            Y = 8;
            Console.SetCursorPosition(38, 8);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(Name);
            Console.SetCursorPosition(36, 10);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($"Score: {Score}");
            Console.SetCursorPosition(36, 12);
            Console.Write($"Steps: {Steps}");
            Console.SetCursorPosition(36, 14);
            Console.Write($"Lives: {Lives}");
        }

        public void GameOver()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("     #####   ###   ##   ## ######");
            Console.WriteLine("    ##      ## ##  ### ### ##");
            Console.WriteLine("   ##      ##   ## ####### ##");
            Console.WriteLine("   ##  ### ##   ## ####### #####");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("   ##   ## ####### ## # ## ##");
            Console.WriteLine("    ##  ## ##   ## ##   ## ##");
            Console.WriteLine("     ##### ##   ## ##   ## ######");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("    #####  ##   ## ###### ######");
            Console.WriteLine("   ##   ## ##   ## ##     ##   ##");
            Console.WriteLine("   ##   ## ##   ## ##     ##   ##");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("   ##   ## ### ### #####  ##  ###");
            Console.WriteLine("   ##   ##  #####  ##     #####");
            Console.WriteLine("   ##   ##   ###   ##     ## ###");
            Console.WriteLine("    #####     #    ###### ##  ###");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void YouWin()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("   ###  ###    ######    ###   ###");
            Console.WriteLine("   ###  ###  ###    ###  ###   ###");
            Console.WriteLine("   ###  ###  ###    ###  ###   ###");
            Console.WriteLine("    ######   ###    ###  ###   ###");
            Console.WriteLine("      ##     ###    ###  ###   ###");
            Console.WriteLine("      ##     ###    ###  ###   ###");
            Console.WriteLine("      ##       ######     #######");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("   ###      ###  ######  ###   ###");
            Console.WriteLine("   ###      ###   ####   ####  ###");
            Console.WriteLine("   ###      ###   ####   ##### ###");
            Console.WriteLine("   ###  ##  ###   ####   #########");
            Console.WriteLine("   ############   ####   ### #####");
            Console.WriteLine("   #####  #####   ####   ###  ####");
            Console.WriteLine("   ###      ###  ######  ###   ###");
        }
    }
}

