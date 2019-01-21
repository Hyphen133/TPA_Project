using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.Primitives;
using System.Reflection;
using System.Xml.Serialization;

namespace Logic.MEF
{
    public class Mef
    {
        private static CompositionContainer container = null;

        public static CompositionContainer Container
        {
            get
            {
                if (container == null)
                {
                    var catalog = new DirectoryCatalog(".", "*");
                    container = new CompositionContainer(catalog);
                }
                return container;
            }
        }
    }
}
