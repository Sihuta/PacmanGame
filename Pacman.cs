using System;
using System.Collections.Generic;
using System.Text;

namespace PacmanGame
{
    public class Pacman
    {
        public enum Direction
        {
            LEFT,
            RIGHT,
            UP,
            DOWN
        }

        public int Lives;
        private char ch = 'o';
        private Direction direction = Direction.DOWN;
        public int Score = 0;
        public int Steps = 0;
        public bool Play = true;
        public int X;
        public int Y;

        public Pacman(int x, int y)
        {
            X = x;
            Y = y;
            Lives = y / 2;
        }

        public void Draw()
        {
            DrawPoint(ch);
        }
        public void Clear()
        {
            DrawPoint(' ');
        }
        private void DrawPoint(char _ch)
        {
            Console.SetCursorPosition(X, Y);
            if (_ch == 'o')
                Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(_ch);
        }

        public void Move(string key)
        {
            if (key == "down")
            {
                direction = Direction.DOWN;
            }
            else if (key == "up")
            {
                direction = Direction.UP;
            }
            else if (key == "left")
            {
                direction = Direction.LEFT;
            }
            else if (key == "right")
            {
                direction = Direction.RIGHT;
            }

            Move();
            CurrentResults();
        }

        public void Move()
        {
            ++Steps;
            Clear();
            GetNextPoint();
            Draw();
        }

        public Pacman GetNextPoint()
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
            var pacman = new Pacman(X, Y);
            return pacman;
        }

        public void GetScore(char key)
        {
            if (key == '.') { Score += 10; }
            else if (key == '@') { Score += 50; }
            else if (key == 'V') { Score += 100; }
            else if (key == 'A') { Lives -= 1; }
        }

        public void CurrentResults()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(36, 8);
            Console.WriteLine($"Score: {Score}");
            Console.SetCursorPosition(36, 10);
            Console.WriteLine($"Lives: {Lives}");
        }

        public void Results()
        {
            Console.SetCursorPosition(36, 10);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"Score: {Score}");
            Console.SetCursorPosition(36, 12);
            Console.WriteLine($"Steps: {Steps}");
            Console.SetCursorPosition(36, 14);
            Console.WriteLine($"Lives: {Lives}");
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

