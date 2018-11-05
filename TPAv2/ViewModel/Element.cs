using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPAv2.ViewModel
{
    public class Element
    {
        public string Name;
        public Element parent;
        public List<Element> children;

        public Element(Element parent)
        {
            this.parent = parent;
            children = new List<Element>();
        }

        public virtual void Expand()
        {

        }
    }
}
