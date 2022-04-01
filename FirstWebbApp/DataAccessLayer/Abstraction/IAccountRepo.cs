using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirstWebbApp.DataAccessLayer.Domain.Entities;

namespace FirstWebbApp.DataAccessLayer.Abstraction
{
    public interface IAccountRepo
    {
        void Add(Account account);
        void Update(Account account);
        Account Get(int id);
        Account GetUserName(string username);
        void Delete(int id);
    }
}
