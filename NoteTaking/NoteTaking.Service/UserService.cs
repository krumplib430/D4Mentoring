using System;
using System.Collections.Generic;
using NoteTaking.Common.Wrappers;
using NoteTaking.DataAccess.Contracts;
using NoteTaking.Models;
using NoteTaking.Service.Contracts;

namespace NoteTaking.Service
{
	public class UserService : IUserService
	{
		private readonly IGuidWrapper _guidWrapper;
		private readonly IDateTimeWrapper _dateTimeWrapper;
		private readonly IUserStore _userStore;
		private readonly IUserQuery _userQuery;

		public UserService(IGuidWrapper guidWrapper, IDateTimeWrapper dateTimeWrapper, IUserStore userStore, IUserQuery userQuery)
		{
			_guidWrapper = guidWrapper;
			_dateTimeWrapper = dateTimeWrapper;
			_userStore = userStore;
			_userQuery = userQuery;
		}

		/// <inheritdoc />
		public List<User> GetAll()
		{
			return _userQuery.GetAll();
		}

		/// <inheritdoc />
		public User Get(Guid id)
		{
			return _userQuery.Get(id);
		}

		/// <inheritdoc />
		public User Create(User user)
		{
			// TODO: do validation here using fluent validation

			user.Id = _guidWrapper.NewGuid();
			user.RegisteredOn = _dateTimeWrapper.UtcNow();

			_userStore.Create(user);

			return _userQuery.Get(user.Id.Value);
		}
	}
}