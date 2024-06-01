using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace BicycleApplication.Controllers
{
    public class CharacteristicController : Controller
    {
        public IActionResult Mountain()
        {
            return View();
        }

        public IActionResult Gravel()
        {
            return View();
        }

        public IActionResult Electro()
        {
            return View();
        }

        public IActionResult Highway()
        {
            return View();
        }
    }
}

