using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirstWebbApp.DataAccessLayer.Domain.Entities;

namespace FirstWebbApp.DataAccessLayer.Abstraction
{
    public interface IAccountRoleRepo
    {
        void Add(AccountRole accountRole);
        IList<AccountRole> GetByUser(int userId);
        IList<Account> GetByRole(string roleName);
    }
}
