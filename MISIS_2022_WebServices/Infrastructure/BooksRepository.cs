using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using MISIS_2022_WebServices.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISIS_2022_WebServices.Infrastructure
{
    public class BooksRepository : RepositoryBase, IBooksRepository
    {
        private readonly IConfiguration _configuration;

        public BooksRepository(IConfiguration configuration) :
            base(configuration)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        public void Delete(Guid id) => this.ExecSql($"DELETE FROM Books WHERE id='{id}'");

        public Book[] GetAll() => this.GetData<Book, BooksMappingService>("SELECT id, name, author FROM Books");

        public Book GetById(Guid id) => this.GetData<Book, BooksMappingService>($"SELECT id, name, author FROM Books WHERE id='{id}'").FirstOrDefault();

        public Guid Insert(Book book)
        {
            if (book == null)
                throw new ArgumentNullException(nameof(book));

            var id = Guid.NewGuid();

            this.ExecSql($"INSERT INTO Books (id, name, author) VALUES ('{id}','{book.Name}','{book.Author}')");

            return id;
        }

        public void Update(Book book)
        {
            if (book == null)
                throw new ArgumentNullException(nameof(book));

            this.ExecSql($"UPDATE Books SET name='{book.Name}', author='{book.Author}' WHERE id='{book.Id}'");
        }
    }
}