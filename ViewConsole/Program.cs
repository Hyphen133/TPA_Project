using System;

namespace ViewConsole
{
    class Program
    {
        private static ConsoleAppClass cac;

        static void Main(string[] args)
        {
            cac = new ConsoleAppClass();
            cac.Start();
        }
    }
}
