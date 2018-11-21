using TPA.Reflection.Model;

namespace ViewModel.TreeView
{
    class ParameterTreeViewItem : BaseTreeViewItem
    {
        private ParameterMetadata parameterMetadata;

        public ParameterTreeViewItem(ParameterMetadata parameterMetadata)
        {
            this.parameterMetadata = parameterMetadata;
            Name = parameterMetadata.Name;
        }

        override public void BuildMyself()
        {
            Children.Clear();
            Children.Add(new TypeTreeViewItem(parameterMetadata.TypeMetadata));
        }
    }
}
