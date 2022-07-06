using BachorzLibrary.DAL.DAO;
using BachorzLibrary.DAL.NHibernate;
using System;
using System.Collections.Generic;
using System.Text;

namespace BachorzLibrary.DAL.Repositories
{
    public class NHibernateBaseRepository<E> : NHibernateBaseDao<E> where E : Entity
    {
        public NHibernateBaseRepository(INHibernateHelper nHibernateHelper) : base(nHibernateHelper)
        {
        }
    }
}
