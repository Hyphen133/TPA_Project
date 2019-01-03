using DataSerializer.Model;
using DataTransferGraph2.Model;
using System.Linq;

namespace DataSerializer.SerializationMapper
{
    public class SerializationNamespaceMapper
    {
        public static XMLNamespaceMetadata MapToXML(DTG2NamespaceMetadata namespaceMetadata)
        {
            var m_NamespaceName = namespaceMetadata.NamespaceName;
            //May be even more beneficial to create all types from all namespaces beforehand
            foreach (var type in namespaceMetadata.Types)
            {
                HelperDictonaries.TypeDictonaryToXML[type] = SerializationTypeMapper.MapToXML(type);
            }
            var m_Types = from type in namespaceMetadata.Types orderby type.TypeName select SerializationTypeMapper.FillTypeXML(HelperDictonaries.TypeDictonaryToXML[type], type);
            XMLNamespaceMetadata namespaceModel = new XMLNamespaceMetadata
            {
                NamespaceName = m_NamespaceName,
                Types = m_Types
            };

            return namespaceModel;
        }

        public static DTG2NamespaceMetadata MapToDTG(XMLNamespaceMetadata namespaceMetadata)
        {
            var m_NamespaceName = namespaceMetadata.NamespaceName;
            //May be even more beneficial to create all types from all namespaces beforehand
            foreach (var type in namespaceMetadata.Types)
            {
                HelperDictonaries.TypeDictonaryToDTG[type] = SerializationTypeMapper.MapToDTG(type);
            }
            var m_Types = from type in namespaceMetadata.Types orderby type.TypeName select SerializationTypeMapper.fillType(HelperDictonaries.TypeDictonaryToDTG[type], type);
            DTG2NamespaceMetadata namespaceModel = new DTG2NamespaceMetadata
            {
                NamespaceName = m_NamespaceName,
                Types = m_Types
            };

            return namespaceModel;
        }
    }
}
