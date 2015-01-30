namespace Shapes
{
    public class Triangle : BasicShape
    {
        private double secondSide;
        private double thirdSide;

        public double SecondSide
        {
            get { return this.secondSide; }
            set { this.secondSide = value; }
        }

        public double ThirdSide
        {
            get { return this.thirdSide; }
            set { this.thirdSide = value; }
        }

        public Triangle(double width, double height, double secondSide, double thirdSide) 
            : base(width, height)
        {
            this.SecondSide = secondSide;
            this.ThirdSide = thirdSide;
        }

        public override double CalculateArea()
        {
            return (this.Width * this.Height) / 2;
        }

        public override double CalculatePerimeter()
        {
            return this.Width + this.secondSide + this.thirdSide;
        }
    }
}
