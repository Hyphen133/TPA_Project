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
            assemblyModel.SetValues();
            return assemblyModel;
        }

        public static DTG2AssemblyMetadata MapToDTG(XMLAssemblyMetadata assemblyMetadata)
        {
            HelperDictonaries.ResetDictonaries();

            DTG2AssemblyMetadata assemblyModel = new DTG2AssemblyMetadata
            {
                Name = assemblyMetadata.Name,
                Namespaces = from XMLNamespaceMetadata _namespace in assemblyMetadata.NamespacesL
                             select SerializationNamespaceMapper.MapToDTG(_namespace)
            };
            return assemblyModel;
        }
    }
}
