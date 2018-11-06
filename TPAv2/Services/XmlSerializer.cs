﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using TPA.Reflection.Model;

namespace TPAv2.Services
{
    public class XmlSerializer
    {
        public static void SerializeAssembly(AssemblyMetadata assembly, String filepath)
        {
            DataContractSerializer serializer = new DataContractSerializer(assembly.GetType());

            using (FileStream fs = new FileStream(filepath, FileMode.Create))
            {
                serializer.WriteObject(fs, assembly);
            }
        }

        public static AssemblyMetadata DeserializeAssembly(String filepath)
        {
            DataContractSerializer serializer = new DataContractSerializer(typeof(AssemblyMetadata));


            AssemblyMetadata assemblyMetadata = null;
            using (FileStream fs = new FileStream(filepath, FileMode.Open))
            {
                XmlDictionaryReaderQuotas dictReader = new XmlDictionaryReaderQuotas();
                dictReader.MaxDepth = 1000;
                XmlDictionaryReader reader = XmlDictionaryReader.CreateTextReader(fs, dictReader);

                assemblyMetadata = (AssemblyMetadata)serializer.ReadObject(reader);
            }
            return assemblyMetadata;
        }
    }
}