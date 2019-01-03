using DataTransferGraph2.Model;
using Logic.Model;
using System.Collections.Generic;

namespace Logic.DTGMapper
{
    public class HelperDictonaries
    {
        private static Dictionary<TypeMetadata, DTG2TypeMetadata> typeDictonaryForDTG = new Dictionary<TypeMetadata, DTG2TypeMetadata>();

        public static Dictionary<TypeMetadata, DTG2TypeMetadata> TypeDictonaryForDTG { get => typeDictonaryForDTG; set => typeDictonaryForDTG = value; }

        private static Dictionary<DTG2TypeMetadata, TypeMetadata> typeDictonaryForModel = new Dictionary<DTG2TypeMetadata, TypeMetadata>();

        public static Dictionary<DTG2TypeMetadata, TypeMetadata> TypeDictonaryForModel { get => typeDictonaryForModel; set => typeDictonaryForModel = value; }

        public static void ResetDictonaries()
        {
            typeDictonaryForDTG.Clear();
        }
    }
}
