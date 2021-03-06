﻿using DataSerializer.Model;
using DataTransferGraph.Model;
using System.Linq;

namespace DataSerializer.SerializationMapper
{
    public class SerializationNamespaceMapper
    {
        public static XMLNamespaceMetadata MapToXML(DTGNamespaceMetadata namespaceMetadata)
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

        public static DTGNamespaceMetadata MapToDTG(XMLNamespaceMetadata namespaceMetadata)
        {
            var m_NamespaceName = namespaceMetadata.NamespaceName;
            //May be even more beneficial to create all types from all namespaces beforehand
            foreach (var type in namespaceMetadata.TypesL)
            {
                HelperDictonaries.TypeDictonaryToDTG[type] = SerializationTypeMapper.MapToDTG(type);
            }
            var m_Types = from type in namespaceMetadata.TypesL orderby type.TypeName select SerializationTypeMapper.fillType(HelperDictonaries.TypeDictonaryToDTG[type], type);
            DTGNamespaceMetadata namespaceModel = new DTGNamespaceMetadata
            {
                NamespaceName = m_NamespaceName,
                Types = m_Types
            };

            return namespaceModel;
        }
    }
}
