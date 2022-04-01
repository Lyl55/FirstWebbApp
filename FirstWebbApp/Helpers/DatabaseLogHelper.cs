using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirstWebbApp.DataAccessLayer.Abstraction;
using FirstWebbApp.Helpers.Abstraction;

namespace FirstWebbApp.Helpers
{
    public class DatabaseLogHelper:IDataBaseLogHelper
    {
        private readonly IDataBase _dataBase;

        public DatabaseLogHelper(IDataBase dataBase)
        {
            _dataBase = dataBase;
        }
        public void AddOpertionLog(string operation)
        {
            operation = operation.Trim();
            _dataBase.AddOperation(operation);
        }
    }
}
