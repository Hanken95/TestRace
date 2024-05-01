using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestRace.Models
{

    //public enum Fault
    //{
    //    NameMissing,
    //    NameHasNonLetterCharacter,
    //    IdMissing,
    //    IdHasNonNumberCharacter,
    //    StartTimeMissing,
    //    FinishTimeMissing,
    //    StartTimeHasNonNumberCharacter
    //}

    public enum FaultType
    {
        MissingInput,
        IncompleteInput,
        IncorrectCharacter,
        NumberOutsideRange,
        IncorrectAmountOfCharacters,
        TimeOrder
    }

    public class Fault(string name, string message, FaultType faultType)
    {
        private string _name = name;
        private string _message = message;
        private FaultType _faultType = faultType;

        public string Name
        {
            get { return _name; }
            init { _name = value; }
        }

        public string Message
        {
            get { return _message; }
            init { _message = value; }
        }

        public FaultType FaultType
        {
            get { return _faultType; }
            init { _faultType = value; }
        }

    }
}
