using System;
using BicycleApplication.Entities.Models;
using Contracts;
using Entities.Models;
using Shared.Filters;

namespace Repository
{
	public class RepositoryManager<T> : IRepositoryManager<T>
		where T : AbstractBicycle, new()
	{
		private readonly RepositoryContext<T> _repositoryContext;
        private readonly Lazy<IBicycleRepository<T>> _bicycleRepository;
        private readonly Lazy<IFilterRepository<T>> _filterRepository;

		public RepositoryManager(RepositoryContext<T> repositoryContext)
		{
			_repositoryContext = repositoryContext;
			_bicycleRepository = new Lazy<IBicycleRepository<T>>(() => new BicycleRepository<T>(repositoryContext));
			_filterRepository = new Lazy<IFilterRepository<T>>(() => new FilterRepository<T>(repositoryContext));
        }

		public IBicycleRepository<T> Bicycle => _bicycleRepository.Value;
        public IFilterRepository<T> Filters => _filterRepository.Value;
	}
}

