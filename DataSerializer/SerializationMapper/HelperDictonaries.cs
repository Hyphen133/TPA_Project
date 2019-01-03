using DataSerializer.Model;
using DataTransferGraph2.Model;
using System.Collections.Generic;

namespace DataSerializer.SerializationMapper
{
    public class HelperDictonaries
    {
        private static Dictionary<DTG2TypeMetadata, XMLTypeMetadata> typeDictonaryToXML = new Dictionary<DTG2TypeMetadata, XMLTypeMetadata>();
        public static Dictionary<DTG2TypeMetadata, XMLTypeMetadata> TypeDictonaryToXML { get => typeDictonaryToXML; set => typeDictonaryToXML = value; }

        private static Dictionary<XMLTypeMetadata, DTG2TypeMetadata> typeDictonaryToDTG = new Dictionary<XMLTypeMetadata, DTG2TypeMetadata>();
        public static Dictionary<XMLTypeMetadata, DTG2TypeMetadata> TypeDictonaryToDTG { get => typeDictonaryToDTG; set => typeDictonaryToDTG = value; }



        public static void ResetDictonaries()
        {
            typeDictonaryToXML.Clear();
            typeDictonaryToDTG.Clear();
        }
    }
}
