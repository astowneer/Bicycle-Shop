using System;
using Contracts;
using Entities.Models;
namespace Repository
{
	public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : AbstractBicycle, new()
	{
		protected RepositoryContext<T> _repositoryContext;

		public RepositoryBase(RepositoryContext<T> repositoryContext) =>
			_repositoryContext = repositoryContext;

		public void Create(T entity)
		{
			_repositoryContext.Add(entity);
			_repositoryContext.SaveAllChanges();
		}

		public void Update(int index, T entity)
		{
			_repositoryContext.Edit(index);
			_repositoryContext.Insert(entity, index);
            _repositoryContext.SaveAllChanges();
        }

        public void Delete(T entity)
		{
			_repositoryContext.Remove(entity);
			_repositoryContext.SaveAllChanges();
        }
    } 
}

