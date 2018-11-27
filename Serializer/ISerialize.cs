using System;

namespace Serializer
{
    public interface ISerialize
    {
        Object Read(Type type);
        void Write(object obj);
    }
}
