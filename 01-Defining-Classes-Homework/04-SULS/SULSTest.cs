using System;
using System.Collections.Generic;
using System.Linq;

namespace _04_SULS
{
    public class SULSTest
    {
        static void Main(string[] args)
        {
            Person p1 = new Person("Petar", "Stoyanov", 25);
            Person p2 = new Person("Mihail", "Mihajlov", 28);
            Person p3 = new Person("Stefan", "Stefanov", 19);
            Trainer t1 = new Trainer("Evgeni", "Evgeniev", 35);
            JuniorTrainer jt1 = new JuniorTrainer("Evgeni", "Evgeniev", 35);
            SeniorTrainer st1 = new SeniorTrainer("Maria", "Georgieva", 33);
            Student s1 = new Student("Tanq", "Petrova", 17, 123456, 5.45);
            GraduateStudent gs1 = new GraduateStudent("Minka", "Praznikova", 21, 456789, 6.00);
            CurrentStudent cs1 = new CurrentStudent("Ginka", "Gineva", 23, 321654, 4.44, "PHP Basics");
            DropoutStudent ds1 = new DropoutStudent("Georgi", "Tihomirov", 20, 987654, 2.20, "weak results");
            OnlineStudent ols1 = new OnlineStudent("Voileta", "Dimitrova", 26, 657983, 3.85, "C#");
            OnsiteStudent oss1 = new OnsiteStudent("Nikola", "Nikolov", 24, 756319, 4.90, "Java Basics", 8);

            t1.CreateCourse("Web Fundamentals");
            Console.WriteLine();
            st1.DeleteCourse("JavaScript Basics");
            Console.WriteLine();
            ds1.Reapply();
            Console.WriteLine();

            List<Person> persons = new List<Person>
            {
                p1, p2, p3, t1, jt1, st1, s1, gs1, cs1, ds1, ols1, oss1
            };

            var currentStudents =
                from person in persons
                where person is CurrentStudent
                select (CurrentStudent)person;

            currentStudents = currentStudents.OrderByDescending(c => c.AverageGrade);

            foreach (var currentStudent in currentStudents)
            {
                Console.WriteLine(currentStudent);
            }
        }
    }
}
