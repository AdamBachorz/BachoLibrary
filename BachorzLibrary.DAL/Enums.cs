using System;
using System.Collections.Generic;
using System.Text;

namespace BachorzLibrary.DAL
{
    public enum DataBase
    {
        MSSQL,
        PostgreSQL,
        MySQL
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
