namespace _04_SULS
{
    public class OnsiteStudent : CurrentStudent
    {
        private int numberOfVisits;

        public OnsiteStudent(string firstName, string lastName, int age, int studentNumber,
            double averageGrade, string currentCourse, int numberOfVisits) 
            : base(firstName, lastName, age, studentNumber, averageGrade, currentCourse)
        {
            this.NumberOfVisits = numberOfVisits;
        }

        public int NumberOfVisits
        {
            get { return this.numberOfVisits; }
            set { this.numberOfVisits = value; }
        }

        public override string ToString()
        {
            return base.ToString() + "number of visits: " + this.numberOfVisits + "\n";
        }
    }
}
