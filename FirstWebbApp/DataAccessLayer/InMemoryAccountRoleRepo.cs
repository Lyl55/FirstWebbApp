using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirstWebbApp.DataAccessLayer.Abstraction;
using FirstWebbApp.DataAccessLayer.Domain.Entities;

namespace FirstWebbApp.DataAccessLayer
{
    public class InMemoryAccountRoleRepo:IAccountRoleRepo
    {
        private readonly List<AccountRole> _accountRoles = new List<AccountRole>();
        public void Add(AccountRole accountRole)
        {
            accountRole.Id = _accountRoles.LastOrDefault()?.Id ?? 1;

            _accountRoles.Add(accountRole);
        }

        public IList<AccountRole> GetByUser(int userId)
        {
            return _accountRoles.Where(x => x.AccountId == userId).ToList();
        }

        public IList<Account> GetByRole(string roleName)
        {
            return _accountRoles.Where(x => x.Role.Name.ToLowerInvariant() == roleName.ToLowerInvariant())
                .Select(x => x.Account).ToList();
        }
    }
}
