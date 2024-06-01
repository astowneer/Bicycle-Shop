using System;

using Entities.Models;
namespace Contracts
{
	public interface IBicycleRepository<T>
	{
		IEnumerable<T> GetBicycles();
        T GetBicycle(int id);
		void CreateBicycle(T bicycle);
		void UpdateBicycle(T bicycle);
		void DeleteBicycle(T bicycle);
    }
}

