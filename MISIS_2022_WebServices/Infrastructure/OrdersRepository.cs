using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using MISIS_2022_WebServices.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISIS_2022_WebServices.Infrastructure
{
    public class OrdersRepository : RepositoryBase, IOrdersRepository
    {
        public OrdersRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public Guid Insert(Order order)
        {
            if (order == null)
                throw new ArgumentNullException(nameof(order));

            var id = Guid.NewGuid();

            this.ExecSql($"INSERT INTO Order (id, book_id, reader, date) VALUES ('{id}',{order.BookId},'{order.Reader}','{order.Date}')");

            return id;
        }

        public Order[] GetAll() => this.GetData<Order, OrdersMappingService>("SELECT * FROM Orders");

        public Order[] GetAllWithFilter(Guid bookId) => this.GetData<Order, OrdersMappingService>($"SELECT * FROM Orders WHERE bookId={bookId}");
    }
}
