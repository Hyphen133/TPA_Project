﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;

namespace ViewConsole
{
    class ConsoleBrowse : IBrowse
    {
        public string GetFilePath()
        {
            Console.WriteLine("Plese enter path to dll library.");
            return Console.ReadLine();
        }

        public string GetFolderPath()
        {
            Console.WriteLine("Plese enter path to dll library.");
            return Console.ReadLine();
        }
    }
}
