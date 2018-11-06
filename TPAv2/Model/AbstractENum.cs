
using System.Runtime.Serialization;

namespace TPA.Reflection.Model
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