namespace DataTransferGraph2.Model
{
    public class DTG2ParameterMetadata
    {
        public DTG2ParameterMetadata() { }

        public DTG2ParameterMetadata(string name, DTG2TypeMetadata typeMetadata)
        {
            m_Name = name;
            m_TypeMetadata = typeMetadata;
        }

        #region private
        private string m_Name;
        private DTG2TypeMetadata m_TypeMetadata;
        #endregion

        public string Name { get => m_Name; set => m_Name = value; }
        public DTG2TypeMetadata TypeMetadata { get => m_TypeMetadata; set => m_TypeMetadata = value; } 
    }
}