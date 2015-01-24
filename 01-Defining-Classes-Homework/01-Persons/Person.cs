using System;

namespace _01_Defining_Classes_Homework
{
    public class Person
    {
        private string name;
        private int age;
        private string email;

        public string Name
        {
            get { return this.name; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException();
                }
                this.name = value;
            }
        }

        public int Age
        {
            get { return this.age; }
            set
            {
                if (value < 1 || value > 100)
                {
                    throw new ArgumentException("Age must be between 1 and 100!");
                }
                this.age = value;
            }
        }

        public string Email
        {
            get { return this.email; }
            set
            {
                if (!string.IsNullOrEmpty(value) && !value.Contains("@"))
                {
                    throw new ArgumentException("Email must contains @ character!");
                }
                this.email = value;
            }
        }

        public Person(string name, int age)
            : this(name, age, null)
        {
        }

        public Person(string name, int age, string email)
        {
            this.Name = name;
            this.Age = age;
            this.Email = email;
        }

        public override string ToString()
        {
            return string.Format("Name:{0}, Age:{1}, Email:{2}", this.Name, this.Age, 
                string.IsNullOrEmpty(this.Email) ? "not set" : this.Email);
        }
    }
}
