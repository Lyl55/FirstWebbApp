using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirstWebbApp.DataAccessLayer.Abstraction;
using FirstWebbApp.DataAccessLayer.Domain.Entities;

namespace FirstWebbApp.DataAccessLayer
{
    public class InMemoryAccountRepo:IAccountRepo
    {
        private readonly List<Account> _accounts;

        public InMemoryAccountRepo()
        {
            _accounts = new List<Account>();
        }
        public void Add(Account account)
        {
            int id = _accounts.LastOrDefault()?.Id ?? 1;

            account.Id = id;
            _accounts.Add(account);
        }

        public void Update(Account account)
        {
            var db = _accounts.FirstOrDefault(x => x.Id == account.Id);
            if (db!=account)
            {
                db.UserName = account.UserName;
                db.Email = account.Email;
                db.Number = account.Number;
                db.Password = account.Password;
                db.EmailConfirmed = account.EmailConfirmed;
                db.NumberConfirmed = account.NumberConfirmed;

            }

        }

        public Account Get(int id)
        {
            return _accounts.FirstOrDefault(x => x.Id == id);
        }

        public Account GetUserName(string name)
        {
            return _accounts.FirstOrDefault(x => x.UserName.ToLowerInvariant() == name.ToLowerInvariant());
        }

        public void Delete(int id)
        {
            _accounts.RemoveAll(x => x.Id == id);
        }
    }
}
