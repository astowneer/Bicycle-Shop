using System;

using Service.Contracts;
using Contracts;
using Entities.Models;

namespace Services
{
	public class ServiceManager<T> : IServiceManager<T>
		where T : AbstractBicycle, new()
	{
		private readonly Lazy<IBicycleService<T>> _bicycleService;
        private readonly Lazy<IFilterService<T>> _filterService;

		public ServiceManager(IRepositoryManager<T> repositoryManager)
		{
			_bicycleService = new Lazy<IBicycleService<T>>(() => new BicycleService<T>(repositoryManager));
            _filterService = new Lazy<IFilterService<T>>(() => new FilterService<T>(repositoryManager));
		}

		public IBicycleService<T> BicycleService => _bicycleService.Value;
		public IFilterService<T> FiltersService => _filterService.Value;
	}
}

