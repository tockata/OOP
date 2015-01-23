using System;

namespace _04_SULS
{
    public class DropoutStudent : Student
    {
        private string dropOutReason;

        public DropoutStudent(string firstName, string lastName, int age, int studentNumber,
            double averageGrade, string dropOutReason) 
            : base(firstName, lastName, age, studentNumber, averageGrade)
        {
            this.DropOutReason = dropOutReason;
        }

        public string DropOutReason
        {
            get { return this.dropOutReason; }
            set { this.dropOutReason = value; }
        }

        public void Reapply()
        {
            Console.WriteLine(base.ToString() + "dropout reason: " + this.dropOutReason);
        }
    }
}
