using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISIS_2022_WebServices.Infrastructure
{
    public class RepostiroyBase
    {
        private readonly IConfiguration _configuration;

        public RepostiroyBase(IConfiguration configuration)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }
        private string GetConnectionString() => _configuration.GetConnectionString("Main");

        //public T[] GetData<T>(string sql)
        //    where T: class, new()
        //{
        //    //using (var connection = new SqlConnection(this.GetConnectionString()))
        //    //{
        //    //    connection.Open();
        //    //    using (var command = new SqlCommand($"SELECT id, name, author FROM Books WHERE id='{id}'", connection))
        //    //    {
        //    //        var reader = command.ExecuteReader();

        //    //        if (reader.Read())
        //    //        {
        //    //            return new Book
        //    //            {
        //    //                Id = Guid.Parse(reader["id"].ToString()),
        //    //                Name = reader["name"].ToString(),
        //    //                Author = reader["author"].ToString()
        //    //            };
        //    //        }
        //    //        else
        //    //            return null;
        //    //    }
        //    //}
        //}
    }
}
