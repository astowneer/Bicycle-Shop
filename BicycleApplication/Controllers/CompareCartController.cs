using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BicycleApplication.Extensions;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;

namespace BicycleApplication.Controllers
{
    public class CompareCartController : Controller
    {
        private readonly IBicycleService<Bicycle> _bicycleService;

        public CompareCartController(IBicycleService<Bicycle> bicycleService)
        {
            _bicycleService = bicycleService;
        }

        public IActionResult Index()
        {
            var compareCart = HttpContext.Session.Get<List<CompareItem>>("compare") ?? new List<CompareItem>();
            return View(compareCart);
        }

        public IActionResult Compare(int id)
        {
            var bicycle = _bicycleService.GetBicycle(id);
            var compareCart = HttpContext.Session.Get<List<CompareItem>>("compare") ?? new List<CompareItem>();

            if (!compareCart.Any(item => item.Bicycle.Id == id))
            {
                compareCart.Add(new CompareItem { Bicycle = bicycle });
            }

            HttpContext.Session.Set("compare", compareCart);
            return RedirectToAction("Index", "Bicycle");
        }
    }
}

