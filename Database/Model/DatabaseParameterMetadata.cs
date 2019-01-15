namespace Database.Model
{
    public class DatabaseParameterMetadata
    {
        private string m_Name;
        private DatabaseTypeMetadata m_TypeMetadata;

        public string Name { get => m_Name; set => m_Name = value; }
        public DatabaseTypeMetadata TypeMetadata { get => m_TypeMetadata; set => m_TypeMetadata = value; }
    }
}
