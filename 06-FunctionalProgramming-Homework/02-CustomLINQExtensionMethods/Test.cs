using System;
using System.Collections.Generic;
using System.Linq;

public class Test
{
    static void Main()
    {
        string[] games = {"Morrowind", "BioShock","Half Life", "The Darkness","Daxter", "System Shock 2"};

        // 1. Extension method WhereNot<T>:
        var filteredGames = games.WhereNot(g => g.StartsWith("H")).Select(g => g);

        PrintCollection(filteredGames);
        Console.WriteLine();

        // 2. Extension method Repeat<T>:
        var repeatedGames = games.Repeat(3);

        PrintCollection(repeatedGames);
        Console.WriteLine();

        // 3. Extension method WhereEndsWith<string>:
        string[] suffixes = { "d", "s" };
        var gamesEndingWithSuff = games.WhereEndsWith<string>(suffixes);

        PrintCollection(gamesEndingWithSuff);
    }

    public static void PrintCollection(IEnumerable<string> processedGames)
    {
        foreach (var filteredGame in processedGames)
        {
            Console.WriteLine(filteredGame);
        }
    }
}