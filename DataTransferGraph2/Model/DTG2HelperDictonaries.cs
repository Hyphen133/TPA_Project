using Logic.Model;
using System.Collections.Generic;

namespace DataTransferGraph2.Model
{
    public class DTG2HelperDictonaries
    {
        private static Dictionary<TypeMetadata, DTG2TypeMetadata> typeDictonary = new Dictionary<TypeMetadata, DTG2TypeMetadata>();

        public static Dictionary<TypeMetadata, DTG2TypeMetadata> TypeDictonary { get => typeDictonary; set => typeDictonary = value; }

        public static void ResetDictonaries()
        {
            typeDictonary.Clear();
        }

        public static DTG2TypeMetadata CreateTypeMetadata(TypeMetadata type)
        {
            if (!typeDictonary.ContainsKey(type))
            {
                TypeDictonary[type] = new DTG2TypeMetadata(type);

            }
            return TypeDictonary[type];
        }
    }
}
