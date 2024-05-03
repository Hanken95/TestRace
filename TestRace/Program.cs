using Tournament;
using Tournament.Models;

internal class Program
{
    private static void Main()
    {
        Console.WriteLine("Welcome to the tournament");
        Console.WriteLine();
        Console.WriteLine("Please enter the codepath to the document with the " +
            "race results or enter 1 to use the default race results");

        //string codePath = Console.ReadLine();
        //if (codePath == "1")
        //{
        //    var winner = RaceResultsCalculator.CalculateWinner();
        //}
        //else
        //{
        //    try
        //    {

        //    }
        //}

        //var participants = RaceResultsCalculator.participants;

        var winner = RaceResultsCalculator.CalculateWinner();

        var baw = 1;

        
    }
}