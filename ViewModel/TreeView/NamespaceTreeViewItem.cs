using TPA.Reflection.Model;

namespace ViewModel.TreeView
{
    class NamespaceTreeViewItem : BaseTreeViewItem
    {
        private NamespaceMetadata namespaceMetadata;

        public NamespaceTreeViewItem(NamespaceMetadata namespaceMetadata)
        {
            this.namespaceMetadata = namespaceMetadata;
        }

        public new void BuildMyself()
        {
            //TODO
        }
    }
}
