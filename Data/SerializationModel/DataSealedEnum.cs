using System.Runtime.Serialization;

namespace Data
{
  [DataContract]
  public enum SealedEnum
  {
    [EnumMember]
    Sealed,
    [EnumMember]
    NotSealed
  }
}