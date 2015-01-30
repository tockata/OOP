using System;

namespace Shapes
{
    public class Test
    {
        static void Main(string[] args)
        {
            IShape[] shapes = new IShape[]
            {
                new Triangle(45, 23, 12, 15),
                new Triangle(8.8, 10.45, 3.3, 1.5),
                new Triangle(1.597, 3.24, 12.3, 8.13),
                new Rectangle(12.4, 45.789),
                new Rectangle(8, 5),
                new Rectangle(0.57983, 0.896547),
                new Circle(2.5),
                new Circle(0.56987),
                new Circle(9), 
            };

            foreach (var shape in shapes)
            {
                Console.WriteLine("Shape: {0}, area: {1:F2}, perimeter: {2:F2}\n", shape.GetType(),
                    shape.CalculateArea(), shape.CalculatePerimeter());
            }
        }
    }
}
