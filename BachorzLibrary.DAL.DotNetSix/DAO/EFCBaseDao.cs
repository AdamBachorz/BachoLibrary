using BachorzLibrary.Common.DbModel;
using BachorzLibrary.DAL.DAO;
using BachorzLibrary.DAL.DotNetSix.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BachorzLibrary.DAL.DotNetSix.DAO
{
    public class EFCBaseDao<E, DbC, IdType> : IBaseDao<E, IdType> where E : Entity<IdType> where DbC : BaseDbContext
    {
        protected DbC _db;

        public EFCBaseDao(DbC db)
        {
            _db = db;
        }

        public virtual void Delete(IdType id)
        {
            var entityToDelete = GetOneById(id);
            _db.Entry(entityToDelete).State = EntityState.Deleted;
            _db.SaveChanges();
        }

        public virtual IList<E> GetAll()
        {
            return _db.Set<E>().ToList();
        }

        public IQueryable<E> GetAllLazy()
        {
            throw new NotImplementedException();
        }

        public IList<E> GetByIds(IEnumerable<IdType> ids)
        {
            return _db.Set<E>().Where(e => ids.Contains(e.Id)).ToList();
        }

        public virtual IQueryable<E> DbSet()
        {
            var result = _db.Set<E>();
            return result;
        }

        public virtual E GetLatest()
        {
            return _db.Set<E>().OrderByDescending(x => x.Id).FirstOrDefault();
        }

        public virtual E GetOneById(IdType id)
        {
            var result = _db.Set<E>().FirstOrDefault(x => x.Id.Equals(id));
            return result;
        }

        public virtual E Insert(E entity)
        {
            _db.Entry(entity).State = EntityState.Added;
            _db.SaveChanges();

            return entity;
        }

        public virtual void Update(IdType id, E entity)
        {
            throw new NotImplementedException();
        }

        public virtual void Update(E entity)
        {
            _db.Entry(entity).State = EntityState.Modified;
            _db.SaveChanges();
        }

    }
}
