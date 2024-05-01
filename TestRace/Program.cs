using TestRace;

internal class Program
{
    private static void Main()
    {
        TimeOnly timeOnly = new(10, 10, 10);
        var a = ":2.3".Split(":");
        var works = TimeOnly.TryParse("1s0:20:30", out var _);
        var worsks = TimeOnly.TryParse(":59:59", out var _);
        var woks = TimeOnly.TryParse("23:59:59", out var _);
        var woaks = TimeOnly.TryParse("23:59:59:15", out var _);
        var woraks = TimeOnly.TryParse("-1:59:59", out var _);
        var w4orsks = TimeOnly.TryParse("23:59::59", out var _);
        var w4ordsks = TimeOnly.TryParse("23:59:59:", out var _);
        var w4ofrdsks = TimeOnly.TryParse("23;59:59", out var _);
        //var faultsReturned = ValueChecker.TimeChecker("10:13:26");
        //Console.WriteLine(ValueChecker.NameChecker("Hej1san"));

        foreach (var fault in ValueChecker.TimeChecker("10:10:10", "10:20:40"))
        {
            Console.WriteLine(fault.Name);
        }
        Console.WriteLine();
        foreach (var fault in ValueChecker.TimeChecker("25:60:377", "10:234:4s0"))
        {
            Console.WriteLine(fault.Name);
        }
        Console.WriteLine();
        foreach (var fault in ValueChecker.TimeChecker("1010:10", "10:20:40"))
        {
            Console.WriteLine(fault.Name);
        }
        Console.WriteLine();
        foreach (var fault in ValueChecker.TimeChecker("40::10", "102040"))
        {
            Console.WriteLine(fault.Name);
        }
        Console.WriteLine();
        foreach (var fault in ValueChecker.TimeChecker("10:20:10", "10:10:10"))
        {
            Console.WriteLine(fault.Name);
        }
        Console.WriteLine();










        string line;
        //try
        //{
        //    //Pass the file path and file name to the StreamReader constructor
        //    StreamReader sr = new("C:\\Users\\Luna\\Desktop\\race-results.txt");
        //    //Read the first line of text
        //    line = sr.ReadLine();
        //    //Continue to read until you reach end of file
        //    Console.WriteLine(timeOnly.ToString("HH:mm:ss"));
        //    while (line != null)
        //    {
        //        //write the line to console window
        //        Console.WriteLine(line);
        //        string[] entryValues = line.Split(",");
        //        if (entryValues.Length > 0)
        //        {
        //            foreach (string entryValue in entryValues)
        //            {
        //                Console.WriteLine(entryValue);
        //            }
        //        }
        //        //Read the next line
        //        line = sr.ReadLine();
        //    }
        //    //close the file
        //    sr.Close();
        //    Console.ReadLine();
        //}
        //catch (Exception e)
        //{
        //    Console.WriteLine("Exception: " + e.Message);
        //}
    }
}