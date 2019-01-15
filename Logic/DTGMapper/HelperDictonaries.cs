using DataTransferGraph.Model;
using Logic.Model;
using System.Collections.Generic;

namespace Logic.DTGMapper
{
    public class HelperDictonaries
    {
        private static Dictionary<TypeMetadata, DTGTypeMetadata> typeDictonaryForDTG = new Dictionary<TypeMetadata, DTGTypeMetadata>();

        public static Dictionary<TypeMetadata, DTGTypeMetadata> TypeDictonaryForDTG { get => typeDictonaryForDTG; set => typeDictonaryForDTG = value; }

        private static Dictionary<DTGTypeMetadata, TypeMetadata> typeDictonaryForModel = new Dictionary<DTGTypeMetadata, TypeMetadata>();

        public static Dictionary<DTGTypeMetadata, TypeMetadata> TypeDictonaryForModel { get => typeDictonaryForModel; set => typeDictonaryForModel = value; }

        public static void ResetDictonaries()
        {
            typeDictonaryForDTG.Clear();
        }
    }
}
