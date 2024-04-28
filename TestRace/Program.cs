using TestRace;

internal class Program
{
    private static void Main()
    {
        TimeOnly timeOnly = new(10, 10, 10);

        Console.WriteLine(ValueChecker.NameChecker("Hej1san"));
        Console.WriteLine(ValueChecker.NameChecker(""));
        Console.WriteLine(ValueChecker.NameChecker("  "));
        Console.WriteLine(ValueChecker.NameChecker(null));

        Console.WriteLine(ValueChecker.NameChecker("Hejsan"));

        string line;
        try
        {
            //Pass the file path and file name to the StreamReader constructor
            StreamReader sr = new("C:\\Users\\Luna\\Desktop\\race-results.txt");
            //Read the first line of text
            line = sr.ReadLine();
            //Continue to read until you reach end of file
            Console.WriteLine(timeOnly.ToString("HH:mm:ss"));
            while (line != null)
            {
                //write the line to console window
                Console.WriteLine(line);
                string[] entryValues = line.Split(",");
                if (entryValues.Length > 0)
                {
                    foreach (string entryValue in entryValues)
                    {
                        Console.WriteLine(entryValue);
                    }
                }
                //Read the next line
                line = sr.ReadLine();
            }
            //close the file
            sr.Close();
            Console.ReadLine();
        }
        catch (Exception e)
        {
            Console.WriteLine("Exception: " + e.Message);
        }
        finally
        {
            Console.WriteLine("Executing finally block.");
        }
    }
}