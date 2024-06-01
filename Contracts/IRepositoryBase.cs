using System;

using Entities.Models;
namespace Contracts
{
	public interface IRepositoryBase<T>
	{
		void Create(T entity);
		void Update(int index, T entity);
		void Delete(T entity);
	}
}

