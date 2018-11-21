using System;
using System.Collections.Generic;
using System.Text;
using TP.GraphicalData.TreeView;
using ViewModel;

namespace ViewConsole
{
    class ConsoleAppClass
    {
        private Stack<TreeViewItem> parenting;
        private TreeViewItem currentElement;
        private int currentChildValue;
        private List<List<String>> above;
        private List<String> parents;
        private List<List<String>> below;

        public void Start()
        {
            Console.Clear();
            parenting = new Stack<TreeViewItem>();
            MyViewModel myViewModel = new MyViewModel(new ConsoleBrowse());
            if(myViewModel.Click_Browse.CanExecute(null))
            {
                myViewModel.Click_Browse.Execute(null);
            }
            if(myViewModel.Click_Button.CanExecute(null))
            {
                myViewModel.Click_Button.Execute(null);
            }
            Console.Clear();

            Console.WriteLine(myViewModel.HierarchicalAreas[0].Name);

            currentElement = myViewModel.HierarchicalAreas[0];

            above = new List<List<string>>();
            parents = new List<string>();
            below = new List<List<string>>();

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
                            parents.RemoveAt(parents.Count - 1);
                            currentElement = parenting.Pop();
                            currentElement.IsExpanded = false;
                        }
                        break;
                    case ConsoleKey.RightArrow:
                        if (currentElement.Children.Count > 0)
                        {
                            parents.Add(currentElement.Name);
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
                                parents.RemoveAt(parents.Count - 1);
                                currentElement = parenting.Pop();
                                currentElement.IsExpanded = false;
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
            if (parents.Count > 0) all.AppendLine(parents[0]);
            for (int i = 0; i < above.Count; i++)
            {
                foreach (string s in above[i])
                {
                    for (int k = 0; k <= i; k++)
                    {
                        all.Append("\t");
                    }
                    all.AppendLine(s);
                }
                if (parents.Count > i + 1)
                {
                    for (int k = 0; k <= i; k++)
                    {
                        all.Append("\t");
                    }
                    all.AppendLine(parents[i + 1]);
                }
            }

            if (parents.Count > 1)
            {
                for (int i = 0; i < parents.Count - 1; i++)
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
                    for (int k = 0; k < below.Count - i; k++)
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
