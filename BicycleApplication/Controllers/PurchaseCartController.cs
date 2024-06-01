using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BicycleApplication.Extensions;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;

using Entities.Models;
using Services;

namespace BicycleApplication.Controllers
{
    public class PurchaseCartController : Controller
    {
        private readonly IBicycleService<Bicycle> _service;

        public PurchaseCartController(IBicycleService<Bicycle> service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            var cart = HttpContext.Session.Get<List<BicycleItem>>("cart") ?? new List<BicycleItem>();
            ViewBag.Total = cart.Sum(s => s.Quantity * s.Bicycle.Price);
            return View(cart);
        }

        public IActionResult Add(int id)
        {
            var cart = HttpContext.Session.Get<List<BicycleItem>>("cart") ?? new List<BicycleItem>();
            var index = cart.FindIndex(m => m.Bicycle.Id == id);
            if (index != -1)
            {
                cart[index].Quantity++;
            }
            else
            {
                cart.Add(new BicycleItem { Bicycle = _service.GetBicycle(id), Quantity = 1 });
            }
            HttpContext.Session.Set("cart", cart);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Minus(int id)
        {
            var cart = HttpContext.Session.Get<List<BicycleItem>>("cart") ?? new List<BicycleItem>();
            var index = cart.FindIndex(m => m.Bicycle.Id == id);
            if (index != -1)
            {
                if (cart[index].Quantity > 0)
                {
                    cart[index].Quantity--;
                    if (cart[index].Quantity == 0)
                    {
                        cart.RemoveAt(index);
                    }
                }
            }
            HttpContext.Session.Set("cart", cart);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Buy(int id)
        {
            var bicycle = _service.GetBicycle(id);
            var cart = HttpContext.Session.Get<List<BicycleItem>>("cart");

            if (cart != null)
            {
                var index = cart.FindIndex(m => m.Bicycle.Id == id);
                if (index != -1)
                {
                    cart[index].Quantity++;
                }
                else
                {
                    cart.Add(new BicycleItem() { Bicycle = bicycle, Quantity = 1 });
                }
            }
            else
            {
                cart = new List<BicycleItem>();
                cart.Add(new BicycleItem() { Bicycle = bicycle, Quantity = 1 });
            }

            HttpContext.Session.Set<List<BicycleItem>>("cart", cart);
            return RedirectToAction("Index", "MountainBicycle");
        }

        public IActionResult Remove(int id)
        {
            var cart = HttpContext.Session.Get<List<BicycleItem>>("cart") ?? new List<BicycleItem>();
            var index = cart.FindIndex(m => m.Bicycle.Id == id);

            if (index != -1)
            {
                cart.RemoveAt(index);
            }

            HttpContext.Session.Set("cart", cart);
            return RedirectToAction(nameof(Index));
        }
    }
}

