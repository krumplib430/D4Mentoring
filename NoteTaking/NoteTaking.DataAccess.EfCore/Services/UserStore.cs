using System.Threading.Tasks;
using NoteTaking.Common.Mapping;
using NoteTaking.DataAccess.Contracts;
using NoteTaking.DataAccess.EfCore.Models;
using NoteTaking.Models;

namespace NoteTaking.DataAccess.EfCore.Services
{
	public class UserStore : IUserStore
	{
		private readonly IMappingService _mappingService;

		public UserStore(IMappingService mappingService)
		{
			_mappingService = mappingService;
		}

		/// <inheritdoc />
		public async Task CreateAsync(User user)
		{
			var userDao = _mappingService.Map<User, UserDao>(user);

			using (var context = new NoteTakingContext())
			{
				context.Users.Add(userDao);
				await context.SaveChangesAsync();
			}
		}
	}
}