using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirstWebbApp.DataAccessLayer.Domain.Entities;

namespace FirstWebbApp.DataAccessLayer.Abstraction
{
    public interface IRoleRepo
    {
        void Add(Role role);
        void Update(Role role);
        Role GetByRolename(string rolename);
        Role GetById(int id);
    }
}
