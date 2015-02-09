using System;
using System.Collections.Generic;
using System.Text;

public class Test
{
    static void Main()
    {
        StringBuilder str1 = new StringBuilder("Implement the folloWing following extension methods for the class StringBuilder.");

        // extension method Substring(int startIndex, int length):
        string result = str1.Substring(0, 23);
        Console.WriteLine(result);

        // extension method RemoveText(string text):
        str1 = str1.RemoveText("following");
        Console.WriteLine(str1);

        // extension method AppendAll<T>(IEnumerable<T> items):
        List<int> nums = new List<int>()
        {
            55, 25, 100, -200, 999
        };

        StringBuilder str2 = new StringBuilder();
        str2.AppendAll(nums);
        Console.WriteLine(str2);
    }
}