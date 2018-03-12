using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace SnakeGame.Core
{
    //TODO: This class looks like 'Game', because it holds Field, Item and Snake. Should be separated.
    public class Snake
    {
        private List<Point> points = new List<Point>();
        private List<Point> lastPoints = new List<Point>();
        public Point Item { get; } //TODO: Better to call smth like 'ItemToEat' - not really obvious what this Item is.

        private int xVelocity; //TODO: It's not clear for me what is the purpose of xVelocity and yVelocity.
        private int yVelocity;
        private int xLimit; //TODO: xLimit and yLimit look like the field size. If so, should be in the 'Field' class and renamed.
        private int yLimit;
        private int length = 6;
        private readonly int extension = 1;
        private readonly int delay = 80;
        private bool notCollided = true;
        private bool isWin = false;

        private int XVelocity
        {
            get { return xVelocity; }
            set
            {
                if (notCollided)
                {
                    xVelocity = value;
                }
                else
                {
                    xVelocity = 0;
                }
            }
        }

        private int YVelocity
        {
            get { return yVelocity; }
            set
            {
                if (notCollided)
                {
                    yVelocity = value;
                }
                else
                {
                    yVelocity = 0;
                }
            }
        }

        private bool NotCollided
        {
            get
            {
                if (notCollided)
                {
                    notCollided = (points[0].X > 0 &&
                                     points[0].Y > 0 &&
                                     points[0].X < (xLimit - 1) &&
                                     points[0].Y < (yLimit - 1) &&
                                     !points.GroupBy(n => n).Any(c => c.Count() > 1));
                }
                return notCollided;
            }
        }

        public bool Dead
        {
            get { return !notCollided; }
        }

        public bool Win
        {
            get
            {
                if (!isWin)
                {
                    isWin = length == 25;
                }
                return isWin;
            }
        }

        private Point GenerateItem()
        {
            Random random = new Random();
            Item.X = random.Next(1, xLimit - 1);
            Item.Y = random.Next(1, yLimit - 1);
            return (Point)Item.Clone();
        }

        public Snake(int xLimit, int yLimit)
        {
            for (int i = 0; i < length; i++)
            {
                points.Add(new Point() { X = (length + 2 - i), Y = 5 });
            }

            this.xLimit = xLimit;
            this.yLimit = yLimit;

            Item = new Point();
            GenerateItem();

            XVelocity = 1;
            YVelocity = 0;
            lastPoints = CloneList(points);
        }

        public List<Point> Move()
        {

            points[0].X += XVelocity;
            points[0].Y -= YVelocity;

            if (points[0].Equals(Item))
            {
                length = length + extension;
                GenerateItem();
            }

            if (NotCollided)
            {
                for (int i = 1; i < length; i++)
                {
                    try
                    {
                        points[i].X = lastPoints[i - 1].X;
                        points[i].Y = lastPoints[i - 1].Y;
                    }
                    catch (Exception)
                    {
                        for (int k = 1; k <= extension; k++)
                        {
                            points.Add(new Point()
                            {
                                X = lastPoints[lastPoints.Count() - 1].X + k * (lastPoints[lastPoints.Count() - 1].X - lastPoints[lastPoints.Count() - 2].X),
                                Y = lastPoints[lastPoints.Count() - 1].Y + k * (lastPoints[lastPoints.Count() - 1].Y - lastPoints[lastPoints.Count() - 2].Y)
                            });
                        }


                    }

                }
            }
            else
            {
                points[0].X -= XVelocity;
                points[0].Y += YVelocity;
            }

            lastPoints = CloneList(points);

            if (YVelocity == 0)
            {
                Thread.Sleep(delay);
            }
            else
            {
                Thread.Sleep(delay * 2);
            }

            return CloneList(points);
        }

        public void Down()
        {
            if (YVelocity == 0)
            {
                XVelocity = 0;
                YVelocity = -1;
            }
        }

        public void Up()
        {
            if (YVelocity == 0)
            {
                XVelocity = 0;
                YVelocity = 1;
            }
        }

        public void Right()
        {
            if (XVelocity == 0)
            {
                XVelocity = 1;
                YVelocity = 0;
            }
        }

        public void Left()
        {
            if (XVelocity == 0)
            {
                XVelocity = -1;
                YVelocity = 0;
            }
        }

        static public List<Point> CloneList(List<Point> listToClone)
        {
            List<Point> clone = new List<Point>();

            foreach (Point elem in listToClone)
            {
                clone.Add((Point)elem.Clone());
            }

            return clone;
        }
    }
}
