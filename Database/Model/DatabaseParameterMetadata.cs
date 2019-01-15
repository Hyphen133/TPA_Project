namespace Database.Model
{
    public class DatabaseParameterMetadata
    {
        private int m_ParameterID;
        private string m_Name;
        private DatabaseTypeMetadata m_TypeMetadata;

        public int ParameterID { get => m_ParameterID; set => m_ParameterID = value; }
        public string Name { get => m_Name; set => m_Name = value; }
        public DatabaseTypeMetadata TypeMetadata { get => m_TypeMetadata; set => m_TypeMetadata = value; }
    }
}
