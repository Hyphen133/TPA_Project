using System.Runtime.Serialization;

namespace Data
{
  [DataContract]
  public enum  VirtualEnum
  {
        [EnumMember]
        NotVirtual,
        [EnumMember]
        Virtual 
  }
}