using System;
using System.Threading.Tasks;

namespace NoteTaking.DataAccess.Contracts
{
	public interface IStore<in T>
	{
		Task CreateAsync(T entity);

		Task UpdateAsync(T entity);

		Task DeleteAsync(Guid id);
	}
}