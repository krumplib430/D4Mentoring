using System.Threading.Tasks;
using NoteTaking.Models;

namespace NoteTaking.DataAccess.Contracts
{
	public interface IUserStore
	{
		Task CreateAsync(User user);
	}
}