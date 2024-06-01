using System;

using Contracts;
using Entities.Models;

namespace Repository
{
	public class BicycleRepository<T> : RepositoryBase<T>, IBicycleRepository<T>
        where T : AbstractBicycle, new()
	{
		public BicycleRepository(RepositoryContext<T> repositoryContext) : base(repositoryContext) { }

        public IEnumerable<T> GetBicycles() =>
            _repositoryContext.Entities.ToList();

        public T GetBicycle(int id) =>
            _repositoryContext.Entities.Where(m => m.Id == id)
                                       .FirstOrDefault();

        public void CreateBicycle(T bicycle) => Create(bicycle);

        public void UpdateBicycle(T bicycle)
        {
            int index = _repositoryContext.Entities.ToList().FindIndex(m => m.Id == bicycle.Id);

            Update(index, bicycle);
        }

        public void DeleteBicycle(T bicycle) => Delete(bicycle);
    }
}

