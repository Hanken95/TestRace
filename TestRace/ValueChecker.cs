using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestRace
{
    public enum Fault
    {
        NameMissing,
        NameHasNonLetterCharacter,
    }

    public static class ValueChecker
    {
        public static List<Fault> EntireEntryChecker(string[] entry)
        {
            List<Fault> faults = new List<Fault>();
            //if (entry.Length != 5)
            //{
            //    CheckLenghtOfEntryProblem(entry);
            //    return faults;
            //}
            if (NameChecker(entry[0]).Count > 0)
            {
                foreach (var fault in NameChecker(entry[0]))
                {
                    faults.Add(fault);
                }
            }
            return faults;
        }

        public static List<Fault> NameChecker(string name)
        {
            List<Fault> faults = new List<Fault>();
            if (string.IsNullOrWhiteSpace(name))
            {
                faults.Add(Fault.NameMissing);
                return faults;
            }
            if (name.All(char.IsLetter))
            {
                faults.Add(Fault.NameHasNonLetterCharacter);
            }
            return faults;
        }

    }
}
