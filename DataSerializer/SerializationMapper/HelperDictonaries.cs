using DataSerializer.Model;
using DataTransferGraph.Model;
using System.Collections.Generic;

namespace DataSerializer.SerializationMapper
{
    public class HelperDictonaries
    {
        private static Dictionary<DTGTypeMetadata, XMLTypeMetadata> typeDictonaryToXML = new Dictionary<DTGTypeMetadata, XMLTypeMetadata>();
        public static Dictionary<DTGTypeMetadata, XMLTypeMetadata> TypeDictonaryToXML { get => typeDictonaryToXML; set => typeDictonaryToXML = value; }

        private static Dictionary<XMLTypeMetadata, DTGTypeMetadata> typeDictonaryToDTG = new Dictionary<XMLTypeMetadata, DTGTypeMetadata>();
        public static Dictionary<XMLTypeMetadata, DTGTypeMetadata> TypeDictonaryToDTG { get => typeDictonaryToDTG; set => typeDictonaryToDTG = value; }



        public static void ResetDictonaries()
        {
            typeDictonaryToXML.Clear();
            typeDictonaryToDTG.Clear();
        }
    }
}
