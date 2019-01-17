using System.IO;

namespace Logic
{
    public class Configuration
    {
        public Configuration()
        {
            string repository = "";
            string logging = "";
            string connectionstring = "";
            string filepath = "";
            using (StreamReader sr = new StreamReader(@"C:\Users\Radioaktywny\Desktop\TPA_Project\Logic\Config.txt"))
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
            var c = 0;            
        }
    }
}
