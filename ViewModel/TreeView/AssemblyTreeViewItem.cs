using TPA.Reflection.Model;

namespace ViewModel.TreeView
{
    class AssemblyTreeViewItem : BaseTreeViewItem
    {
        private AssemblyMetadata assemblyMetadata;

        public AssemblyTreeViewItem(AssemblyMetadata assemblyMetadata) : base()
        {
            
            this.assemblyMetadata = assemblyMetadata;
            Name = assemblyMetadata.Name;
        }

        override public void BuildMyself()
        {
            Children.Clear();
            foreach(NamespaceMetadata nm in assemblyMetadata.Namespaces)
            {
                Children.Add(new NamespaceTreeViewItem(nm));
            }
        }
    }
}
