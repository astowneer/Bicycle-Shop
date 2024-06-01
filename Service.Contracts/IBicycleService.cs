using System;
using Entities.Models;
using Shared.DataTransferObjects;
namespace Service.Contracts
{
	public interface IBicycleService<T>
	{
		IEnumerable<T> GetAllBicycles();
		T GetBicycle(int id);
		T CreateBicycle(T bicycle);
		void UpdateBicycle(T bicycle, bool compTrackChanges);
		void DeleteBicycle(int id);
	}
}

