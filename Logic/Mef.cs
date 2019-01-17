﻿using System.ComponentModel.Composition.Hosting;

namespace Logic.MEF
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

        public static T Inject<T>(string name)
        {
            return Container.GetExportedValue<T>(name);
        }
    }
}
