using Database.Model;
using DataTransferGraph.Model;
using System.Collections.Generic;

namespace Database.DatabaseMapper
{
    public class HelperDictonaries
    {
        private static Dictionary<DTGTypeMetadata, DatabaseTypeMetadata> typeDictonaryToDatabase = new Dictionary<DTGTypeMetadata, DatabaseTypeMetadata>();
        public static Dictionary<DTGTypeMetadata, DatabaseTypeMetadata> TypeDictonaryToDatabase { get => typeDictonaryToDatabase; set => typeDictonaryToDatabase = value; }

        private static Dictionary<DatabaseTypeMetadata, DTGTypeMetadata> typeDictonaryToDTG = new Dictionary<DatabaseTypeMetadata, DTGTypeMetadata>();
        public static Dictionary<DatabaseTypeMetadata, DTGTypeMetadata> TypeDictonaryToDTG { get => typeDictonaryToDTG; set => typeDictonaryToDTG = value; }

        public static void ResetDictonaries()
        {
            typeDictonaryToDatabase.Clear();
            typeDictonaryToDTG.Clear();
        }
    }
}
