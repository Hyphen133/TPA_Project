
using System.Runtime.Serialization;

namespace TPA.Reflection.Model
{
  [DataContract]
  public enum AccessLevel
  {
        [EnumMemberAttribute]
        IsPublic,
        [EnumMemberAttribute]
        IsProtected,
        [EnumMemberAttribute]
        IsProtectedInternal,
        [EnumMemberAttribute]
        IsPrivate
  }
}