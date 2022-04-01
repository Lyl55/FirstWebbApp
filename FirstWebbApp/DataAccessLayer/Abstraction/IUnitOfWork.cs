using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstWebbApp.DataAccessLayer.Abstraction
{
    public interface IUnitOfWork
    {
        IAccountRepo AccountRepository { get; }
        IRoleRepo RoleRepository { get; }
        IAccountRoleRepo AccountRoleRepository { get; }
    }
}
