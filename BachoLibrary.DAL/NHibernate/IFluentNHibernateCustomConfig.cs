using FluentNHibernate.Cfg;
using System;
using System.Collections.Generic;
using System.Text;

namespace BachoLibrary.DAL.NHibernate
{
    public interface IFluentNHibernateCustomConfig : ICustomConfig
    {
        Action<MappingConfiguration> Mapping { get; set; }
        FluentConfiguration BuildNHibernateConfiguration();
    }
}
