using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISIS_2022_WebServices.Domain
{
    public class Order
    {
        public Guid BookId { get; set; }
        public string Reader { get; set; }
        public DateTime Date { get; set; }
        public Guid Id { get; set; }
    }
}
