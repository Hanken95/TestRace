using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace TestRace
{
    public class ParticipantEntry
    {
        private string _name;
        private int _id;
        private TimeOnly _startTime;
        private TimeOnly _finishTime;
        private string _raceType;
        private string _fullEntryString;

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



    }
}
