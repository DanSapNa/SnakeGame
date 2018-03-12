using System;

namespace SnakeGame.Core
{
    //TODO: Maybe just use a struct?
    public class Point : ICloneable
    {
        public int X { get; set; }
        public int Y { get; set; }

        public object Clone()
        {
            return new Point() { X = this.X, Y = this.Y };
        }

        public override bool Equals(object obj)
        {
            bool areEqual = false;

            if (obj is Point)
            {
                Point point2 = (Point)obj;

                if (point2.X == this.X && point2.Y == this.Y)
                    areEqual = true;
            }

            return areEqual;
        }

        public override int GetHashCode()
        {
            string str = String.Format("{0},{1}", X, Y);
            return str.GetHashCode();
        }
    }
}
