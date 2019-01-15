namespace DataTransferGraph.Model
{
    public class DTGParameterMetadata
    {
        private string m_Name;
        private DTGTypeMetadata m_TypeMetadata;

        public string Name { get => m_Name; set => m_Name = value; }
        public DTGTypeMetadata TypeMetadata { get => m_TypeMetadata; set => m_TypeMetadata = value; }
    }
}