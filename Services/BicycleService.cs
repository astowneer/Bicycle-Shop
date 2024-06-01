using System;

using Shared.DataTransferObjects;
using Contracts;
using Service.Contracts;
using Entities.Models;

namespace Services
{
	public class BicycleService<T> : IBicycleService<T>
		where T : AbstractBicycle, new()
	{
		private readonly IRepositoryManager<T> _repositoryManager;

		public BicycleService(IRepositoryManager<T> repositoryManager)
			=> _repositoryManager = repositoryManager;

		public IEnumerable<T> GetAllBicycles()
		{
			var bicycles = _repositoryManager.Bicycle.GetBicycles();
			
			return bicycles;
		}

		public T GetBicycle(int id)
		{
			var bicycle = _repositoryManager.Bicycle.GetBicycle(id);
	
			return bicycle;
		}

		public T CreateBicycle(T bicycle)
        {
			_repositoryManager.Bicycle.CreateBicycle(bicycle);

			return bicycle;
		}

		public void UpdateBicycle(T bicycle, bool compTrackChanges) 
		{
			_repositoryManager.Bicycle.UpdateBicycle(bicycle);
		}

		public void DeleteBicycle(int id)
		{
			var bicycle = _repositoryManager.Bicycle.GetBicycle(id);

			if(bicycle is null)
				throw new Exception();

			_repositoryManager.Bicycle.DeleteBicycle(bicycle);
		}
	}
}

