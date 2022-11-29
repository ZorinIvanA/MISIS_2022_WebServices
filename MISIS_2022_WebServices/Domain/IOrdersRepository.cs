using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISIS_2022_WebServices.Domain
{
    public interface IOrdersRepository
    {
        Guid Insert(Order order);
    }
}
