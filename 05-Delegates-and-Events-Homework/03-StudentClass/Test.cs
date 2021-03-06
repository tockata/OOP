﻿using System;

public class Test
{
    static void Main()
    {
        Student student = new Student("Pesho", 25);
        student.PropertyChanged += (sender, eventArgs) =>
        {
            Console.WriteLine("Property changed: {0} (from {1} to {2})",
                eventArgs.PropertyName, eventArgs.OldValue, eventArgs.NewValue);
        };

        student.Name = "Gosho";
        student.Age = 21;
    }
}