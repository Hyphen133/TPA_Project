
namespace TPA.Reflection.Model
{
  public class ParameterMetadata
  {

    public ParameterMetadata(string name, TypeMetadata typeMetadata)
    {
      this.m_Name = name;
      this.m_TypeMetadata = typeMetadata;
    }
    
    //private vars
    private string m_Name;
    private TypeMetadata m_TypeMetadata;

        public string Name { get => m_Name; set => m_Name = value; }
        public TypeMetadata TypeMetadata { get => m_TypeMetadata; set => m_TypeMetadata = value; }
    }
}