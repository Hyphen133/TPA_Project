namespace Data.SerializationModel
{
    interface ICRUDRepository<K, V>
    {
        V Get(K key);
        void Add(V value);
        void Update(V value);
        void Delete(K key);
    }
}
