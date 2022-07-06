using BachorzLibrary.Common.DbModel;
using BachorzLibrary.NHibernate.Extensions;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace BachorzLibrary.DAL.NHibernate
{
    public abstract class FluentNHibernateEntityMapping<E> : ClassMap<E> where E : Entity
    {
        public FluentNHibernateEntityMapping(string tableName, IdentityStrategy identityStrategy = IdentityStrategy.Sequance) : base()
        {
            Table(tableName);
            Id(x => x.Id, "id")
                .GeneratedBy
                .Strategy(identityStrategy, tableName);
                //.Sequence(tableName + "_seq");
        }
    }

}
