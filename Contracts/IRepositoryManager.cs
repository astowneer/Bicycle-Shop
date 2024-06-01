using System;
using BicycleApplication.Entities.Models;
using Entities.Models;

namespace Contracts
{
	public interface IRepositoryManager<T>
	{
		IBicycleRepository<T> Bicycle { get; }
        IFilterRepository<T> Filters { get; }
	}
}

