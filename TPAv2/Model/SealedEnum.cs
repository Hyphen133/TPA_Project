
using System.Runtime.Serialization;

namespace TPA.Reflection.Model
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