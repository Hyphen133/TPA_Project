using TPA.Reflection.Model;

namespace ViewModel.TreeView
{
    public class PropertyTreeViewItem : BaseTreeViewItem
    {
        private PropertyMetadata propertyMetadata;

        public PropertyTreeViewItem(PropertyMetadata propertyMetadata)
        {
            this.propertyMetadata = propertyMetadata;
            Name = propertyMetadata.Name;
        }

        override public void BuildMyself()
        {
            Children.Clear();
            Children.Add(new TypeTreeViewItem(propertyMetadata.TypeMetadata));
        }
    }
}
