using System.Collections.Generic;

namespace DataTransferGraph2.Model
{
    public class DTG2MethodMetadata
    {
        private string m_Name;
        private IEnumerable<DTG2TypeMetadata> m_GenericArguments;
        private DTG2TypeMetadata m_ReturnType;
        private bool m_Extension;
        private IEnumerable<DTG2ParameterMetadata> m_Parameters;

        public string Name { get => m_Name; set => m_Name = value; }
        public IEnumerable<DTG2TypeMetadata> GenericArguments { get => m_GenericArguments; set => m_GenericArguments = value; }
        public DTG2TypeMetadata ReturnType { get => m_ReturnType; set => m_ReturnType = value; }
        public IEnumerable<DTG2ParameterMetadata> Parameters { get => m_Parameters; set => m_Parameters = value; }
    }
}