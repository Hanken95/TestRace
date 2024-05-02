using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestRace.Models;

namespace TestRace
{

    public static class ValueChecker
    {
        public static List<Fault> EntireEntryChecker(string[] entry)
        {
            List<Fault> faults = new List<Fault>();
            if (entry.Length != 5)
            {
                faults.AddRange(CheckLenghtOfEntryProblem(entry));
                return faults;
            }
            faults.AddRange(NameChecker(entry[0]));
            faults.AddRange(IDChecker(entry[1]));
            faults.AddRange(TimeChecker(entry[2], entry[3]).startTimeFaults);
            faults.AddRange(TimeChecker(entry[2], entry[3]).finishTimeFaults);
            faults.AddRange(RaceTypeChecker(entry[4]));

            return faults;
        }

        private static List<Fault> CheckLenghtOfEntryProblem(string[] entry)
        {
            List<Fault> faults = new List<Fault>();

            if (entry.Length > 5)
            {
                faults.Add(new Fault("More than 5 values", "There are more than 5 entry values", FaultType.IncorrectAmountOfInputs));
            }
            if (entry.Length < 5)
            {
                faults.Add(new Fault("Less than 5 values", "There are less than 5 entry values", FaultType.IncorrectAmountOfInputs));
            }

            return faults;
        }

        public static List<Fault> NameChecker(string? name)
        {
            List<Fault> faults = new List<Fault>();
            if (string.IsNullOrWhiteSpace(name))
            {
                faults.Add(new Fault("Name missing", "The name of the participant is missing", FaultType.MissingInput));
                return faults;
            }
            else if (!name.All(char.IsLetter))
            {
                faults.Add(new Fault("Nonletter in name", "There is a character other than a letter in the name", FaultType.IncorrectCharacter));
            }
            return faults;
        }

        public static List<Fault> IDChecker(string id)
        {
            List<Fault> faults = new List<Fault>();
            if (string.IsNullOrWhiteSpace(id))
            {
                faults.Add(new Fault("ID missing", "The ID of the participant is missing", FaultType.MissingInput));
                return faults;
            }
            else if (!id.All(char.IsNumber))
            {
                faults.Add(new Fault("Nonnumber in ID", "There are one or more characters other than numbers in the ID", FaultType.IncorrectCharacter));
            }
            return faults;
        }
        
        public static (List<Fault> startTimeFaults, List<Fault> finishTimeFaults) TimeChecker(string startTime, string finishTime)
        {
            List<Fault> startTimeFaults = new List<Fault>();
            List<Fault> finishTimeFaults = new List<Fault>();
            if (string.IsNullOrWhiteSpace(startTime))
            {
                startTimeFaults.Add(new Fault("Start time missing", "The start time of the participant is missing", FaultType.MissingInput));
            }
            if (string.IsNullOrWhiteSpace(finishTime))
            {
                finishTimeFaults.Add(new Fault("Finish time missing", "The finish time of the participant is missing", FaultType.MissingInput));
            }
            if (startTimeFaults.Count > 1 || finishTimeFaults.Count > 1)
            {
                return (startTimeFaults, finishTimeFaults);
            }

            if (startTimeFaults.Count < 1 && !TimeOnly.TryParse(startTime, out var _))
            {
                startTimeFaults.AddRange(CheckTimeCharacters(startTime));
            }
            if (finishTimeFaults.Count < 1 && !TimeOnly.TryParse(finishTime, out var _))
            {
                finishTimeFaults.AddRange(CheckTimeCharacters(finishTime, false));
            }
            if (startTimeFaults.Count < 1 || finishTimeFaults.Count < 1)
            {
                var startTimeAsTimeOnly = TimeOnly.Parse(startTime);
                var finishTimeAsTimeOnly = TimeOnly.Parse(finishTime);
                if (startTimeAsTimeOnly.CompareTo(finishTimeAsTimeOnly) > 0)
                {
                    startTimeFaults.Add(new Fault("Start time before finish time", "The start time is after the finish time", FaultType.TimeOrder));
                }
                else if (startTimeAsTimeOnly.CompareTo(finishTimeAsTimeOnly) == 0)
                {
                    startTimeFaults.Add(new Fault("Start time same as finish time", "The start time the same as the finish time", FaultType.TimeOrder));
                }
            }

            return (startTimeFaults, finishTimeFaults);
        }

        private static List<Fault> CheckTimeCharacters(string time, bool isStartTime = true)
        {
            List<Fault> faults = new List<Fault>();
            string typeOfTime = "start";
            if (!isStartTime)
            {
                typeOfTime = "finish";
            }
            if (time.Count(character => character == ':') == 2)
            {
                var numbers = time.Split(":");
                if (string.IsNullOrWhiteSpace(numbers[0]))
                {
                    faults.Add(new Fault($"Missing hour of {typeOfTime} time", $"The hour of the {typeOfTime} time is missing", FaultType.IncompleteInput));
                }
                else if (!numbers[0].All(char.IsNumber))
                {
                    faults.Add(new Fault($"Nonnumber in hour of {typeOfTime} time", $"There is a nonnumber character in the hour of the {typeOfTime} time", FaultType.IncorrectCharacter));
                }
                else if (int.Parse(numbers[0]) > 23 || int.Parse(numbers[0]) < 0)
                {
                    faults.Add(new Fault($"Hour of {typeOfTime} time outside range", $"The hour of the {typeOfTime} time is above 23 or below 0", FaultType.NumberOutsideRange));
                }
                if (string.IsNullOrWhiteSpace(numbers[1]))
                {
                    faults.Add(new Fault($"Missing minute of {typeOfTime} time", $"The minute of the {typeOfTime} time is missing", FaultType.IncompleteInput));
                }
                else if (!numbers[1].All(char.IsNumber))
                {
                    faults.Add(new Fault($"Nonnumber in minute of {typeOfTime} time", $"There is a nonnumber character in the minute of the {typeOfTime} time", FaultType.IncorrectCharacter));
                }
                else if (int.Parse(numbers[1]) > 59 || int.Parse(numbers[1]) < 0)
                {
                    faults.Add(new Fault($"Minute of {typeOfTime} time outside range", $"The minute of the {typeOfTime} time is above 59 or below 0", FaultType.NumberOutsideRange));
                }
                if (string.IsNullOrWhiteSpace(numbers[2]))
                {
                    faults.Add(new Fault($"Missing second of {typeOfTime} time", $"The second of the {typeOfTime} time is missing", FaultType.IncompleteInput));
                }
                else if (!numbers[2].All(char.IsNumber))
                {
                    faults.Add(new Fault($"Nonnumber in second of {typeOfTime} time", $"There is a nonnumber character in the second of the {typeOfTime} time", FaultType.IncorrectCharacter));
                }
                else if (int.Parse(numbers[2]) > 59 || int.Parse(numbers[2]) < 0)
                {
                    faults.Add(new Fault($"Hour of {typeOfTime} time outside range", $"The hour of the {typeOfTime} time is above 59 or below 0", FaultType.NumberOutsideRange));
                }
            }
            else
            {
                faults.Add(new Fault($"Incorrect amount of : in {typeOfTime} time", $"There are more than or lessa than 3 : signs in the {typeOfTime} time", FaultType.IncorrectAmountOfCharacters));
            }

            return faults;
        }
        
        public static List<Fault> RaceTypeChecker(string raceType)
        {
            List<Fault> faults = new List<Fault>();

            if (raceType != "1000m" && raceType != "eggRace" && raceType != "sackRace")
            {
                faults.Add(new Fault("Incorrect race type", "The race type isn't one of the accepted 3 race types", FaultType.Racetype));
            }

            return faults;
        }
    }
}
