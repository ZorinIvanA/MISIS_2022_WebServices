using MISIS_2022_WebServices.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISIS_2022_WebServices.Model
{
    public class BookModel
    {
        public string Author { get; set; }
        public string Name { get; set; }
        public int PublishYear { get; set; }
        public Guid Id { get; set; }

        public Book ToDomainObject()
        {
            return new Book
            {
                Id = this.Id,
                Author = this.Author,
                PublishYear = this.PublishYear,
                Name = this.Name
            };
        }
    }
}
