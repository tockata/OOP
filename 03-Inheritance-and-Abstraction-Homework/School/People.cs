using System;

namespace School
{
    public abstract class People : IName, IDetails
    {
        private string name;
        private string details;

        public People(string name, string details = null)
        {
            this.Name = name;
            this.Details = details;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException();
                }

                this.name = value;
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
                    throw new ArgumentException("People details can not be empty!");
                }

                this.details = value;
            }
        }

        public override string ToString()
        {
            string people = "Name: " + this.Name + "\n";
            if (this.Details != null)
            {
                people += "Details: " + this.Details + "\n";
            }

            return people;
        }
    }
}
