namespace Tournament.Models
{
    public class ParticipantEntry
    {
        private string? _name;
        private int? _id;
        private TimeOnly? _startTime;
        private TimeOnly? _finishTime;
        private string? _raceType;
        private string _fullEntryString;
        private List<Fault> _faults;


        

        private ParticipantEntry(string? name, int? id, TimeOnly? startTime, TimeOnly? finishTime, string? raceType, string fullEntryString, List<Fault> faults)
        {
            _name = name;
            _id = id;
            _startTime = startTime;
            _finishTime = finishTime;
            _raceType = raceType;
            _fullEntryString = fullEntryString;
            _faults = faults;
        }
            

        public string? Name
        {
            get { return _name; }
            set 
            {
                if (ValueChecker.NameChecker(_name).Count == 0)
                { 
                    _name = value;
                }
            }
        }

        public int? ID
        {
            get { return _id; }
            set { _id = value; }
        }

        public TimeOnly? StartTime
        {
            get { return _startTime; }
            set { _startTime = value; }
        }

        public TimeOnly? FinishTime
        {
            get { return _finishTime; }
            set { _finishTime = value; }
        }

        public TimeSpan? RaceTime
        {
            get 
            {
                if (FinishTime != null && StartTime != null)
                {
                    return FinishTime - StartTime; 
                }
                else
                {
                    return null;
                }
            }
        }

        public string? RaceType
        {
            get { return _raceType; }
            set { _raceType = value; }
        }

        public string FullEntryString
        {
            get { return _fullEntryString; }
            set { _fullEntryString = value; }
        }

        public List<Fault> Faults
        {
            get { return _faults; }
            set { _faults = value; }
        }
        public static ParticipantEntry ParticipantEntryCreator(string entry)
        {
            string[]? entryValues = entry.Split(',');

            var faults = ValueChecker.EntireEntryChecker(entryValues);

            if (faults.Count == 0)
            {
                string name = entryValues[0];
                int id = int.Parse(entryValues[1]);
                TimeOnly startTime = TimeOnly.Parse(entryValues[2]);
                TimeOnly finishTime = TimeOnly.Parse(entryValues[3]);
                string raceType = entryValues[4];

                return new ParticipantEntry(name, id, startTime, finishTime, raceType, entry, faults);
            }
            else
            {
                if (faults.Exists(fault => fault.FaultType == FaultType.IncorrectAmountOfInputs))
                {
                    return new ParticipantEntry(null, null, null, null, null, entry, faults);
                }

                string? name = entryValues[0];
                int? id = null;
                TimeOnly? startTime = null;
                TimeOnly? finishTime = null;
                string? raceType = null;
                
                if (ValueChecker.NameChecker(name).Count > 0)
                {
                    name = null;
                }

                if (ValueChecker.IDChecker(entryValues[1]).Count == 0)
                {
                    id = int.Parse(entryValues[1]);
                }

                var timeFaults = ValueChecker.TimeChecker(entryValues[2], entryValues[3]);
                if (timeFaults.startTimeFaults.Count == 0 || timeFaults.startTimeFaults.Count == 1 && timeFaults.startTimeFaults.Any(fault => fault.FaultType == FaultType.TimeOrder))
                {
                    startTime = TimeOnly.Parse(entryValues[2]);
                }
                if (timeFaults.finishTimeFaults.Count == 0)
                {
                    finishTime = TimeOnly.Parse(entryValues[3]);
                }

                if (ValueChecker.RaceTypeChecker(entryValues[4]).Count == 0)
                {
                    raceType = entryValues[4];
                }

                return new ParticipantEntry(name, id, startTime, finishTime, raceType, entry, faults);
            }
        }
    }
}
