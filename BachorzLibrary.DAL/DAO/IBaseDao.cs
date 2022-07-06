using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BachorzLibrary.DAL.DAO
{
    public interface IBaseDao<E, IdType>
    {
        E GetOneById(IdType id);
        E GetLatest();
        IList<E> GetAll();
        IQueryable<E> GetAllLazy();
        E Insert(E entity);
        void Update(IdType id, E entity);
        void Update(E entity);
        void Delete(IdType id);
    }
}
