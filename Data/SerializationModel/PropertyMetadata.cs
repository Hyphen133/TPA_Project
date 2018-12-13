﻿using System.Runtime.Serialization;

namespace Data
{
    [DataContract(IsReference = true)]
    public class PropertyMetadata
    {
        #region private
        [DataMember]
        private string m_Name;
        [DataMember]
        private TypeMetadata m_TypeMetadata;

        public string Name { get => m_Name; set => m_Name = value; }
        public TypeMetadata TypeMetadata { get => m_TypeMetadata; set => m_TypeMetadata = value; }
        #endregion
    }
}