using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.GraphicalData.TreeView;
using TPA.Reflection.Model;
using TPAv2.Services;
using ViewWPF.TreeView;

namespace ViewModel.TreeView
{
    public class DllLoader
    {
        public static void LoadDLL(string PathVariable, ObservableCollection<TreeViewItem> HierarchicalArea)
        {
            if (PathVariable.Substring(PathVariable.Length - 4) == ".dll")
            {
                DataService.LoadAssembly(PathVariable);
                AssemblyMetadata assemblyMetadata = DataService.LoadAssembly(PathVariable);
                TreeViewItem originalRootItem = ConversionServices.ConvertAssemblyMetadata(assemblyMetadata);
                TreeViewItem rootItem = new TreeViewItem();
                rootItem.Name = originalRootItem.Name;
                rootItem.OriginalItem = originalRootItem;
                HierarchicalArea.Add(rootItem);
            }
        }
    }
}
