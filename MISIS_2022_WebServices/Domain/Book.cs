using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISIS_2022_WebServices.Domain
{
    public class Book
    {
        public string Author { get; set; }
        public string Name { get; set; }
        public int PublishYear { get; set; }
        public Guid Id { get; set; }
    }
}
