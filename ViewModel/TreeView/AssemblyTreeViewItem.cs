using TPA.Reflection.Model;

namespace ViewModel.TreeView
{
    class AssemblyTreeViewItem : BaseTreeViewItem
    {
        private AssemblyMetadata assemblyMetadata;

        public AssemblyTreeViewItem(AssemblyMetadata assemblyMetadata)
        {
            this.assemblyMetadata = assemblyMetadata;
        }

        public new void BuildMyself()
        {
            //TODO
        }
    }
}
