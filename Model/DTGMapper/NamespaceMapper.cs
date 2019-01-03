using DataTransferGraph2.Model;
using Logic.Model;
using System.Linq;

namespace Logic.DTGMapper
{
    public class NamespaceMapper
    {
        public static DTG2NamespaceMetadata MapToDTGModel(NamespaceMetadata namespaceMetadata)
        {
            var m_NamespaceName = namespaceMetadata.NamespaceName;
            //May be even more beneficial to create all types from all namespaces beforehand
            
            foreach (var type in namespaceMetadata.Types)
            {
                HelperDictonaries.TypeDictonary[type] = TypeMapper.MapToDTGModel(type);
            }
            var m_Types = from type in namespaceMetadata.Types orderby type.TypeName select TypeMapper.fillType(HelperDictonaries.TypeDictonary[type], type);
            
            DTG2NamespaceMetadata namespaceModel = new DTG2NamespaceMetadata {
                NamespaceName = m_NamespaceName,
                Types = m_Types
            };
            
            return namespaceModel;
        }

        /*public NamespaceMetadata MapFromDTGModel(DTGNamespaceModel model)
        {
            NamespaceMetadata namespaceMetadata = new NamespaceMetadata
            {
                NamespaceName = model.NamespaceName
            };
            if (model.Types != null)
                namespaceMetadata.Types = model.Types.Select(n => TypeMapper.EmitType((DTGTypeModel)n)).ToList();
            return namespaceMetadata;
        }*/

    }
}
