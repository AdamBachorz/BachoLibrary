using System;
using System.Collections.Generic;
using System.Text;

namespace BachoLibrary.DAL
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
