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
        static void Main(string[] args)
        {
            MyViewModel myViewModel = new MyViewModel();
            myViewModel.PathVariable = "C:\\Users\\stz\\Google Drive\\Studia\\Informatyka\\5 Semestr\\Technologie programowania adaptacyjnego\\Projekt\\TPA_Project\\TPAv2\\TPA.ApplicationArchitecture.dll";
            Console.WriteLine("oko");
            myViewModel.Click_Browse.Execute(null);

            Console.WriteLine(myViewModel.HierarchicalAreas.Count);
            Console.WriteLine(myViewModel.HierarchicalAreas[0].Name);


            Console.ReadKey();
        }
    }
}
