using TPA.Reflection.Model;

namespace ViewModel.TreeView
{
    public class NamespaceTreeViewItem : BaseTreeViewItem
    {
        private NamespaceMetadata namespaceMetadata;

        public NamespaceTreeViewItem(NamespaceMetadata namespaceMetadata)
        {
            this.namespaceMetadata = namespaceMetadata;
            Name = namespaceMetadata.NamespaceName;
        }

        override public void BuildMyself()
        {
            Children.Clear();
            foreach(TypeMetadata tm in namespaceMetadata.Types)
            {
                Children.Add(new TypeTreeViewItem(tm));
            }
        }
    }
}
