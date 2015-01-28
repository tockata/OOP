using System;
using System.Collections.Generic;

namespace School
{
    public class SchoolTest
    {
        static void Main()
        {
            Student student1 = new Student("Pesho Peshev", 5, "Pesho is the best student");
            Student student2 = new Student("Gosho Goshev", 2, "Gosho is pe4en");
            Student student3 = new Student("Mariya Mihaylova", 4, "Mimi is just Mimi");

            IList<Student> listOfStudents1 = new List<Student> { student1, student2 };
            IList<Student> listOfStudents2 = new List<Student> { student2, student3 };
            IList<Student> listOfStudents3 = new List<Student> { student1, student3 };

            Discipline d1 = new Discipline("C#", 15, listOfStudents1, "basic level");
            Discipline d2 = new Discipline("Java", 10, listOfStudents2, "intermediate level");
            Discipline d3 = new Discipline("PHP", 8, listOfStudents3, "ninja level");

            IList<Discipline> listOfDisciplines1 = new List<Discipline> { d1, d2 };
            IList<Discipline> listOfDisciplines2 = new List<Discipline> { d2, d3 };
            IList<Discipline> listOfDisciplines3 = new List<Discipline> { d1, d3 };

            Teacher teacher1 = new Teacher("Iliyana Georgieva", listOfDisciplines1, "Master ninja of C#");
            Teacher teacher2 = new Teacher("Marin Marinov", listOfDisciplines2, "teaches everything");
            Teacher teacher3 = new Teacher(
                "Trifon Trifonov", 
                listOfDisciplines2, 
                "When I wrote this, only God and I understood what I was doing. Now, God only knows");

            IList<Teacher> t1 = new List<Teacher> { teacher1, teacher2 };
            IList<Teacher> t2 = new List<Teacher> { teacher2, teacher3 };
            IList<Teacher> t3 = new List<Teacher> { teacher1, teacher3 };

            SchoolClass sc1 = new SchoolClass("Class 5A", t1, listOfStudents1);
            SchoolClass sc2 = new SchoolClass("Class 5B", t2, listOfStudents2, "The best class!");
            SchoolClass sc3 = new SchoolClass("Class 5C", t3, listOfStudents3);

            IList<SchoolClass> listOfSchoolClasses1 = new List<SchoolClass> { sc1, sc2 };
            IList<SchoolClass> listOfSchoolClasses2 = new List<SchoolClass> { sc2, sc3 };
            IList<SchoolClass> listOfSchoolClasses3 = new List<SchoolClass> { sc1, sc3 };

            School school1 = new School(listOfSchoolClasses1);
            School school2 = new School(listOfSchoolClasses2);
            School school3 = new School(listOfSchoolClasses3);

            Console.WriteLine(school1);
            Console.WriteLine(student1 + "\n");
            Console.WriteLine(teacher1 + "\n");
            Console.WriteLine(sc1);
        }
    }
}
