using Database;
using DataTransferGraph;
using System;
using System.Collections.Generic;
using System.IO;
using Tracing;

namespace Logic
{
    public class Configuration
    {
        public static Dictionary<Type, string> configuredValues = new Dictionary<Type, string>();

        public Configuration()
        {
            string repository = "";
            string logging = "";
            string connectionstring = "";
            string filepath = "";
            string path = Directory.GetParent(Directory.GetCurrentDirectory()).ToString();
            string root = "TPA_Project";
            while (!(path.Substring(path.Length - root.Length) == root))
            {
                path = path.Remove(path.Length - 1);
            }
            path += "\\Logic\\Config.txt";
            using (StreamReader sr = new StreamReader(path))
            {
                string line = sr.ReadLine();
                repository = line.Substring(line.IndexOf("|") + 1);
                line = sr.ReadLine();
                logging = line.Substring(line.IndexOf("|") + 1);
                line = sr.ReadLine();
                connectionstring = line.Substring(line.IndexOf("|") + 1);
                line = sr.ReadLine();
                filepath = line.Substring(line.IndexOf("|") + 1);
            }
            configuredValues.Add(typeof(ISerialize), repository);
            configuredValues.Add(typeof(ITraceSource), logging);
            DatabaseOperations.Path = connectionstring;
            FileTraceSource.filepath = filepath;

        }
    }
}
