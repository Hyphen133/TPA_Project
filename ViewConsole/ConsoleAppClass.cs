using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.GraphicalData.TreeView;
using ViewModel.TreeView;

namespace ViewConsole
{
    class ConsoleAppClass
    {
        private Stack<TreeViewItem> parenting;
        private TreeViewItem currentElement;
        private int currentChildValue;
        private List<List<String>> above;
        private List<List<String>> below;
        private string path;

        public ConsoleAppClass(String path)
        {
            this.path = path;
        }

        public void Start()
        {
            Console.Clear();
            parenting = new Stack<TreeViewItem>();
            BaseViewModel myViewModel = new BaseViewModel();
            myViewModel.PathVariable = path;
            DllLoader.LoadDLL(path, myViewModel.HierarchicalAreas);

            Console.WriteLine(myViewModel.HierarchicalAreas[0].Name);

            currentElement = myViewModel.HierarchicalAreas[0];

            above = new List<List<string>>();
            below = new List<List<string>>();
            above.Add(new List<string>());
            below.Add(new List<string>());

            while (true)
            {
                System.ConsoleKey c = Console.ReadKey().Key;

                switch (c)
                {
                    case ConsoleKey.DownArrow:
                        if (parenting.Count > 0)
                        {
                            above.RemoveAt(above.Count - 1);
                            above.Add(new List<string>());
                            below.RemoveAt(above.Count - 1);
                            below.Add(new List<string>());

                            if (currentChildValue < parenting.Peek().Children.Count - 1)
                            {
                                currentChildValue++;
                                currentElement = parenting.Peek().Children[currentChildValue];
                            }

                            for (int i = 0; i < currentChildValue; i++)
                            {
                                above[above.Count - 1].Add(parenting.Peek().Children[i].Name);
                            }

                            for (int i = currentChildValue + 1; i < parenting.Peek().Children.Count; i++)
                            {
                                below[below.Count - 1].Add(parenting.Peek().Children[i].Name);
                            }
                        }
                        break;
                    case ConsoleKey.UpArrow:
                        if (parenting.Count > 0)
                        {
                            above.RemoveAt(above.Count - 1);
                            above.Add(new List<string>());
                            below.RemoveAt(above.Count - 1);
                            below.Add(new List<string>());

                            if (currentChildValue > 0)
                            {
                                currentChildValue--;
                                currentElement = parenting.Peek().Children[currentChildValue];
                            }

                            for (int i = 0; i < currentChildValue; i++)
                            {
                                above[above.Count - 1].Add(parenting.Peek().Children[i].Name);
                            }

                            for (int i = currentChildValue + 1; i < parenting.Peek().Children.Count; i++)
                            {
                                below[below.Count - 1].Add(parenting.Peek().Children[i].Name);
                            }
                        }
                        break;
                    case ConsoleKey.LeftArrow:
                        if (parenting.Count > 0)
                        {
                            currentChildValue = 0;
                            above.RemoveAt(above.Count - 1);
                            below.RemoveAt(below.Count - 1);
                            currentElement = parenting.Pop();
                            currentElement.IsExpanded = false;

                            if (above[above.Count - 1][above[above.Count - 1].Count - 1] == currentElement.Name)
                            {
                                above[above.Count - 1].RemoveAt(above[above.Count - 1].Count - 1);
                            }
                        }
                        break;
                    case ConsoleKey.RightArrow:
                        if (currentElement.Children.Count > 0)
                        {
                            if (above[above.Count - 1].Count == 0)
                            {
                                above[above.Count - 1].Add(currentElement.Name);
                            }
                            else if (above[above.Count - 1][above[above.Count - 1].Count - 1] != currentElement.Name)
                            {
                                above[above.Count - 1].Add(currentElement.Name);
                            }
                            above.Add(new List<string>());
                            below.Add(new List<string>());

                            int pom = currentChildValue;

                            parenting.Push(currentElement);
                            currentElement.IsExpanded = true;
                            if (currentElement.Children.Count == 0)
                            {
                                currentChildValue = pom;
                                above.RemoveAt(above.Count - 1);
                                below.RemoveAt(below.Count - 1);
                                currentElement = parenting.Pop();
                                currentElement.IsExpanded = false;

                                if (above[above.Count - 1][above[above.Count - 1].Count - 1] == currentElement.Name)
                                {
                                    above[above.Count - 1].RemoveAt(above[above.Count - 1].Count - 1);
                                }
                            }
                            else
                            {
                                if (currentElement.Children.Count > 1)
                                {
                                    for (int i = 1; i < currentElement.Children.Count; i++)
                                    {
                                        below[below.Count - 1].Add(currentElement.Children[i].Name);
                                    }
                                }
                                currentElement = currentElement.Children[0];
                            }
                        }
                        break;
                }
                Display();
            }
        }
        private void Display()
        {
            StringBuilder all = new StringBuilder();
            for (int i = 0; i < above.Count; i++)
            {
                foreach (string s in above[i])
                {
                    for (int k = 0; k < i; k++)
                    {
                        all.Append("\t");
                    }
                    all.AppendLine(s);
                }
            }

            if (above.Count > 1)
            {
                for (int i = 0; i < above.Count - 2; i++)
                {
                    all.Append("--------");
                }
            }
            if (parenting.Count > 0)
            {
                all.Append("------->");
            }
            all.AppendLine(currentElement.Name);

            for (int i = 0; i < below.Count; i++)
            {
                foreach (string s in below[below.Count - i - 1])
                {
                    for (int k = 0; k < below.Count - i - 1; k++)
                    {
                        all.Append("\t");
                    }
                    all.AppendLine(s);
                }
            }
            Console.Clear();
            Console.WriteLine(all.ToString());
        }
    }
}
