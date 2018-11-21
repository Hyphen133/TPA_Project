using TPA.Reflection.Model;

namespace ViewModel.TreeView
{
    class PropertyTreeViewItem : BaseTreeViewItem
    {
        private PropertyMetadata propertyMetadata;

        public PropertyTreeViewItem(PropertyMetadata propertyMetadata)
        {
            this.propertyMetadata = propertyMetadata;
        }

        public new void BuildMyself()
        {
            //TODO
        }
    }
}
