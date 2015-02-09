using System;
using System.Collections.Generic;
using System.Linq;

class Test
{
    static void Main()
    {
        // NOTICE: You must uncomment the lines which prints current problem result to see it.

        List<Student> students = new List<Student>()
        {
            new Student("Pesho", "Goshev", 25, 235470, "0888-897657", "pesho@gmail.com",
                new List<int>{5, 2, 3, 4, 6}, 1),
            new Student("Marijka", "Marcheva", 19, 235414, "02-234567", "mimeto@abv.com",
                new List<int>{4, 6, 3}, 2),
            new Student("Gencho", "Genchev", 33, 235487, "0788-987654", "gencho@yahoo.com",
                new List<int>{4}, 3),
            new Student("Spas", "Mishev", 48, 235402, "0888-863487", "spas@gmail.com",
                new List<int>{5, 3}, 1),
            new Student("Atanaska", "Yankova", 22, 235514, "+3592-675354", "atanaska@abv.bg",
                new List<int>{2, 3, 6}, 2),
            new Student("Spas", "Velev", 48, 23540, "+359 2-863487", "spas@gmail.com",
                new List<int>{5, 2, 4}, 1),
            new Student("Voileta", "Georgieva", 37, 235448, "0788-723548", "violeta@yahoo.com",
                new List<int>{6, 3, 5}, 3)
        };

        // Problem 4.Students by Group:
        var studentsByGroup =
            from student in students
            where student.GroupNumber == 3
            orderby student.FirstName
            select student;

        //PrintStudents(studentsByGroup);

        // Problem 5.Students by First and Last Name:
        var studentsByNames =
            from student in students
            where student.FirstName.CompareTo(student.LastName) == -1
            select student;

        //PrintStudents(studentsByNames);

        // Problem 6.Students by Age
        var studentAge =
            from student in students
            where student.Age > 18 && student.Age < 24
            select new {fname = student.FirstName, lname = student.LastName, age = student.Age};

        //foreach (var student in studentAge)
        //{
        //    Console.WriteLine(student.fname + " " + student.lname + ", age: " + student.age);
        //}

         //Problem 7.Sort Students:
        var sortedStudents1 = students.OrderByDescending(s => s.FirstName).ThenByDescending(s => s.LastName);
        var sortedStudents2 =
            from student in students
            orderby student.FirstName descending , student.LastName descending
            select student;

        //PrintStudents(sortedStudents1);
        //PrintStudents(sortedStudents2);

        // Problem 8.Filter Students by Email Domain:
        var studentsWithEmailDomain =
            from student in students
            where student.Email.IndexOf("@abv.bg") > -1
            select student;

        //PrintStudents(studentsWithEmailDomain);

        // Problem 9.Filter Students by Phone:
        var studentsByPhone =
            from student in students
            where student.Phone.StartsWith("02") || student.Phone.StartsWith("+3592") ||
                  student.Phone.StartsWith("+359 2")
            select student;

        //PrintStudents(studentsByPhone);

        // Problem 10.Excellent Students:
        var excellentStudents =
            from student in students 
            where student.Marks.Contains(6)
            select new { fullName = student.FirstName + " " + student.LastName, marks = student.Marks };

        //foreach (var student in excellentStudents)
        //{
        //    Console.WriteLine(student.fullName);
        //    for (int i = 0; i < student.marks.Count; i++)
        //    {
        //        Console.Write(student.marks[i] + " ");
        //    }
        //    Console.WriteLine();
        //}

        // Problem 11.Weak Students:
        var weakStudents =
            students.Where(s => s.Marks.Contains(2))
                .Select(s => new {fullName = s.FirstName + " " + s.LastName, marks = s.Marks});

        //foreach (var student in weakStudents)
        //{
        //    Console.WriteLine(student.fullName);
        //    for (int i = 0; i < student.marks.Count; i++)
        //    {
        //        Console.Write(student.marks[i] + " ");
        //    }
        //    Console.WriteLine();
        //}

        // Problem 12.Students Enrolled in 2014:
        var students2014 = students.Where(s => s.FacultyNumber.ToString().EndsWith("14"));

        //PrintStudents(students2014);
    }

    public static void PrintStudents(dynamic processedStudent)
    {
        foreach (var student in processedStudent)
        {
            Console.WriteLine(student);
        }
    }
}