using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISIS_2022_WebServices.Infrastructure
{
    public class RepositoryBase
    {
        private readonly IConfiguration _configuration;

        public RepositoryBase(IConfiguration configuration)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }
        protected string GetConnectionString() => _configuration.GetConnectionString("Main");

        public T[] GetData<T, TMappingService>(string sql)
            where T : class, new()
            where TMappingService : IMappingService<T>, new()
        {
            List<T> result = new List<T>();
            var mappingService = new TMappingService();

            using (var connection = new SqlConnection(this.GetConnectionString()))
            {
                connection.Open();
                using (var command = new SqlCommand(sql, connection))
                {
                    var reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        result.Add(mappingService.Map(reader));
                    }
                }
            }

            return result.ToArray();
        }

        protected void ExecSql(string sql)
        {
            if (string.IsNullOrWhiteSpace(sql))
                throw new ArgumentNullException(nameof(sql));

            using (var connection = new SqlConnection(this.GetConnectionString()))
            {
                connection.Open();
                using (var command = new SqlCommand(sql, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
