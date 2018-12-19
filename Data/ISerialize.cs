﻿using System;

namespace Data
{
    public interface ISerialize
    {
        Object Read(Type type, string path);
        void Write(object obj, string path);
    }
}
