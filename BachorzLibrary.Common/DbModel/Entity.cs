using System;

namespace BachorzLibrary.Common.DbModel
{
    [Serializable]
    public abstract class Entity<T>
    {
        public virtual T Id { get; set; }
    }

    [Serializable]
    public abstract class Entity : Entity<int>
    {
    }
}
