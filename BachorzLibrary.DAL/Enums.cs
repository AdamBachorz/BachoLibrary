using System;
using System.Collections.Generic;
using System.Text;

namespace BachorzLibrary.DAL
{
    public enum DataBase
    {
        MSSQL = 0,
        PostgreSQL = 1,
        Sqlite = 2,
        MySQL = 3,
    }
    public enum IdentityStrategy
    {
        Sequance,
        Guid
    }
    public enum UserRole
    {
        Administrator = 1,
        User = 2,
    }
}
