using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using FirstWebbApp.DataAccessLayer.Abstraction;
using FirstWebbApp.DataAccessLayer.Domain.Entities;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using JsonConverter = System.Text.Json.Serialization.JsonConverter;

namespace FirstWebbApp.DataAccessLayer
{
    public class InmemoryDatabase:IDataBase
    {
        private const string filepath = "_customers.json";
        private readonly List<Customer> _customers = new List<Customer>();

        public InmemoryDatabase()
        {
            if (File.Exists(filepath))
            {
                string raw = File.ReadAllText(filepath);
                var cust = JsonConvert.DeserializeObject<Customer[]>(raw);
                _customers.AddRange(cust);
            }
            /*_customers.Add(new Customer
            {
                ID = 1,
                Name = "Leyla",
                LastName = "Aliyeva",
                Number = "756777777328",
                Email = "lyl@gmail.com"
            });*/
        }

        public void Add(Customer customer)
        {
            int id = 1;
            if (_customers.Count>0)
            {
                id = _customers[_customers.Count - 1].ID + 1;
            }
            //customer.ID = _customers[_customers.Count - 1].ID + 1;

            _customers.Add(customer);
            //this.Save();
        }

        public void Update(Customer customer)
        {
            var updt = _customers.FirstOrDefault(x => x.ID == customer.ID);

            if (updt != null)
            {
                updt.Name = customer.Name;
                updt.LastName = customer.LastName;
                updt.Number = customer.Number;
                updt.Email = customer.Email;
            }
            this.Save();
        }

        public void Delete(int id)
        {
            _customers.RemoveAll(x => x.ID == id); 
            this.Save();
        }

        


        public Customer Get(int id)
        { 
            return _customers.FirstOrDefault(x => x.ID == id);
        }

        public IList<Customer> Get()
        {
            return _customers;
        }


        private void Save()
        {
            string c = JsonConvert.SerializeObject(_customers);
            File.WriteAllText(filepath, c);
        }
    }
}
