using MISIS_2022_WebServices.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISIS_2022_WebServices.Infrastructure
{
    public class BooksRepository : IBooksRepository
    {
        public void Delete(Guid id)
        {
            
        }

        public Book[] GetAll()
        {
            return new Book[]
            {
                new Book
                {
                    Id = Guid.NewGuid(),
                    Author = "Lev Tolstoy",
                    Name = "War and Peace",
                    PublishYear = 1840
                },
                new Book
                {
                    Id = Guid.NewGuid(),
                    Author= "Alexander Pushkin",
                    Name = "The tale about Tsar Saltan",
                    PublishYear = 1750
                }
            };
        }

        public Book GetById(Guid id)
        {
            return new Book
            {
                Id = Guid.NewGuid(),
                Author = "Lev Tolstoy",
                Name = "War and Peace",
                PublishYear = 1840
            };
        }

        public Guid Insert(Book book)
        {
            return Guid.NewGuid();
        }

        public void Update(Book book)
        {
            
        }
    }
}
