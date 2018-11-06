using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.GraphicalData.TreeView;
using TPAv2.Services;
using ViewWPF.TreeView;

namespace ViewConsole
{
    class Program
    {
        private static ConsoleAppClass cac;

        static void Main(string[] args)
        {
            Console.WriteLine("Plese enter path to dll library.");
            string path = Console.ReadLine();
            cac = new ConsoleAppClass(path);
            cac.Start();
        }
    }
}
