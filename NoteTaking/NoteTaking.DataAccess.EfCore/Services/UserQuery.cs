using System;
using System.Collections.Generic;
using System.Linq;
using NoteTaking.Common.Mapping;
using NoteTaking.DataAccess.Contracts;
using NoteTaking.DataAccess.EfCore.Models;
using NoteTaking.Models;

namespace NoteTaking.DataAccess.EfCore.Services
{
	public class UserQuery : IUserQuery
	{
		private readonly IMappingService _mappingService;

		public UserQuery(IMappingService mappingService)
		{
			_mappingService = mappingService;
		}

		public List<User> GetAll()
		{
			throw new NotImplementedException();
		}

		public User Get(Guid id)
		{
			using (var context = new NoteTakingContext())
			{
				var userDao = context.Users.FirstOrDefault(u => u.Id == id);
				return userDao == null ? null : _mappingService.Map<UserDao, User>(userDao);
			}
		}
	}
}