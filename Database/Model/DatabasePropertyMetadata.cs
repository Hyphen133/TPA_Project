namespace Database.Model
{
    public class DatabasePropertyMetadata
    {
        private int m_PropertyID;
        private string m_Name;
        private DatabaseTypeMetadata m_TypeMetadata;

        public int PropertyID { get => m_PropertyID; set => m_PropertyID = value; }
        public string Name { get => m_Name; set => m_Name = value; }
        public DatabaseTypeMetadata TypeMetadata { get => m_TypeMetadata; set => m_TypeMetadata = value; }
    }
}
