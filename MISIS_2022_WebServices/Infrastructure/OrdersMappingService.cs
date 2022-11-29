using Microsoft.Data.SqlClient;
using MISIS_2022_WebServices.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISIS_2022_WebServices.Infrastructure
{
    public class OrdersMappingService : IMappingService<Order>
    {
        public Order Map(SqlDataReader reader)
        {
            return new Order
            {
                Id = Guid.Parse(reader["id"].ToString()),
                BookId = Guid.Parse(reader["book_id"].ToString()),
                Reader = reader["reader"].ToString()
            };
        }
    }
}
