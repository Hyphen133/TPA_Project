namespace Model.Model
{
    public class ParameterMetadata
    {
        public ParameterMetadata() { }

        public ParameterMetadata(string name, TypeMetadata typeMetadata)
        {
            this.m_Name = name;
            this.m_TypeMetadata = typeMetadata;
        }

        #region private
        private string m_Name;
        private TypeMetadata m_TypeMetadata;
        #endregion

        public string Name { get => m_Name; set => m_Name = value; }
        public TypeMetadata TypeMetadata { get => m_TypeMetadata; set => m_TypeMetadata = value; } 
    }
}