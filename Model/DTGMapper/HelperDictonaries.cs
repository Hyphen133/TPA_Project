using DataTransferGraph2.Model;
using Logic.Model;
using System.Collections.Generic;

namespace Logic.DTGMapper
{
    public class HelperDictonaries
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
                TypeDictonary[type] = TypeMapper.MapToDTGModel(type);
            }
            return TypeDictonary[type];
        }
    }
}
