using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using FirstWebbApp.DataAccessLayer.Abstraction;
using FirstWebbApp.DataAccessLayer.Domain.Entities;
using Newtonsoft.Json;

namespace FirstWebbApp.DataAccessLayer
{
    public class InMemoryDB:IDataBS
    {
        private const string filepath = "_drivers.json";
        private readonly List<Driver> _drivers = new List<Driver>();

        public InMemoryDB()
        {
            if (File.Exists(filepath))
            {
                string raw = File.ReadAllText(filepath);
                var cust = JsonConvert.DeserializeObject<Driver[]>(raw);
                _drivers.AddRange(cust);
            }
        }

        public void Add(Driver drv)
        {
            int id = 1;
            if (_drivers.Count > 0)
            {
                id = _drivers[_drivers.Count - 1].ID + 1;
            }

            _drivers.Add(drv);
            //this.Save();
        }

        public void Update(Driver driver)
        {
            var updt = _drivers.FirstOrDefault(x => x.ID == driver.ID);

            if (updt != null)
            {
                updt.Name = driver.Name;
                updt.LastName = driver.LastName;
                updt.Number = driver.Number;
                updt.Email = driver.Email;
            }
            this.Save();
        }

        public void Delete(int id)
        {
            _drivers.RemoveAll(x => x.ID == id);
            this.Save();
        }

        public Driver Get(int id)
        {
            return _drivers.FirstOrDefault(x => x.ID == id);
        }

        public IList<Driver> Get()
        {
            return _drivers;
        }

        private void Save()
        {
            string c = JsonConvert.SerializeObject(_drivers);
            File.WriteAllText(filepath, c);
        }

    }
}

