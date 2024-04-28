using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestRace
{
    public enum Error
    {
        NameMissing,
        NameHasNonLetterCharacter,
    }

    public static class ValueChecker
    {
        public static bool NameChecker(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return false;
            }
            return name.All(char.IsLetter);
        }
    }
}
