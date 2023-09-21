using System;

namespace Factory
{
   
    public static class PointFactory
    {
        public static Point NewCartesianPoint(double x, double y)
        {
            return new Point(x,y);
        }
        public static Point NewPolarPoint(double x, double y)
        {
            return new Point(x, y);
        }
    }
    public class Point

    {
        private double x, y;

        public Point(double x, double y)
        {
            this.x = x;
            this.y = y;
        }
              
        public override string ToString()
        {
            return $"This point has coordinates of {this.x} , {this.y}";
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            var p1 = PointFactory.NewCartesianPoint(2.0, 1.0);
            var p2 = PointFactory.NewPolarPoint(5.0, Math.PI / 2);

            Console.WriteLine(p1.ToString());
            Console.WriteLine(p2.ToString());
        }
    }
}