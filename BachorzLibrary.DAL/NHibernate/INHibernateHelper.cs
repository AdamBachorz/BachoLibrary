using BachorzLibrary.DAL;
using BachorzLibrary.DAL.NHibernate;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Text;

namespace BachorzLibrary.DAL.NHibernate
{
    public interface INHibernateHelper
    {
        ISession OpenSession();
        IFluentNHibernateCustomConfig CustomConfig { get; }
    }
}
