
using System.Threading;
using System.Threading.Tasks;
using FirstWebbApp.DataAccessLayer.Abstraction;
using FirstWebbApp.DataAccessLayer.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace FirstWebbApp.Identity
{
    public class RoleStore: IRoleStore<Role>
    {
        private readonly IUnitOfWork _unitOfWork;

        public RoleStore(IUnitOfWork unitofwork)
        {
            _unitOfWork = unitofwork;
        }
        public void Dispose()
        {

        }

        public Task<IdentityResult> CreateAsync(Role role, CancellationToken cancellationToken)
        {
            return Task.FromResult(IdentityResult.Success);
        }

        public Task<IdentityResult> UpdateAsync(Role role, CancellationToken cancellationToken)
        {
            _unitOfWork.RoleRepository.Update(role);
            return Task.FromResult(IdentityResult.Success);
        }

        public Task<IdentityResult> DeleteAsync(Role role, CancellationToken cancellationToken)
        {
            return Task.FromResult(IdentityResult.Success);
        }

        public Task<string> GetRoleIdAsync(Role role, CancellationToken cancellationToken)
        {
            return Task.FromResult(role.Id.ToString());
        }

        public Task<string> GetRoleNameAsync(Role role, CancellationToken cancellationToken)
        {
            return Task.FromResult(role.Name);
        }

        public Task SetRoleNameAsync(Role role, string roleName, CancellationToken cancellationToken)
        {
            role.Name = roleName;
            return Task.CompletedTask;
        }

        public Task<string> GetNormalizedRoleNameAsync(Role role, CancellationToken cancellationToken)
        {
            return Task.FromResult(role.Name.ToUpperInvariant());
        }

        public Task SetNormalizedRoleNameAsync(Role role, string normalizedName, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task<Role> FindByIdAsync(string roleId, CancellationToken cancellationToken)
        {
            var role = _unitOfWork.RoleRepository.GetById(int.Parse(roleId));
            return Task.FromResult(role);
        }

        public Task<Role> FindByNameAsync(string normalizedRoleName, CancellationToken cancellationToken)
        {
            var role = _unitOfWork.RoleRepository.GetByRolename(normalizedRoleName);
            return Task.FromResult(role);
        }
    }
}
