using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirstWebbApp.DataAccessLayer.Domain.Entities;

namespace FirstWebbApp.DataAccessLayer.Abstraction
{
    public interface IDataBS
    {
        void Add(Driver driver);
        void Update(Driver driver);
        void Delete(int id);
        Driver Get(int id);
        IList<Driver> Get();
    }
}
