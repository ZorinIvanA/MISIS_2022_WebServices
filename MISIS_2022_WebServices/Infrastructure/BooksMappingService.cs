using Microsoft.Data.SqlClient;
using MISIS_2022_WebServices.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISIS_2022_WebServices.Infrastructure
{
    public class BooksMappingService : IMappingService<Book>
    {
        public Book Map(SqlDataReader reader)
        {
            return new Book
            {
                Id = Guid.Parse(reader["id"].ToString()),
                Name = reader["name"].ToString(),
                Author = reader["author"].ToString()
            };
        }
    }
}
