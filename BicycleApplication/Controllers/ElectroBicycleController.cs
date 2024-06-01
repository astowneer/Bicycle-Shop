using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BicycleApplication.Entities.Models;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects;
using Shared.Filters;
using Shared.ViewModels;

namespace BicycleApplication.Controllers
{
    public class ElectroBicycleController : Controller
    {
        private readonly IServiceManager<Bicycle> _mainService;
        private readonly IServiceManager<Electro> _service;

        public ElectroBicycleController(IServiceManager<Bicycle> mainService,
            IServiceManager<Electro> service)
        {
            _mainService = mainService;
            _service = service;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            var bicycles = _service.BicycleService.GetAllBicycles().ToList();
            var imagesPath = GetImagePath(bicycles.Count());

            // Max price value for ranger
            ViewBag.MaxPriceValue = bicycles.Any() ? Convert.ToInt32(bicycles.Max(m => m.Price)) : 0;

            var mainBicycles = bicycles.Select(m => new Bicycle(m));
            var electroBicycles = mainBicycles.Select(m => new ElectroDto(m)).ToList();
            var electroViewModel = CreateElectroViewModel(electroBicycles, imagesPath);

            return View(electroViewModel);
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
            ViewBag.MaxPriceValue = bicycles.Any() ? bicycles.Max(m => m.Price) : 0;

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

            List<string> imagesPath = GetImagePath(bicycles.Count);

            var mainBicycles = bicycles.Select(m => new Bicycle(m));
            var electroBicycle = mainBicycles.Select(m => new ElectroDto(m)).ToList();
            var electroViewModel = CreateElectroViewModel(electroBicycle, imagesPath);

            return View(electroViewModel);
        }

        private ElectroViewModel CreateElectroViewModel(List<ElectroDto> bicycles, List<string> imagePath)
        {
            return new ElectroViewModel()
            {
                Bicycles = bicycles,
                ImagesPath = imagePath,
                ColorFilter = _service.FiltersService.GetColors().ToList(),
                WheelFilter = _service.FiltersService.GetWheels().ToList(),
                YearFilter = _service.FiltersService.GetYears().ToList(),
            };
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Electro bicycle)
        {
            // Define unique Id
            if (bicycle is null)
                throw new Exception();

            bicycle.Id = _mainService.BicycleService.GetAllBicycles().Any() ?
                                        _mainService.BicycleService.GetAllBicycles().Max(m => m.Id) + 1 : 1;

            if (ModelState.IsValid)
            {
                Bicycle mainBicycle = new Bicycle(bicycle, battery: bicycle.Battery, power: bicycle.Power);

                _mainService.BicycleService.CreateBicycle(mainBicycle);
                _service.BicycleService.CreateBicycle(bicycle);

                return RedirectToAction(nameof(Index));
            }

            return View(bicycle);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || _service.BicycleService.GetAllBicycles() == null)
            {
                return NotFound();
            }

            var bicycle = _service.BicycleService.GetAllBicycles().FirstOrDefault(m => m.Id == id);

            if (bicycle == null)
            {
                return NotFound();
            }

            return View(bicycle);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int? id, Electro bicycle)
        {
            if (ModelState.IsValid)
            {
                Bicycle mainBicycle = new Bicycle(bicycle, battery: bicycle.Battery, power: bicycle.Power);
                _mainService.BicycleService.UpdateBicycle(mainBicycle, compTrackChanges: false);
                _service.BicycleService.UpdateBicycle(bicycle, compTrackChanges: false);

                return RedirectToAction(nameof(Index));
            }

            return View(bicycle);
        }

        public IActionResult Details(int? id)
        {
            if (id == null || _service.BicycleService.GetAllBicycles() == null)
            {
                return NotFound();
            }

            var bicycle = _service.BicycleService.GetAllBicycles().FirstOrDefault(m => m.Id == id);

            if (bicycle == null)
            {
                return NotFound();
            }

            return View(bicycle);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || _service.BicycleService.GetAllBicycles() == null)
            {
                return NotFound();
            }

            var bicycle = _service.BicycleService.GetAllBicycles().FirstOrDefault(m => m.Id == id);

            if (bicycle == null)
            {
                return NotFound();
            }

            return View(bicycle);
        }

        [HttpPost, ActionName("Delete")]
        [IgnoreAntiforgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            if (_service.BicycleService.GetAllBicycles() == null)
            {
                return Problem("Entity set 'BicycleContext.Bicycle' is null");
            }

            _service.BicycleService.DeleteBicycle(id);
            _mainService.BicycleService.DeleteBicycle(id);

            return RedirectToAction(nameof(Index));
        }

        private static List<string> GetImagePath(int amount)
        {
            List<string> imagesPath = new List<string>();

            for (int i = 0; i < amount; i++)
            {
                int index = (i + 1) % 7;
                imagesPath.Add($"~/Images/electro{index}.png");
            }

            return imagesPath;
        }
    }
}

