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
            ViewData["Message"] = "Show All Books";
            return View();
        }
    }
}