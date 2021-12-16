using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirstWebbApp.DataAccessLayer;
using FirstWebbApp.DataAccessLayer.Abstraction;
using Microsoft.AspNetCore.Mvc;

namespace FirstWebbApp.Controllers
{
    public class BaseController:Controller
    {
        protected readonly IDataBase DB;

        public BaseController(IDataBase dataBase)
        {
            DB = dataBase;
        }
    }
}
