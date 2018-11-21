using TPA.Reflection.Model;

namespace ViewModel.TreeView
{
    public class TypeTreeViewItem : BaseTreeViewItem
    {
        private TypeMetadata typeMetadata;

        public TypeTreeViewItem(TypeMetadata typeMetadata)
        {
            this.typeMetadata = typeMetadata;
        }

        public new void BuildMyself()
        {
            //TODO
        }
    }
}
