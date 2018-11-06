
using System.Runtime.Serialization;

namespace TPA.Reflection.Model
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