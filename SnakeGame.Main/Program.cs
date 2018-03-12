using SnakeGame.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame.Main
{
    //TODO: The approach is not really OOP-like. Consider using such classes as Game, Snake, Food 
    //(there is a comment regarding this in Snake.cs file, too.
    public class Program
    {
        private static bool IsRestart = false;
        private static ConsoleKeyInfo KeyInfo;
        private static ConsoleKey Key;

        static void Main(string[] args)
        {
            List<Point> snakePoints = new List<Point>();

            int width = 64;
            int height = 30;

            Snake snake = new Snake(width, height);

            ConsoleRender render = new ConsoleRender(width, height);

            if (!IsRestart)
            {
                render.DisplayStartMenu();
                do
                {
                    KeyInfo = Console.ReadKey(true);
                    Key = KeyInfo.Key;
                    if (Key != ConsoleKey.Enter & Key != ConsoleKey.Spacebar)
                    {
                        render.DisplayStartMenu();
                    }
                }
                while (Key != ConsoleKey.Enter & Key != ConsoleKey.Spacebar);
            }

            IsRestart = false;

            if (KeyInfo.Key.Equals(ConsoleKey.Spacebar))
            {
                render = new ConsoleRender(width, height);
                Key = new ConsoleKey();

                while (Key != ConsoleKey.Q && !snake.Dead && !snake.Win)
                {
                    if (Console.KeyAvailable)
                    {
                        KeyInfo = Console.ReadKey(true);
                        Key = KeyInfo.Key;
                        switch (Key)
                        {
                            case ConsoleKey.RightArrow:
                                snake.Right();
                                break;
                            case ConsoleKey.LeftArrow:
                                snake.Left();
                                break;
                            case ConsoleKey.UpArrow:
                                snake.Up();
                                break;
                            case ConsoleKey.DownArrow:
                                snake.Down();
                                break;
                            default:
                                break;
                        }
                    }

                    render.DisplaySnake(snake.Move());
                    render.DisplayItem(snake.Item);
                }

                if (snake.Dead)
                {
                    render.DisplayGameOverMenu();
                    do
                    {
                        KeyInfo = Console.ReadKey(true);
                        Key = KeyInfo.Key;
                        if (Key != ConsoleKey.Enter & Key != ConsoleKey.Spacebar)
                        {
                            render.DisplayGameOverMenu();
                        }
                    }
                    while (Key != ConsoleKey.Enter & Key != ConsoleKey.Spacebar);
                }
                else
                {
                    if (snake.Win)
                    {
                        render.DisplayGameWinMenu();
                        do
                        {
                            KeyInfo = Console.ReadKey(true);
                            Key = KeyInfo.Key;
                            if (Key != ConsoleKey.Enter & Key != ConsoleKey.Spacebar)
                            {
                                render.DisplayGameWinMenu();
                            }
                        }
                        while (Key != ConsoleKey.Enter & Key != ConsoleKey.Spacebar);
                    }
                }

                if (Key != ConsoleKey.Q)
                {
                    if (Key.Equals(ConsoleKey.Spacebar))
                    {
                        IsRestart = true;
                        Main(new string[] { });
                    }
                }

            }
            else
            {
                return;
            }

        }
    }
}
