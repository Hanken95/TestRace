﻿using System;
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
        public static List<Fault> NameChecker(string name)
        {
            List<Fault> faults = new List<Fault>();
            if (string.IsNullOrWhiteSpace(name))
            {
                faults.Add(Fault.NameMissing);
            }
            if (name.All(char.IsLetter))
            {
                faults.Add(Fault.NameHasNonLetterCharacter);
            }
            return faults;
        }
    }
}