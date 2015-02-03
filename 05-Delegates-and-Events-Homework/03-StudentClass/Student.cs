using System;

public class Student
{
    private string name;
    private int age;

    public event PropertyChangedEventHandler PropertyChanged;

    public Student(string name, int age)
    {
        this.Name = name;
        this.Age = age;
    }

    public string Name
    {
        get { return this.name; }
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                Console.WriteLine("Name can not be empty!");
                throw new ArgumentNullException();
            }

            this.OnPropertyChanged("Name", this.name, value);
            this.name = value;
        }
    }

    public int Age
    {
        get { return this.age; }
        set
        {
            if (value < 0 || value >= 100)
            {
                throw new ArgumentOutOfRangeException("age", "Age must be in range [0...100].");
            }

            this.OnPropertyChanged("Age", this.age, value);
            this.age = value;
        }
    }

    protected void OnPropertyChanged(string propName, dynamic oldValue, dynamic newValue )
    {
        if (PropertyChanged != null)
        {
            PropertyChangedEventArgs args = new PropertyChangedEventArgs(propName, oldValue, newValue);
            PropertyChanged(this, args);
        }
    }
}
