using Database.Model;
using DataTransferGraph.Model;
using System.Linq;

namespace Database.DatabaseMapper
{
    public class DatabaseNamespaceMapper
    {
        public static DatabaseNamespaceMetadata MapToDatabase(DTGNamespaceMetadata namespaceMetadata)
        {
            var m_NamespaceName = namespaceMetadata.NamespaceName;
            //May be even more beneficial to create all types from all namespaces beforehand
            foreach (var type in namespaceMetadata.Types)
            {
                HelperDictonaries.TypeDictonaryToDatabase[type] = DatabaseTypeMapper.MapToDatabase(type);
            }
            var m_Types = from type in namespaceMetadata.Types orderby type.TypeName select DatabaseTypeMapper.FillTypeDatabase(HelperDictonaries.TypeDictonaryToDatabase[type], type);
            foreach (var t in m_Types)
            {
                t.NamespaceName = m_NamespaceName;
            }
            DatabaseNamespaceMetadata namespaceModel = new DatabaseNamespaceMetadata
            {
                NamespaceName = m_NamespaceName,
                Types = m_Types
            };

            return namespaceModel;
        }

        public static DTGNamespaceMetadata MapToDTG(DatabaseNamespaceMetadata namespaceMetadata)
        {
            var m_NamespaceName = namespaceMetadata.NamespaceName;
            //May be even more beneficial to create all types from all namespaces beforehand
            foreach (var type in namespaceMetadata.TypesL)
            {
                HelperDictonaries.TypeDictonaryToDTG[type] = DatabaseTypeMapper.MapToDTG(type);
            }
            var m_Types = from type in namespaceMetadata.TypesL orderby type.TypeName select DatabaseTypeMapper.fillType(HelperDictonaries.TypeDictonaryToDTG[type], type);
            DTGNamespaceMetadata namespaceModel = new DTGNamespaceMetadata
            {
                NamespaceName = m_NamespaceName,
                Types = m_Types
            };
            return namespaceModel;
        }
    }
}
