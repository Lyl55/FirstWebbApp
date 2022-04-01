using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirstWebbApp.DataAccessLayer.Abstraction;
using FirstWebbApp.DataAccessLayer.Domain.Entities;
using FirstWebbApp.Helpers.Abstraction;
using FirstWebbApp.Models.Customers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.AspNetCore.Razor.Language.Extensions;

namespace FirstWebbApp.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CustomersController:BaseController
    {
        private readonly IDataBaseLogHelper _dataBaseLogHelper;
        
        public CustomersController(IDataBase db,IDataBaseLogHelper dataBaseLogHelper) : base(db)
        {
            _dataBaseLogHelper = dataBaseLogHelper;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var mes = TempData["Message"];
            ViewBag.Message = mes;
            /*ViewBag.Text = "Customers lists";
            ViewData["Text2"] = "Customers";*/
            var cust = DB.Get();
            var models = new List<CustomerModel>();
            foreach (var c in cust)
            {
                var model = new CustomerModel
                {
                    ID = c.ID,
                    Name = c.Name,
                    LastName = c.LastName,
                    Email = c.Email,
                    Number = c.Number
                };
                models.Add(model);
            }
            return View(models);
            
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(CustomerModel model)
        {
            if (ModelState.IsValid == false)
            {
                return View(model);
            }
            var ent = new Customer
            {
                Name = model.LastName,
                LastName = model.LastName,
                Email = model.Email,
                Number = model.Number
            };
            DB.Add(ent);
            TempData["Message"] = "Successfully";
            return RedirectToAction("Index");
        }

        [HttpGet]
       public IActionResult Update(int id)
        {
            var ent = DB.Get(id);
            var model = new CustomerModel
                {
                    ID = ent.ID,
                    Name = ent.Name,
                    LastName = ent.LastName,
                    Email = ent.Email,
                    Number = ent.Number
                };
                return View(model);
        }

        [HttpPost]
        public IActionResult Update(CustomerModel model)
        {
            if (ModelState.IsValid == false)
            {
                return View(model);
            }

            var entity = DB.Get(model.ID);
            entity.Name = model.Name;
            entity.LastName = model.LastName;
            entity.Email = model.Email;
            entity.Number = model.Number;
            DB.Update(entity);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            
            DB.Delete(id);
            return RedirectToAction("Index");
        }
    }
    }

