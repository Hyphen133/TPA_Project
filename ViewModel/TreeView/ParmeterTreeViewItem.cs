using TPA.Reflection.Model;

namespace ViewModel.TreeView
{
    class ParmeterTreeViewItem : BaseTreeViewItem
    {
        private ParameterMetadata parameterMetadata;

        public ParmeterTreeViewItem(ParameterMetadata parameterMetadata)
        {
            this.parameterMetadata = parameterMetadata;
        }

        public new void BuildMyself()
        {
            //TODO
        }
    }
}
