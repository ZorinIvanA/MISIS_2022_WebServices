using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using MISIS_2022_WebServices.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISIS_2022_WebServices.Infrastructure
{
    public class BooksRepository : IBooksRepository
    {
        private readonly IConfiguration _configuration;

        public BooksRepository(IConfiguration configuration)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        public void Delete(Guid id)
        {
            using (var connection = new SqlConnection(this.GetConnectionString()))
            {
                connection.Open();
                using (var command = new SqlCommand($"DELETE FROM Books WHERE id='{id}'", connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        public Book[] GetAll()
        {
            List<Book> books = new List<Book>();

            using (var connection = new SqlConnection(this.GetConnectionString()))
            {
                connection.Open();
                using (var command = new SqlCommand("SELECT id, name, author FROM Books", connection))
                {
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        books.Add(new Book
                        {
                            Id = Guid.Parse(reader["id"].ToString()),
                            Name = reader["name"].ToString(),
                            Author = reader["author"].ToString()
                        });
                    }
                }
            }

            return books.ToArray();
        }

        public Book GetById(Guid id)
        {
            using (var connection = new SqlConnection(this.GetConnectionString()))
            {
                connection.Open();
                using (var command = new SqlCommand($"SELECT id, name, author FROM Books WHERE id='{id}'", connection))
                {
                    var reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        return new Book
                        {
                            Id = Guid.Parse(reader["id"].ToString()),
                            Name = reader["name"].ToString(),
                            Author = reader["author"].ToString()
                        };
                    }
                    else
                        return null;
                }
            }
        }

        public Guid Insert(Book book)
        {
            if (book == null)
                throw new ArgumentNullException(nameof(book));

            var id = Guid.NewGuid();

            using (var connection = new SqlConnection(this.GetConnectionString()))
            {
                connection.Open();
                using (var command = new SqlCommand($"INSERT INTO Books (id, name, author) VALUES ('{id}','{book.Name}','{book.Author}')", connection))
                {
                    command.ExecuteNonQuery();
                }
            }

            return id;
        }

        private string GetConnectionString() => this._configuration.GetConnectionString("Main");

        public void Update(Book book)
        {
            if (book == null)
                throw new ArgumentNullException(nameof(book));

            var id = Guid.NewGuid();

            using (var connection = new SqlConnection(this.GetConnectionString()))
            {
                connection.Open();
                using (var command = new SqlCommand($"UPDATE Books SET name='{book.Name}', author='{book.Author}' WHERE id='{book.Id}'", connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
