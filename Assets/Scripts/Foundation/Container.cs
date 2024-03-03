using System;
using System.Linq;
using System.Collections.Generic;

namespace MultiPong.Foundation
{
    public class Container<T>
    {
        private readonly Dictionary<Type, T> entities;

        public Container()
        {
            this.entities = new Dictionary<Type, T>();
        }

        public void Add(T entity)
        {
            entities.Add(entity.GetType(), entity);
        }

        public void Remove(T entity)
        {
            entities.Remove(entity.GetType());
        }

        public bool IsExists(Type type)
        {
            return entities.ContainsKey(type);
        }

        public TEntity Get<TEntity>() where TEntity : T
        {
            Type type = typeof(TEntity);

            if (IsExists(type))
                return (TEntity)entities[type];
            throw new Exception($"The {typeof(T).Name} of type '{type}' does not found.");
        }

        public IEnumerable<T> GetAll()
        {
            return entities.Select(entity => entity.Value);
        }
    }
}