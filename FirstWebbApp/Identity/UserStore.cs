using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FirstWebbApp.DataAccessLayer.Abstraction;
using FirstWebbApp.DataAccessLayer.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace FirstWebbApp.Identity
{
    public class UserStore:IUserStore<Account>, IUserPasswordStore<Account>,IUserRoleStore<Account>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserStore(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Dispose()
        {
        }

        public Task<string> GetUserIdAsync(Account user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.Id.ToString());
        }

        public Task<string> GetUserNameAsync(Account user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.UserName);
        }

        public Task SetUserNameAsync(Account user, string userName, CancellationToken cancellationToken)
        {
            user.UserName = userName;
            return Task.CompletedTask;
        }

        public Task<string> GetNormalizedUserNameAsync(Account user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.UserName.ToUpperInvariant());
        }

        public Task SetNormalizedUserNameAsync(Account user, string normalizedName, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task<IdentityResult> CreateAsync(Account user, CancellationToken cancellationToken)
        {
            _unitOfWork.AccountRepository.Add(user);
            return Task.FromResult(IdentityResult.Success);
        }

        public Task<IdentityResult> UpdateAsync(Account user, CancellationToken cancellationToken)
        {
            _unitOfWork.AccountRepository.Update(user);
            return Task.FromResult(IdentityResult.Success);
        }

        public Task<IdentityResult> DeleteAsync(Account user, CancellationToken cancellationToken)
        {
            _unitOfWork.AccountRepository.Delete(user.Id);
            return Task.FromResult(IdentityResult.Success);
        }

        public Task<Account> FindByIdAsync(string userId, CancellationToken cancellationToken)
        {
            var account = _unitOfWork.AccountRepository.Get(int.Parse(userId));
            return Task.FromResult(account);
        }

        public Task<Account> FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken)
        {
            var account = _unitOfWork.AccountRepository.GetUserName(normalizedUserName);
            return Task.FromResult(account);
        }

        public Task SetPasswordHashAsync(Account user, string passwordHash, CancellationToken cancellationToken)
        {
            user.PasswordHash = passwordHash;
            return Task.CompletedTask;
        }

        public Task<string> GetPasswordHashAsync(Account user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.PasswordHash);
        }

        public Task<bool> HasPasswordAsync(Account user, CancellationToken cancellationToken)
        {
            return Task.FromResult(string.IsNullOrEmpty(user.PasswordHash) == false);

        }

        public Task AddToRoleAsync(Account user, string roleName, CancellationToken cancellationToken)
        {
            var role = _unitOfWork.RoleRepository.GetByRolename(roleName);
            var accRole = new AccountRole
            {
                Account = user,
                AccountId = user.Id,
                Role = role,
                RoleId = role.Id
            };
            _unitOfWork.AccountRoleRepository.Add(accRole);
            return Task.CompletedTask;
        }

        public Task RemoveFromRoleAsync(Account user, string roleName, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task<IList<string>> GetRolesAsync(Account user, CancellationToken cancellationToken)
        {
            var rls = _unitOfWork.AccountRoleRepository.GetByUser(user.Id);
            var rolesList = rls.Select(x => x.Role.Name).ToList();
            return Task.FromResult(rolesList as IList<string>);
        }

        public Task<bool> IsInRoleAsync(Account user, string roleName, CancellationToken cancellationToken)
        {
            var users = _unitOfWork.AccountRoleRepository.GetByRole(roleName);
            bool isInrole = users.Any(x => x.Id == user.Id);

            return Task.FromResult(isInrole);
        }

        public Task<IList<Account>> GetUsersInRoleAsync(string roleName, CancellationToken cancellationToken)
        {
            var users = _unitOfWork.AccountRoleRepository.GetByRole(roleName);

            return Task.FromResult(users);
        }
    }
}
