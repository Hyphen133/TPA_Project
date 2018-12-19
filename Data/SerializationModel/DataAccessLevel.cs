using System.Runtime.Serialization;

namespace Data
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