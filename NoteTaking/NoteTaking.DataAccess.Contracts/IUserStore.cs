using NoteTaking.Models;

namespace NoteTaking.DataAccess.Contracts
{
	public interface IUserStore
	{
		bool Create(User user);
	}
}