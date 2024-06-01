using System;
namespace Service.Contracts
{
	public interface IServiceManager<T>
	{
		IBicycleService<T> BicycleService { get; }
        IFilterService<T> FiltersService { get; }
	}
}

