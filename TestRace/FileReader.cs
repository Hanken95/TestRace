using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestRace
{
    public static class FileReader
    {
        public static List<string> ReadFile()
        {
            List<string> entrylist = new List<string>();
            string line;
            try
            {
                StreamReader sr = new("C:\\Users\\Luna\\Desktop\\race-results.txt");

                line = sr.ReadLine();

                while (line != null)
                {
                    entrylist.Add(line);
                    
                    
                    line = sr.ReadLine();
                }

                sr.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            return entrylist;
        }
    }
}
