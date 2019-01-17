using DataSerializer.SerializationMapper;
using DataSerializer.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.IO;
using System.Runtime.Serialization;
using DataTransferGraph.Model;
using DataTransferGraph;

namespace Serialization
{
    [Export("FileSerializer", typeof(ISerialize))]
    public class XmlSerialize : ISerialize
    {

        public DTGAssemblyMetadata Read(string path)
        {
            XMLAssemblyMetadata model;
            DataContractSerializer dataContractSerializer = new DataContractSerializer(typeof(XMLAssemblyMetadata));
            using (FileStream fileStream = new FileStream(path, FileMode.Open))
            {
                model = (XMLAssemblyMetadata)dataContractSerializer.ReadObject(fileStream);
            }
            return SerializationAssemblyMapper.MapToDTG(model);
        }

        public void Save(DTGAssemblyMetadata assemblyModel, string path)
        {
            XMLAssemblyMetadata assembly = SerializationAssemblyMapper.MapToXML(assemblyModel);
            List<Type> knownTypes = new List<Type>
            {
                typeof(XMLTypeMetadata),
                typeof(XMLNamespaceMetadata),
                typeof(XMLMethodMetadata),
                typeof(XMLParameterMetadata),
                typeof(XMLPropertyMetadata)
            };

            DataContractSerializer dataContractSerializer =
                new DataContractSerializer(typeof(XMLAssemblyMetadata));

            try
            {
                using (FileStream fileStream = new FileStream(path, FileMode.Create))
                {
                    dataContractSerializer.WriteObject(fileStream, assembly);
                }
            }
            catch (Exception)
            {
                
            }
        }
    }
}
