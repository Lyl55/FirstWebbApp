using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirstWebbApp.DataAccessLayer.Domain.Entities;

namespace FirstWebbApp.DataAccessLayer.Abstraction
{
    public interface IDataBase
    {
        void Add(Customer customer);
        void Update(Customer customer);
        void Delete(int id);
        Customer Get(int id);
        IList<Customer> Get();
    }
}
