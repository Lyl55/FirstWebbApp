using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirstWebbApp.DataAccessLayer.Abstraction;
using FirstWebbApp.DataAccessLayer.Domain.Entities;
using FirstWebbApp.Models.Customers;
using FirstWebbApp.Models.Derivers;
using Microsoft.AspNetCore.Mvc;

namespace FirstWebbApp.Controllers
{
    public class DriversController:BaseControl
    {
        public DriversController(IDataBS dataBase) : base(dataBase)
        {

        }

        [HttpGet]
        public IActionResult Index()
        {
            var drv = DBs.Get();
            var m = new List<DriversModel>();
            foreach (var c in drv)
            {
                var model = new DriversModel
                {
                    ID = c.ID,
                    Name = c.Name,
                    LastName = c.LastName,
                    Email = c.Email,
                    Number = c.Number
                };
                m.Add(model);
            }
            return View(m);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(DriversModel model)
        {
            if (ModelState.IsValid==false)
            {
                return View(model);
            }

            var x = new Driver
            {
                Name = model.Name,
                LastName = model.LastName,
                Email = model.Email,
                Number = model.Number
            };
            DBs.Add(x);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            var x = DBs.Get(id);
            var model = new DriversModel
            {
                ID = x.ID,
                Name = x.Name,
                LastName = x.LastName,
                Email = x.Email,
                Number = x.Number
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Update(DriversModel model)
        {
            if (ModelState.IsValid==false)
            {
                return View(model);
            }

            var y = DBs.Get(model.ID);
            y.Name = model.Name;
            y.LastName = model.LastName;
            y.Email = model.Email;
            y.Number = model.Number;
            DBs.Update(y);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            DBs.Delete(id);
            return RedirectToAction("Index");
        }


    }


}
