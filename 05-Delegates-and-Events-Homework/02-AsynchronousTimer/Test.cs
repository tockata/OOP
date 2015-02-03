﻿using System;
using System.Threading;

public class TestTimer
{
    public static void asyncMethod()
    {
        Console.WriteLine("I am asynchronous method.");
    }

    static void Main()
    {
        AsyncTimer aTimer = new AsyncTimer(asyncMethod, 1000, 50);
        aTimer.Start();

        //the code below is for testing asynchronous execution of method:
        int count = 1000;
        while (count >= 0)
        {
            Thread.Sleep(200);
            count--;
            Console.WriteLine(count);
        }
    }
}