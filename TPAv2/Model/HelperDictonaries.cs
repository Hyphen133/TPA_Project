using System;
using System.Collections.Generic;

namespace Model.Model
{
    public class HelperDictonaries
    {
        private static Dictionary<Type, TypeMetadata> typeDictonary = new Dictionary<Type, TypeMetadata>();

        public static Dictionary<Type, TypeMetadata> TypeDictonary { get => typeDictonary; set => typeDictonary = value; }

        public static void resetDictonaries()
        {
            typeDictonary.Clear();
        }

        public static TypeMetadata CreateTypeMetadata(Type type)
        {
            if (!typeDictonary.ContainsKey(type))
            {
                HelperDictonaries.TypeDictonary[type] = new TypeMetadata(type);

            }
            return HelperDictonaries.TypeDictonary[type];
        }
    }
}
