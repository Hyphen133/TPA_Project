using System.ComponentModel.Composition.Hosting;

namespace Model.MEF
{
    public class Mef
    {
        private static CompositionContainer container;

        public static CompositionContainer Container
        {
            get
            {
                if (container == null)
                {
                    var catalog =
                        new DirectoryCatalog(".", "*");

                    container = new CompositionContainer(catalog);
                }

                return container;
            }
        }
    }
}
