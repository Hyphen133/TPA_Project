using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPA.Reflection.Model;

namespace TPAv2.ViewModel
{
    public class NamespaceElement : Element
    {
        public NamespaceMetadata namespaceMetadata;
        public NamespaceElement(Element parent, NamespaceMetadata namespaceMetadata) : base(parent)
        {
            Name = namespaceMetadata.NamespaceName;
            this.namespaceMetadata = namespaceMetadata;
        }

        public override void Expand()
        {
            children.Clear();
            foreach(TypeMetadata t in namespaceMetadata.Types)
            {
                children.Add(new TypeElement(this, t));
            }
        }
    }
}
