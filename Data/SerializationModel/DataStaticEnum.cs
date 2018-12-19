using System.Runtime.Serialization;

namespace Data
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