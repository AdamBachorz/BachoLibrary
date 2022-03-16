using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BachoLibrary.DAL
{
    public interface ICustomConfig
    {
        DataBase DataBase { get; set }
        bool IsProduction { get; set; }
        string ConnectionString { get; set; }
    }
}
