using System;

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
