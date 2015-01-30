using System;

namespace Shapes
{
    public class Circle : IShape
    {
        private double radius;

        public Circle(double radius)
        {
            this.radius = radius;
        }

        public double Radius
        {
            get { return this.radius; }
            set { this.radius = value; }
        }


        public double CalculateArea()
        {
            return Math.PI * Math.Pow(this.radius, 2);
        }

        public double CalculatePerimeter()
        {
            return 2 * Math.PI * this.radius;
        }
    }
}
