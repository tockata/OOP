using System;
using System.Collections.Generic;
using System.Text;

public static class Extensions
{
    public static string Substring(this StringBuilder str, int startIndex, int length)
    {
        if (startIndex < 0)
        {
            Console.WriteLine("Start index can not be negative number!");
            throw new ArgumentOutOfRangeException();
        }

        if (startIndex + length > str.Length)
        {
            Console.WriteLine("Start index + length must be smaller than string length!");
            throw new ArgumentOutOfRangeException();
        }

        return str.ToString().Substring(startIndex, length);
    }

    public static StringBuilder RemoveText(this StringBuilder str, string text)
    {
        string tempStr = str.ToString().ToLower();
        int index = tempStr.IndexOf(text.ToLower());

        while (index != -1)
        {
            str = str.Remove(index, text.Length);
            tempStr = str.ToString().ToLower();
            index = tempStr.IndexOf(text.ToLower());
        }
            
        return str;
    }

    public static StringBuilder AppendAll<T>(this StringBuilder str, IEnumerable<T> items)
    {
        foreach (var item in items)
        {
            str.Append(item.ToString(), 0, item.ToString().Length);
            str.Append(" ");
        }

        return str;
    }
}