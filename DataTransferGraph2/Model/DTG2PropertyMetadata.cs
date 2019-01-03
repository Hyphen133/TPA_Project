namespace DataTransferGraph2.Model
{
    public class DTG2PropertyMetadata
    {
        private string m_Name;
        private DTG2TypeMetadata m_TypeMetadata;

        public string Name { get => m_Name; set => m_Name = value; }
        public DTG2TypeMetadata TypeMetadata { get => m_TypeMetadata; set => m_TypeMetadata = value; }
    }
}