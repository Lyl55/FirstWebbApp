using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace FirstWebbApp.Controllers
{
    public class ColorController:Controller
    {
        public IActionResult Index1()
        {
            return View();
        }
    }
}
