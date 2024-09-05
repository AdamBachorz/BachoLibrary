using BachorzLibrary.Common.DbModel;
using BachorzLibrary.DAL.DotNetSix.DAO;
using Microsoft.EntityFrameworkCore;

namespace BachorzLibrary.DAL.DotNetSix.Repositories
{
    public class EFCBaseRepository<E, DbC, IdType> : EFCBaseDao<E, DbC, IdType> where E : Entity<IdType> where DbC : DbContext
    {
        public EFCBaseRepository(DbC db) : base(db)
        {
        }
    }
}
