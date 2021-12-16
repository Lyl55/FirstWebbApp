using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirstWebbApp.DataAccessLayer.Abstraction;
using Microsoft.AspNetCore.Mvc;

namespace FirstWebbApp.Controllers
{
    public class BaseControl : Controller
    {
        protected readonly IDataBS DBs;

        public BaseControl(IDataBS dataBase)
        {
            DBs = dataBase;
        }
    }
}
