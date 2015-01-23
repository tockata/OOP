namespace _04_SULS
{
    public class CurrentStudent : Student
    {
        private string currentCourse;

        public CurrentStudent(string firstName, string lastName, int age, int studentNumber, 
            double averageGrade, string currentCourse) 
            : base(firstName, lastName, age, studentNumber, averageGrade)
        {
            this.CurrentCourse = currentCourse;
        }

        public string CurrentCourse
        {
            get { return this.currentCourse; }
            set { this.currentCourse = value; }
        }

        public override string ToString()
        {
            return base.ToString() + "current course: " + this.CurrentCourse + "\n";
        }
    }
}
