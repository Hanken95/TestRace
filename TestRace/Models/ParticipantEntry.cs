
namespace TestRace.Models
{
    public class ParticipantEntry
    {
        private string _name;
        private int _id;
        private TimeOnly _startTime;
        private TimeOnly _finishTime;
        private string _raceType;
        private string _fullEntryString;
        private List<Fault> _faults;

        public  string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public  int ID
        {
            get { return _id; }
            set { _id = value; }
        }

        public  TimeOnly StartTime
        {
            get { return _startTime; }
            set { _startTime = value; }
        }

        public  TimeOnly FinishTime
        {
            get { return _finishTime; }
            set { _finishTime = value; }
        }

        public  string RaceType
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


    }
}
