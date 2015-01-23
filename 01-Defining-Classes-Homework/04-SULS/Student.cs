﻿namespace _04_SULS
{
    public class Student : Person
    {
        private int studentNumber;
        private double averageGrade;

        public Student(string firstName, string lastName, int age, int studentNumber, double averageGrade) 
            : base(firstName, lastName, age)
        {
            this.StudentNumber = studentNumber;
            this.AverageGrade = averageGrade;
        }

        public int StudentNumber
        {
            get { return this.studentNumber; }
            set { this.studentNumber = value; }
        }
        public double AverageGrade
        {
            get { return this.averageGrade; }
            set { this.averageGrade = value; }
        }

        public override string ToString()
        {
            return "Position: " + this.GetType().Name + "\n" + base.ToString() + 
                "student number: " + this.studentNumber + "\n" +
                "average grade: " + this.averageGrade + "\n";
        }
    }
}
