using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AngularWebApplication.Controllers
{
    public class BookController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Message"] = "Book Example";
            return View();
        }
    }
}