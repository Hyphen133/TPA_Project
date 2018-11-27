using System;

namespace Serializer
{
    class DatabaseSerializer : ISerialize
    {
        private string connectionString;
        private string id;
        public string ConnectionString { get => connectionString; set => connectionString = value; }
        public string ID { get => id; set => id = value; }

        public DatabaseSerializer(string connectionString, string id)
        {
            ConnectionString = connectionString;
            ID = id;
        }

        public object Read(Type type)
        {
            throw new NotImplementedException();
        }

        public void Write(object obj)
        {
            throw new NotImplementedException();
        }
    }
}
