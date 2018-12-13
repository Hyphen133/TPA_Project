using Model;
using System.Collections.ObjectModel;
using TPAv2.Services;
using ViewModel.TreeView;

namespace ViewModel.DataManagement
{
    public class DllLoader
    {
        public static void LoadDLL(string PathVariable, ObservableCollection<BaseTreeViewItem> HierarchicalArea)
        {
            if (PathVariable.Substring(PathVariable.Length - 4) == ".dll")
            {
                DataService.LoadAssembly(PathVariable);
                AssemblyMetadata assemblyMetadata = DataService.LoadAssembly(PathVariable);
                BaseTreeViewItem rootItem = new AssemblyTreeViewItem(assemblyMetadata);
                HierarchicalArea.Add(rootItem);
            }
        }
    }
}
