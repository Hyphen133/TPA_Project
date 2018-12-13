using System.Runtime.Serialization;

namespace Data
{
  [DataContract]
  public enum AbstractEnum
  {
        [EnumMember]
        NotAbstract,
        [EnumMember]
        Abstract
  }
}