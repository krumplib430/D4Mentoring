using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NoteTaking.Common.Mapping;
using NoteTaking.DataAccess.Contracts;
using NoteTaking.DataAccess.EfCore.Models;
using NoteTaking.Models;

namespace NoteTaking.DataAccess.EfCore.Services
{
	public class UserStore : IStore<User>
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

		public async Task UpdateAsync(User user)
		{
			using (var context = new NoteTakingContext())
			{
				var storedUserDao = await context.Users.FirstOrDefaultAsync(u => u.Id == user.Id);
				if (storedUserDao == null)
				{
					return;
				}

				storedUserDao.UserName = user.UserName;
				storedUserDao.FirstName = user.FirstName;
				storedUserDao.Lastname = user.Lastname;
				await context.SaveChangesAsync();
			}
		}

		public async Task DeleteAsync(Guid id)
		{
			using (var context = new NoteTakingContext())
			{
				var storedUserDao = await context.Users.FirstOrDefaultAsync(u => u.Id == id);
				if (storedUserDao == null)
				{
					return;
				}

				context.Entry(storedUserDao).State = EntityState.Deleted;
				await context.SaveChangesAsync();
			}
		}
	}
}