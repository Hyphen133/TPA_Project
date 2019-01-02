using Logic.Model;

namespace ViewModel.TreeView
{
    public class TypeTreeViewItem : BaseTreeViewItem
    {
        private TypeMetadata typeMetadata;

        public TypeTreeViewItem(TypeMetadata typeMetadata)
        {
            this.typeMetadata = typeMetadata;
            if (typeMetadata != null) Name = typeMetadata.TypeName;
        }

        override public void BuildMyself()
        {
            if (typeMetadata != null)
            {
                Children.Clear();
                foreach (var v in typeMetadata.Properties)
                {
                    Children.Add(new PropertyTreeViewItem(v));
                }
                foreach (var v in typeMetadata.Methods)
                {
                    Children.Add(new MethodTreeViewItem(v));
                }
                foreach (var v in typeMetadata.Constructors)
                {
                    Children.Add(new MethodTreeViewItem(v));
                }
            }
        }
    }
}
