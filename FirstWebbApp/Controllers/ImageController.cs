using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace FirstWebbApp.Controllers
{
    public class ImageController : Controller
    {
        public IActionResult Index1()
        {
            string[] arr = { "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcR2Svb9jW-UI_so8AD3VQObUrlTxi_kLjkz6Yl_KCYqnL_Qa2kEYQrHrM5vzCDeIllld4w&usqp=CAU", "https://i.stack.imgur.com/FQAqi.png", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTmvfdhPAU4gwu4oa1k8grGPa-0OOByD-FTbvE7oU3j-y-1HHuRqFcBoJoh-4ZTkuP8I1A&usqp=CAU" };
            Random r = new Random();
            int x = r.Next(arr.Length);
            return View("Index1", arr[x]);
        }
    }
}
