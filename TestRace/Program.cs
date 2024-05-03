using System.Reflection;
using Tournament;
using Tournament.Models;

internal class Program
{
    private static void Main()
    {
        Console.WriteLine("Welcome to the tournament");
        Console.WriteLine();

        Participant winner;

        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("To use the default race results, press 1");
            Console.WriteLine("To use a race results file that is located in the Files folder, press 2");
            Console.WriteLine("To specify a entire path for a race results file press 3");
            switch (Console.ReadKey(true).KeyChar)
            {
                case '1':
                    DefaultRaceResultsFileWinner();
                    exit = true;
                    break;
                case '2':
                    RaceResultsInFilesFolderWinner();
                    exit= true;
                    break;
                case '3':
                    RaceResultsFromCompletePathWinner();
                    exit= true;
                    break;
                default:
                    Console.WriteLine("Incorrect input");
                    Console.WriteLine();
                    Console.WriteLine("Press any key to go back");
                    Console.ReadKey();
                    break;
            }
            Console.Clear();    
        }

    }
    private static void DefaultRaceResultsFileWinner()
    {
        var winner = RaceResultsCalculator.CalculateWinner();
        var participants = RaceResultsCalculator.participants;
        DisplayTournamentInfo(winner, participants);
    }
   
    private static void RaceResultsInFilesFolderWinner()
    {
        Console.Clear();
        Console.WriteLine("Enter the text file name");
        string? fileName = Console.ReadLine();
        while (fileName == null || string.IsNullOrWhiteSpace(fileName))
        {
            Console.Clear();
            Console.WriteLine("Incorrect input, try again");
            fileName = Console.ReadLine();
        }
        try
        {
            List<Participant> participants = Participant.ParticipantListCreator(FileReader.ReadFileInFilesFolder(fileName));
            Participant winner = RaceResultsCalculator.CalculateWinner(participants);
            DisplayTournamentInfo(winner, participants);
        }
        catch (Exception ex)
        {
            Console.Clear();
            Console.WriteLine("The process gave an error:");
            Console.WriteLine(ex.Message);
            Console.WriteLine();
            Console.WriteLine("To try again 1");
            Console.WriteLine("To quit the program, press any other key");
            switch (Console.ReadKey(true).KeyChar)
            {
                case '1':
                    RaceResultsInFilesFolderWinner();
                    break;
                default:
                    break;
                
            }
        }
    }

    private static void RaceResultsFromCompletePathWinner()
    {
        Console.Clear();
        Console.WriteLine("Enter the path for the text file");
        string? filePath = Console.ReadLine();
        while (filePath == null || string.IsNullOrWhiteSpace(filePath))
        {
            Console.Clear();
            Console.WriteLine("Incorrect input, try again");
            filePath = Console.ReadLine();
        }
        try
        {
            List<Participant> participants = Participant.ParticipantListCreator(FileReader.ReadFile(filePath));
            Participant winner = RaceResultsCalculator.CalculateWinner(participants);
            DisplayTournamentInfo(winner, participants);
        }
        catch (Exception ex)
        {
            Console.Clear();
            Console.WriteLine("The process gave an error:");
            Console.WriteLine(ex.Message);
            Console.WriteLine();
            Console.WriteLine("To try again 1");
            Console.WriteLine("To quit the program, press any other key");
            switch (Console.ReadKey(true).KeyChar)
            {
                case '1':
                    RaceResultsInFilesFolderWinner();
                    break;
                default:
                    break;

            }
        }
    }

    private static void DisplayTournamentInfo(Participant winner, List<Participant> participants)
    {
        bool exit = false;
        while (!exit)
        {
            Console.Clear();
            Console.WriteLine($"The winner is {winner.Name}!");
            Console.WriteLine("To get info about the winner, press 1");
            Console.WriteLine("To get info about all the participants, press 2");
            Console.WriteLine("To quit the program, press 3");
            switch (Console.ReadKey(true).KeyChar)
            {
                case '1':
                    Console.Clear();
                    Console.WriteLine("Winner:");
                    DisplayParticipantInfo(winner);
                    Console.WriteLine();
                    Console.WriteLine("Press any key to go back");
                    Console.ReadKey(false);
                    break;
                case '2':
                    Console.Clear();
                    foreach (Participant participant in participants)
                    {
                        DisplayParticipantInfo(participant);
                        Console.WriteLine();
                    }
                    Console.WriteLine();
                    Console.WriteLine("Press any key to go back");
                    Console.ReadKey();
                    break;
                case '3':
                    Console.Clear();
                    return;
                default:
                    Console.WriteLine("Incorrect input");
                    Console.WriteLine();
                    Console.WriteLine("Press any key to go back");
                    Console.ReadKey();
                    break;
            }
        }
    }

    private static void DisplayParticipantInfo(Participant participant)
    {
        if (participant.Name != null)
        {
            Console.WriteLine($"Name: {participant.Name}");
        }
        else
        {
            Console.WriteLine($"Name: missing");
        }
        if (participant.ID != null)
        {
            Console.WriteLine($"ID: {participant.ID}");
        }
        else
        {
            Console.WriteLine($"ID: missing");
        }
        Console.WriteLine($"Race entries: {participant.ParticipantEntries.Count}");
        if (participant.CombinedRaceTime != null)
        {
            Console.WriteLine($"Combined racetime: {participant.CombinedRaceTime}");
        }
        else
        {
            Console.WriteLine($"Combined racetime: did not compete in valid races");
        }
        if (participant.EntryFaults != null && participant.EntryFaults.Count > 0)
        {
            Console.WriteLine($"Amount of faults in entries: {participant.EntryFaults.Count}");
        }
        else
        {
            Console.WriteLine($"Amount of faults in entries: no faults");
        }
    }
}
