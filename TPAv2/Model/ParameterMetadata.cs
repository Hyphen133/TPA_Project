
using System.Runtime.Serialization;

namespace TPA.Reflection.Model
{
  [DataContract(IsReference = true)]
  public class ParameterMetadata
  {

    public ParameterMetadata(string name, TypeMetadata typeMetadata)
    {
      this.m_Name = name;
      this.m_TypeMetadata = typeMetadata;
    }
    
    //private vars
    [DataMember]
    private string m_Name;
    [DataMember]
    private TypeMetadata m_TypeMetadata;

        public string Name { get => m_Name; set => m_Name = value; }
        public TypeMetadata TypeMetadata { get => m_TypeMetadata; set => m_TypeMetadata = value; }
    }
}