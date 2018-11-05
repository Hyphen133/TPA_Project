using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPA.Reflection.Model;

namespace TPAv2.ViewModel
{
    public class TypeElement : Element
    {
        public TypeMetadata type;
        public TypeElement(Element parent, TypeMetadata type) : base (parent)
        {
            Name = type.TypeName;
            this.type = type;
        }
        public override void Expand()
        {
            children.Clear();
            foreach(PropertyMetadata prop in type.Properties)
            {
                children.Add(new TypeElement(this, prop.TypeMetadata));
            }
        }
    }
}
