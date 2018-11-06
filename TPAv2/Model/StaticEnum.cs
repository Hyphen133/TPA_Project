
using System.Runtime.Serialization;

namespace TPA.Reflection.Model
{
  [DataContract]
  public enum StaticEnum
  {
    [EnumMember]
    NotStatic,
    [EnumMember]
    Static
  }
}