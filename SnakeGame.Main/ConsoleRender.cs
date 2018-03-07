using SnakeGame.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SnakeGame.Main
{
    public class ConsoleRender
    {
        public int WindowHeigth { get; }
        public int WindowWidth { get; }
        private List<Point> listCurrentFrame = new List<Point>();
        private int horizontalOffset = 16;
        private int verticalOffset = 3;

        public ConsoleRender(int width = 60, int height = 30)
        {
            Console.Clear();
            Console.CursorVisible = false;

            WindowHeigth = height;
            WindowWidth = width;

            try
            {
                Console.SetWindowSize(WindowWidth + 1, WindowHeigth + 1);
            }
            catch (Exception)
            {
                Console.SetWindowSize(60, 30);
            }

            DisplayBorder();
        }

        public void DisplayItem(Point item)
        {
            Console.SetCursorPosition(item.X, item.Y);
            Console.Write("@");
        }

        private void DisplayBorder()
        {
            for (int i = 0; i < WindowHeigth; i++)
            {
                for (int j = 0; j < WindowWidth; j++)
                {
                    if (i == 0 || i == (WindowHeigth - 1) || j == 0 || j == (WindowWidth - 1))
                    {
                        Console.Write("/");
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }
                Console.WriteLine("");
            }
        }

        public void DisplayGameOverMenu()
        {
            Console.SetCursorPosition(WindowWidth / 2 - horizontalOffset, WindowHeigth / 2 - verticalOffset);
            Console.Write("/////////////////////////////////");
            Console.SetCursorPosition(WindowWidth / 2 - horizontalOffset, WindowHeigth / 2 - (verticalOffset - 1));
            Console.Write("/                               /");
            Console.SetCursorPosition(WindowWidth / 2 - horizontalOffset, WindowHeigth / 2 - (verticalOffset - 2));
            Console.Write("/           GAME OVER           /");
            Console.SetCursorPosition(WindowWidth / 2 - horizontalOffset, WindowHeigth / 2 - (verticalOffset - 3));
            Console.Write("/    Press Space to Restart     /");
            Console.SetCursorPosition(WindowWidth / 2 - horizontalOffset, WindowHeigth / 2 - (verticalOffset - 4));
            Console.Write("/      Press Enter to Exit      /");
            Console.SetCursorPosition(WindowWidth / 2 - horizontalOffset, (WindowHeigth / 2) - (verticalOffset - 5));
            Console.Write("/                               /");
            Console.SetCursorPosition(WindowWidth / 2 - horizontalOffset, (WindowHeigth / 2) - (verticalOffset - 6));
            Console.Write("/////////////////////////////////");
        }

        public void DisplayStartMenu()
        {
            Console.SetCursorPosition(WindowWidth / 2 - horizontalOffset, WindowHeigth / 2 - verticalOffset);
            Console.Write("/////////////////////////////////");
            Console.SetCursorPosition(WindowWidth / 2 - horizontalOffset, WindowHeigth / 2 - (verticalOffset - 1));
            Console.Write("/                               /");
            Console.SetCursorPosition(WindowWidth / 2 - horizontalOffset, WindowHeigth / 2 - (verticalOffset - 2));
            Console.Write("/             SNAKE             /");
            Console.SetCursorPosition(WindowWidth / 2 - horizontalOffset, WindowHeigth / 2 - (verticalOffset - 3));
            Console.Write("/ Press Space to Start new game /");
            Console.SetCursorPosition(WindowWidth / 2 - horizontalOffset, WindowHeigth / 2 - (verticalOffset - 4));
            Console.Write("/      Press Enter to Exit      /");
            Console.SetCursorPosition(WindowWidth / 2 - horizontalOffset, (WindowHeigth / 2) - (verticalOffset - 5));
            Console.Write("/                               /");
            Console.SetCursorPosition(WindowWidth / 2 - horizontalOffset, (WindowHeigth / 2) - (verticalOffset - 6));
            Console.Write("/////////////////////////////////");
        }

        public void DisplayGameWinMenu()
        {
            Console.SetCursorPosition(WindowWidth / 2 - horizontalOffset, WindowHeigth / 2 - verticalOffset);
            Console.Write("/////////////////////////////////");
            Console.SetCursorPosition(WindowWidth / 2 - horizontalOffset, WindowHeigth / 2 - (verticalOffset - 1));
            Console.Write("/                               /");
            Console.SetCursorPosition(WindowWidth / 2 - horizontalOffset, WindowHeigth / 2 - (verticalOffset - 2));
            Console.Write("/           YOU WIN!!!          /");
            Console.SetCursorPosition(WindowWidth / 2 - horizontalOffset, WindowHeigth / 2 - (verticalOffset - 3));
            Console.Write("/ Press Space to Start new game /");
            Console.SetCursorPosition(WindowWidth / 2 - horizontalOffset, WindowHeigth / 2 - (verticalOffset - 4));
            Console.Write("/      Press Enter to Exit      /");
            Console.SetCursorPosition(WindowWidth / 2 - horizontalOffset, (WindowHeigth / 2) - (verticalOffset - 5));
            Console.Write("/                               /");
            Console.SetCursorPosition(WindowWidth / 2 - horizontalOffset, (WindowHeigth / 2) - (verticalOffset - 6));
            Console.Write("/////////////////////////////////");
        }

        public void DisplaySnake(List<Point> snakePoints)
        {
            List<Point> diffPoints = snakePoints.Union(listCurrentFrame).ToList();

            foreach (Point diffPoint in diffPoints)
            {
                Console.SetCursorPosition(diffPoint.X, diffPoint.Y);
                if (snakePoints.Contains(diffPoint))
                {
                    Console.Write("*");
                }
                else
                {
                    Console.Write(" ");
                }
            }

            listCurrentFrame = Snake.CloneList(snakePoints);
        }
    }
}
