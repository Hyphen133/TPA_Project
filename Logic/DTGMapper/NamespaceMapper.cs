using DataTransferGraph.Model;
using Logic.Model;
using System.Linq;

namespace Logic.DTGMapper
{
    public class NamespaceMapper
    {
        public static DTGNamespaceMetadata MapToDTGModel(NamespaceMetadata namespaceMetadata)
        {
            var m_NamespaceName = namespaceMetadata.NamespaceName;
            //May be even more beneficial to create all types from all namespaces beforehand
            foreach (var type in namespaceMetadata.Types)
            {
                HelperDictonaries.TypeDictonaryForDTG[type] = TypeMapper.MapToDTGModel(type);
            }
            var m_Types = from type in namespaceMetadata.Types orderby type.TypeName select TypeMapper.FillTypeDTG(HelperDictonaries.TypeDictonaryForDTG[type], type);
            DTGNamespaceMetadata namespaceModel = new DTGNamespaceMetadata {
                NamespaceName = m_NamespaceName,
                Types = m_Types
            };
            
            return namespaceModel;
        }

        public static NamespaceMetadata MapToModel(DTGNamespaceMetadata namespaceMetadata)
        {
            var m_NamespaceName = namespaceMetadata.NamespaceName;
            //May be even more beneficial to create all types from all namespaces beforehand
            foreach (var type in namespaceMetadata.Types)
            {
                HelperDictonaries.TypeDictonaryForModel[type] = TypeMapper.MapToModel(type);
            }
            var m_Types = from type in namespaceMetadata.Types orderby type.TypeName select TypeMapper.FillTypeModel(HelperDictonaries.TypeDictonaryForModel[type], type);
            NamespaceMetadata namespaceModel = new NamespaceMetadata
            {
                NamespaceName = m_NamespaceName,
                Types = m_Types
            };

            return namespaceModel;
        }
    }
}
