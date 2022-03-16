﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace BachoLibrary.DAL
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