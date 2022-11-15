using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISIS_2022_WebServices.Domain
{
    public interface IBooksRepository
    {
        Book[] GetAll();
        Book GetById(Guid id);
        void Delete(Guid id);
        void Update(Book book);
        Guid Insert(Book book);
    }
}
