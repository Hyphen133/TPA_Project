using TPA.Reflection.Model;

namespace ViewModel.TreeView
{
    public class MethodTreeViewItem : BaseTreeViewItem
    {
        private MethodMetadata methodMetadata;

        public MethodTreeViewItem(MethodMetadata methodMetadata)
        {
            this.methodMetadata = methodMetadata;
            Name = methodMetadata.Name;
        }

        override public void BuildMyself()
        {
            Children.Clear();
            Children.Add(new TypeTreeViewItem(methodMetadata.ReturnType));
            foreach(var v in methodMetadata.Parameters)
            {
                Children.Add(new ParameterTreeViewItem(v));
            }
        }
    }
}
