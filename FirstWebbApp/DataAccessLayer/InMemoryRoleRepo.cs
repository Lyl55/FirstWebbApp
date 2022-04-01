using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirstWebbApp.DataAccessLayer.Abstraction;
using FirstWebbApp.DataAccessLayer.Domain.Entities;

namespace FirstWebbApp.DataAccessLayer
{
    public class InMemoryRoleRepo:IRoleRepo
    {
        private readonly List<Role> _roles;

        public InMemoryRoleRepo()
        {
            _roles = new List<Role>()
            {
                new Role
                {
                    Id = 1,
                    Name = "Admin"
                },
                new Role
                {
                    Id = 2,
                    Name = "Customer"
                }
            };
        }
        public void Add(Role role)
        {
            _roles.Add(role);
        }

        public void Update(Role role)
        {
            var fromDb = _roles.FirstOrDefault(x => x.Id == role.Id);
            fromDb.Name = role.Name;
        }

        public Role GetByRolename(string rolename)
        {
            return _roles.FirstOrDefault(x =>
                x.Name.ToLowerInvariant() == rolename.ToLowerInvariant());
        }

        public Role GetById(int id)
        {
            return _roles.FirstOrDefault(x => x.Id == id);
        }
    }
}
