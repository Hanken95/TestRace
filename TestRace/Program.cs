using TestRace;
using TestRace.Models;

internal class Program
{
    private static void Main()
    {
        var a = ParticipantEntry.ParticipantEntryCreator("Booba,11412,12:20:00,12:44:10,eggRace");

        

        List<ParticipantEntry> list = new List<ParticipantEntry>();
        ParticipantEntry boobaEgg = ParticipantEntry.ParticipantEntryCreator("Booba,11412,12:20:00,12:44:10,eggRace");
        list.Add(boobaEgg);
        ParticipantEntry boobaSack = ParticipantEntry.ParticipantEntryCreator("Booba,11412,12:20:00,12:30:10,sackRace");
        list.Add(boobaSack);
        ParticipantEntry booba1000m = ParticipantEntry.ParticipantEntryCreator("Booba,11412,12:20:00,12:39:10,1000m");
        list.Add(booba1000m);
        list.Add(ParticipantEntry.ParticipantEntryCreator("Phil,11112,12:20:00,12:48:10,eggRace"));
        list.Add(ParticipantEntry.ParticipantEntryCreator("Phil,11112,12:20:00,12:47:10,sackRace"));
        list.Add(ParticipantEntry.ParticipantEntryCreator("Phil,11112,12:20:00,12:45:10,1000m"));

        list.Add(ParticipantEntry.ParticipantEntryCreator(",11112,12:20:00,12:45:10,1000m"));
        list.Add(ParticipantEntry.ParticipantEntryCreator(",11112,12:20:00,13:45:10,1000m"));
        list.Add(ParticipantEntry.ParticipantEntryCreator("Philip,11112,12:20:00,12:45:10,1000m"));
        list.Add(ParticipantEntry.ParticipantEntryCreator("Phil,11112,12:20:00,12:45:10,1000m"));

        var groupedByPartisipantsList = list.GroupBy(pe => pe.Name).ToList();


        foreach (var duplicatesItem in groupedByPartisipantsList)
        {
            foreach (var item in duplicatesItem)
            {
                Console.WriteLine(item.Name);
                Console.WriteLine(item.ID);
            }
        }

        var participants = RaceResultsCalculator.participants;

        var winner = RaceResultsCalculator.CalculateWinner();

        var b = new TimeSpan(10, 10, 0) + new TimeSpan(10, 10, 10);




        //TimeOnly timeOnly1 = new(10, 10, 10);
        //TimeOnly timeOnly2 = new(10, 20, 15);
        //var a = timeOnly2 - timeOnly1;
        //var ass = ":2.3".Split(":");
        //var works = TimeOnly.TryParse("1s0:20:30", out var _);
        //var worsks = TimeOnly.TryParse(":59:59", out var _);
        //var woks = TimeOnly.TryParse("23:59:59", out var _);
        //var woaks = TimeOnly.TryParse("23:59:59:15", out var _);
        //var woraks = TimeOnly.TryParse("-1:59:59", out var _);
        //var w4orsks = TimeOnly.TryParse("23:59::59", out var _);
        //var w4ordsks = TimeOnly.TryParse("23:59:59:", out var _);
        //var w4ofrdsks = TimeOnly.TryParse("23;59:59", out var _);
        //var faultsReturned = ValueChecker.TimeChecker("10:13:26");
        //Console.WriteLine(ValueChecker.NameChecker("Hej1san"));

        foreach (var fault in ValueChecker.TimeChecker("10:10:10", "10:20:40").startTimeFaults)
        {
            Console.WriteLine(fault.Name);
        }
        Console.WriteLine();
        foreach (var fault in ValueChecker.TimeChecker("25:60:377", "10:234:4s0").startTimeFaults)
        {
            Console.WriteLine(fault.Name);
        }
        Console.WriteLine();
        foreach (var fault in ValueChecker.TimeChecker("1010:10", "10:20:40").startTimeFaults)
        {
            Console.WriteLine(fault.Name);
        }
        Console.WriteLine();
        foreach (var fault in ValueChecker.TimeChecker("40::10", "102040").startTimeFaults)
        {
            Console.WriteLine(fault.Name);
        }
        Console.WriteLine();
        foreach (var fault in ValueChecker.TimeChecker("10:20:10", "10:10:10").startTimeFaults)
        {
            Console.WriteLine(fault.Name);
        }
        Console.WriteLine();











    }
}