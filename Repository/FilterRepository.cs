using System;
using Contracts;
using Entities.Models;
using Shared.DataTransferObjects;
using Shared.Filters;

namespace Repository
{
	public class FilterRepository<T> : RepositoryBase<T>, IFilterRepository<T>
        where T : AbstractBicycle, new()
	{
        public FilterRepository(RepositoryContext<T> repositoryContext) : base(repositoryContext) { }

        public IReadOnlyList<ColorFilter> GetColors()
        {
            return _repositoryContext.Entities
                       .Select(m => m.Color)
                       .Distinct()
                       .Select((color, index) => new ColorFilter { Id = index, Color = color, IsChecked = false })
                       .ToList();
        }

        public IReadOnlyList<WheelFilter> GetWheels()
        {
            return _repositoryContext.Entities
                       .Select(m => m.DiameterOfWheel)
                       .Distinct()
                       .Select((wheel, index) => new WheelFilter { Id = index, Diameter = wheel, IsChecked = false })
                       .ToList();
        }

        public IReadOnlyList<YearFilter> GetYears()
        {
            return _repositoryContext.Entities
                       .Select(m => m.Year)
                       .Distinct()
                       .Select((year, index) => new YearFilter { Id = index, Year = year, IsChecked = false })
                       .ToList();
        }

        public List<T> Filter(List<T> bicycles, List<ColorFilter> color, List<YearFilter> year, List<WheelFilter> wheels)
        {
            //bicycles = _repositoryContext.Entities.ToList();
            //var bicyclesDto = bicycles.Select(m => new BicycleDto(m)).ToList();

            bicycles = ApplyFilter<ColorFilter>(color, bicycles);
            bicycles = ApplyFilter<YearFilter>(year, bicycles);
            bicycles = ApplyFilter<WheelFilter>(wheels, bicycles);

            return bicycles;
        }

        private List<T> ApplyFilter<F>(List<F> filters, List<T> bicycles) where F : AbstractFilter
        {
            var checkedFilters = filters.Where(x => x.IsChecked).ToList();
            if (!checkedFilters.Any()) return bicycles;

            var filteredBicycles = new List<T>();
            foreach(var item in checkedFilters)
            {
                filteredBicycles.AddRange(FilterBicyclesByType(item, bicycles).ToList());
            }

            bicycles = filteredBicycles;

            return bicycles.Distinct().ToList();
        }

        private static IEnumerable<T> FilterBicyclesByType<F>(F filter, List<T> bicycles) where F : AbstractFilter
        {
            return filter switch
            {
                ColorFilter colorFilter => bicycles.Where(m => m.Color == colorFilter.Color),
                WheelFilter wheelsFilter => bicycles.Where(m => m.DiameterOfWheel == wheelsFilter.Diameter),
                YearFilter yearFilter => bicycles.Where(m => m.Year == yearFilter.Year),
                _ => bicycles
            };
        }
    }
}

