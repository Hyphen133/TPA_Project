using DataSerializer.Model;
using DataTransferGraph.Model;
using System.ComponentModel.Composition;
using System.Linq;

namespace DataSerializer.SerializationMapper
{
    public class SerializationAssemblyMapper
    {
        public static XMLAssemblyMetadata MapToXML(DTGAssemblyMetadata assemblyMetadata)
        {
            HelperDictonaries.ResetDictonaries();

            XMLAssemblyMetadata assemblyModel = new XMLAssemblyMetadata
            {
                Name = assemblyMetadata.Name,
                Namespaces = from DTGNamespaceMetadata _namespace in assemblyMetadata.Namespaces
                             select SerializationNamespaceMapper.MapToXML(_namespace)
            };
            assemblyModel.SetValues();
            return assemblyModel;
        }

        public static DTGAssemblyMetadata MapToDTG(XMLAssemblyMetadata assemblyMetadata)
        {
            HelperDictonaries.ResetDictonaries();

            DTGAssemblyMetadata assemblyModel = new DTGAssemblyMetadata
            {
                Name = assemblyMetadata.Name,
                Namespaces = from XMLNamespaceMetadata _namespace in assemblyMetadata.NamespacesL
                             select SerializationNamespaceMapper.MapToDTG(_namespace)
            };
            return assemblyModel;
        }
    }
}
