using System;
using Contracts;
using Entities.Models;
using Service.Contracts;
using Shared.DataTransferObjects;
using Shared.Filters;

namespace Services
{
	public class FilterService<T> : IFilterService<T>
	{
		private readonly IRepositoryManager<T> _repositoryManager;

		public FilterService(IRepositoryManager<T> repositoryManager) =>
			_repositoryManager = repositoryManager;

		public IReadOnlyList<ColorFilter> GetColors()
			=> _repositoryManager.Filters.GetColors();

		public IReadOnlyList<WheelFilter> GetWheels()
			=> _repositoryManager.Filters.GetWheels();

		public IReadOnlyList<YearFilter> GetYears()
			=> _repositoryManager.Filters.GetYears();

		public List<T> Filter(List<T> bicycles, List<ColorFilter> color, List<YearFilter> year, List<WheelFilter> wheels)
			=> _repositoryManager.Filters.Filter(bicycles, color, year, wheels);
	}
}

