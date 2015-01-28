﻿using System;
using System.Collections.Generic;

namespace School
{
    public class SchoolClass : IDetails
    {
        private string identifier;
        private IList<Teacher> teachers;
        private IList<Student> students;
        private string details;

        public SchoolClass(string identifier, IList<Teacher> teachers, IList<Student> students,
            string details = null)
        {
            this.Identifier = identifier;
            this.Teachers = teachers;
            this.Students = students;
            this.Details = details;
        }

        public string Identifier
        {
            get { return this.identifier; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    Console.WriteLine("SchoolClass identifier can not be null or empty!");
                    throw new ArgumentNullException();
                }

                this.identifier = value;
            }
        }

        public IList<Teacher> Teachers
        {
            get { return new List<Teacher>(this.teachers); }
            set
            {
                if (value == null || value.Count < 1)
                {
                    Console.WriteLine("Teachers list can not be null or empty!");
                    throw new ArgumentNullException();
                }

                this.teachers = value;
            }
        }

        public IList<Student> Students
        {
            get { return new List<Student>(this.students); }
            set
            {
                if (value == null || value.Count < 1)
                {
                    Console.WriteLine("Students list can not be null or empty!");
                    throw new ArgumentNullException();
                }

                this.students = value;
            }
        }

        public string Details
        {
            get
            {
                return this.details;
            }
            set
            {
                if (value == "")
                {
                    throw new ArgumentException("Details can not be empty!");
                }

                this.details = value;
            }
        }

        public override string ToString()
        {
            string schoolClass = this.Identifier + "\n";

            schoolClass += this.Details != null ? "Discipline details: " + this.Details + "\n" : "";
            schoolClass += "Students in this class:\n";

            foreach (var student in this.Students)
            {
                schoolClass += student.Name + "\n";
            }

            schoolClass += "Teachers for this class:\n";
            foreach (var teacher in this.Teachers)
            {
                schoolClass += teacher.Name + "\n";
            }

            return schoolClass;
        }
    }
}
