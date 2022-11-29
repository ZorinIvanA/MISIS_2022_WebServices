using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISIS_2022_WebServices.Infrastructure
{
    public interface IMappingService<T>
        where T : class, new()
    {
        T Map(SqlDataReader reader);
    }
}
