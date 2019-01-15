using System.Collections.Generic;

namespace DataTransferGraph.Model
{
    public class DTGMethodMetadata
    {
        private string m_Name;
        private IEnumerable<DTGTypeMetadata> m_GenericArguments;
        private DTGTypeMetadata m_ReturnType;
        private IEnumerable<DTGParameterMetadata> m_Parameters;

        public string Name { get => m_Name; set => m_Name = value; }
        public IEnumerable<DTGTypeMetadata> GenericArguments { get => m_GenericArguments; set => m_GenericArguments = value; }
        public DTGTypeMetadata ReturnType { get => m_ReturnType; set => m_ReturnType = value; }
        public IEnumerable<DTGParameterMetadata> Parameters { get => m_Parameters; set => m_Parameters = value; }
    }
}