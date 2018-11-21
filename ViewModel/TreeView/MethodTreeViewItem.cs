using TPA.Reflection.Model;

namespace ViewModel.TreeView
{
    class MethodTreeViewItem : BaseTreeViewItem
    {
        private MethodMetadata methodMetadata;

        public MethodTreeViewItem(MethodMetadata methodMetadata)
        {
            this.methodMetadata = methodMetadata;
        }

        public new void BuildMyself()
        {
            //TODO
        }
    }
}
