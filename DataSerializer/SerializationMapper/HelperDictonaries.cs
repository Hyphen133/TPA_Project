using DataSerializer.Model;
using DataTransferGraph2.Model;
using System.Collections.Generic;

namespace DataSerializer.SerializationMapper
{
    public class HelperDictonaries
    {
        private static Dictionary<DTG2TypeMetadata, XMLTypeMetadata> typeDictonary = new Dictionary<DTG2TypeMetadata, XMLTypeMetadata>();

        public static Dictionary<DTG2TypeMetadata, XMLTypeMetadata> TypeDictonary { get => typeDictonary; set => typeDictonary = value; }

        public static void ResetDictonaries()
        {
            typeDictonary.Clear();
        }
    }
}
