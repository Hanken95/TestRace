﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Tournament
{
    public static class FileReader
    {
        public static List<string> ReadFile(string path)
        {
            return File.ReadAllLines(path).ToList();
        }
        public static List<string> ReadFile()
        {
            var path = @"..\..\..\Files\race-results.txt";
            return File.ReadAllLines(path).ToList();
            
        }

    }
}
