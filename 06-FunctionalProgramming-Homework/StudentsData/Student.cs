using System;
using System.Collections.Generic;

class Student
{
    private string firstName;
    private string lastName;
    private int age;
    private int facultyNumber;
    private string phone;
    private string email;
    private IList<int> marks;
    private int groupNumber;

    public Student(string firstName, string lastName, int age, int facultyNumber, string phone, 
        string email, IList<int> marks, int groupNumber)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
        this.Age = age;
        this.FacultyNumber = facultyNumber;
        this.Phone = phone;
        this.Email = email;
        this.Marks = marks;
        this.GroupNumber = groupNumber;
    }

    public string FirstName
    {
        get { return this.firstName; }
        set { this.firstName = value; }
    }

    public string LastName
    {
        get { return this.lastName; }
        set { this.lastName = value; }
    }

    public int Age
    {
        get { return this.age; }
        set { this.age = value; }
    }

    public int FacultyNumber
    {
        get { return this.facultyNumber; }
        set { this.facultyNumber = value; }
    }

    public string Phone
    {
        get { return this.phone; }
        set { this.phone = value; }
    }

    public string Email
    {
        get { return this.email; }
        set { this.email = value; }
    }

    public IList<int> Marks
    {
        get { return this.marks; }
        set { this.marks = value; }
    }

    public int GroupNumber
    {
        get { return this.groupNumber; }
        set { this.groupNumber = value; }
    }

    public override string ToString()
    {
        string student = this.firstName + " " + this.lastName + ", age: " + this.age + 
            ", faculty number: " + this.facultyNumber + ", phone: " + this.phone + ", " +
            ", email: " + this.email + ", group number: " + this.groupNumber + "\n";
        foreach (int mark in this.marks)
        {
            student += mark + " ";
        }
        student += "\n";

        return student;
    }
}