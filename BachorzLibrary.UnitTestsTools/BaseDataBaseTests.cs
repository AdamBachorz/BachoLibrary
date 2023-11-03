using BachorzLibrary.DAL.DotNetSix.EntityFrameworkCore;

namespace BachorzLibrary.UnitTestsTools
{
    public class BaseDataBaseTests<DbC> : BaseTests where DbC : BaseDbContext
    {
        protected DbC _db;

        public void Setup(string configFilePath)
        {
            base.Setup(configFilePath);
            _fixture.AddTestDatabaseContext<DbC>();
            _db = _fixture.GetTestContext<DbC>();
        }
    }
}
