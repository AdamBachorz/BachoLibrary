using BachoLibrary.DAL;
using BachoLibrary.DAL.NHibernate;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Text;

namespace BachoLibrary.DAL.NHibernate
{
    public interface INHibernateHelper
    {
        ISession OpenSession();
        IFluentNHibernateCustomConfig CustomConfig { get; }
    }
}
