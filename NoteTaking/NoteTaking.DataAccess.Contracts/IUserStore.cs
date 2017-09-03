using NoteTaking.Models;

namespace NoteTaking.DataAccess.Contracts
{
	public interface IUserStore
	{
		void Create(User user);
	}
}