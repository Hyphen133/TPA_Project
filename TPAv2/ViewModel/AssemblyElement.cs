using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPA.Reflection.Model;

namespace TPAv2.ViewModel
{
    public class AssemblyElement : Element
    {
        public AssemblyMetadata assembly;
        public AssemblyElement(Element parent, AssemblyMetadata assembly) : base(parent)
        {
            Name = assembly.Name;
            this.assembly = assembly;
        }

        public override void Expand()
        {
            children.Clear();
            foreach(NamespaceMetadata n in assembly.Namespaces)
            {
                children.Add(new NamespaceElement(this, n));
            }
        }
    }
}
