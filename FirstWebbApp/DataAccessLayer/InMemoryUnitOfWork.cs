using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirstWebbApp.DataAccessLayer.Abstraction;

namespace FirstWebbApp.DataAccessLayer
{
    public class InMemoryUnitOfWork : IUnitOfWork   
    {
        private static IAccountRepo _accountRepository = new InMemoryAccountRepo();
        private static IRoleRepo _roleRepository = new InMemoryRoleRepo();
        private static IAccountRoleRepo _accountRoleRepository = new InMemoryAccountRoleRepo();


        public IAccountRepo AccountRepository => _accountRepository;
        public IRoleRepo RoleRepository => _roleRepository;
        public IAccountRoleRepo AccountRoleRepository => _accountRoleRepository;
    }
}
