using DataSerializer.Model;
using DataTransferGraph2.Model;
using System.ComponentModel.Composition;
using System.Linq;

namespace DataSerializer.SerializationMapper
{
    [Export]
    class SerializationAssemblyMapper
    {
        public static XMLAssemblyMetadata MapToXML(DTG2AssemblyMetadata assemblyMetadata)
        {
            HelperDictonaries.ResetDictonaries();

            XMLAssemblyMetadata assemblyModel = new XMLAssemblyMetadata
            {
                Name = assemblyMetadata.Name,
                Namespaces = from DTG2NamespaceMetadata _namespace in assemblyMetadata.Namespaces
                             select SerializationNamespaceMapper.MapToXML(_namespace)
            };
            return assemblyModel;
        }
    }
}
