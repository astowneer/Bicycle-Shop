using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using Repository;
using Contracts;
using Entities.Models;
using Service.Contracts;
using Shared.DataTransferObjects;
using Shared.Filters;
using Shared.ViewModels;

namespace BicycleApplication.Controllers
{
    public class BicycleController : Controller
    {
        private readonly IServiceManager<Bicycle> _service;

        public BicycleController(IServiceManager<Bicycle> service)
        {
            _service = service;
        }

        public IActionResult Index(string sortOrder)
        {
            var bicycles = _service.BicycleService.GetAllBicycles();
            //Max price value for ranger
            ViewBag.MaxPriceValue = bicycles.Any() ? Convert.ToInt32(bicycles.Max(m => m.Price)) : 0;

            //Sort by parameter
            var bicyclesDto = bicycles.Select(m => new BicycleDto(m)).ToList();

            SetSortOrderViewBags(sortOrder);
            bicyclesDto = SortBicycles(bicyclesDto, sortOrder);

            var bicycleViewModel = CreateBicycleViewModel(bicyclesDto);

            return View(bicycleViewModel);
        }

        [HttpPost]
        [IgnoreAntiforgeryToken]
        public IActionResult Index(string searchString, int min, int max,
            List<ColorFilter> colorFilter,
            List<WheelFilter> wheelFilter,
            List<YearFilter> yearFilter,
            List<FrameFilter> frameFilter,
            List<PedantFilter> pedantFilter,
            List<BrakeFilter> brakeFilter)
        {
            var bicycles = _service.BicycleService.GetAllBicycles().ToList();

            // Max price value for ranger
            ViewBag.MaxPriceValue = bicycles.Any() ? Convert.ToInt32(bicycles.Max(m => m.Price)) : 0;

            // Search by price
            if (max > 0)
            {
                bicycles = bicycles.Where(m => m.Price >= min && m.Price <= max).ToList();
            }

            // Search by model name
            if (!string.IsNullOrEmpty(searchString))
            {
                searchString = searchString.ToLower();
                bicycles = bicycles.Where(m => m.Name.ToLower().Contains(searchString)).ToList();
            }

            // Search by filters
            bicycles = _service.FiltersService.Filter(bicycles, colorFilter, yearFilter, wheelFilter);

            var bicyclesDto = bicycles.Select(m => new BicycleDto(m)).ToList();
            var bicycleViewModel = CreateBicycleViewModel(bicyclesDto);

            return View(bicycleViewModel);
        }

        private void SetSortOrderViewBags(string sortOrder)
        {
            ViewBag.NameSortParm = string.IsNullOrEmpty(sortOrder) ? "Name" : "name_desc";
            ViewBag.ColorSortParm = string.IsNullOrEmpty(sortOrder) ? "Color" : "color_desc";
            ViewBag.YearSortParm = string.IsNullOrEmpty(sortOrder) ? "Year" : "year_desc";
            ViewBag.FrameSortParm = string.IsNullOrEmpty(sortOrder) ? "Frame" : "frame_desc";
            ViewBag.PedantSortParm = string.IsNullOrEmpty(sortOrder) ? "Pedant" : "pedant_desc";
            ViewBag.BrakeSortParm = string.IsNullOrEmpty(sortOrder) ? "Brake" : "brake_desc";
            ViewBag.PriceSortParm = string.IsNullOrEmpty(sortOrder) ? "Price" : "price_desc";
        }

        private List<BicycleDto> SortBicycles(List<BicycleDto> bicycles, string sortOrder)
        {
            return sortOrder switch
            {
                "name_desc" => bicycles.OrderBy(s => s.Name).ToList(),
                "color_desc" => bicycles.OrderBy(s => s.Color).ToList(),
                "year_desc" => bicycles.OrderBy(s => s.Year).ToList(),
                "frame_desc" => bicycles.OrderBy(s => s.FrameMaterial).ToList(),
                "pedant_desc" => bicycles.OrderBy(s => s.PedantType).ToList(),
                "brake_desc" => bicycles.OrderBy(s => s.BrakeType).ToList(),
                "price_desc" => bicycles.OrderBy(s => s.Price).ToList(),
                _ => bicycles
            };
        }

        private BicycleViewModel CreateBicycleViewModel(List<BicycleDto> bicycles)
        {
            return new BicycleViewModel()
            {
                Bicycles = bicycles,
                ColorFilter = _service.FiltersService.GetColors().ToList(),
                WheelFilter = _service.FiltersService.GetWheels().ToList(),
                YearFilter = _service.FiltersService.GetYears().ToList()
            };
        }
    }
}

