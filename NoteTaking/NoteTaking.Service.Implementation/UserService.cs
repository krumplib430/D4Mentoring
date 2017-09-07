using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NoteTaking.Common.Wrappers;
using NoteTaking.DataAccess.Contracts;
using NoteTaking.Models;
using NoteTaking.Service.Contracts;

namespace NoteTaking.Service.Implementation
{
	public class UserService : IUserService
	{
		private readonly IGuidWrapper _guidWrapper;
		private readonly IDateTimeWrapper _dateTimeWrapper;
		private readonly IStore<User> _userStore;
		private readonly IUserQuery _userQuery;

		public UserService(IGuidWrapper guidWrapper, IDateTimeWrapper dateTimeWrapper, IStore<User> userStore, IUserQuery userQuery)
		{
			_guidWrapper = guidWrapper;
			_dateTimeWrapper = dateTimeWrapper;
			_userStore = userStore;
			_userQuery = userQuery;
		}

		/// <inheritdoc />
		public async Task<List<User>> GetAllAsync()
		{
			return await _userQuery.GetAllAsync();
		}

		/// <inheritdoc />
		public async Task<User> GetAsync(Guid id)
		{
			return await _userQuery.GetAsync(id);
		}

		/// <inheritdoc />
		public async Task<User> CreateAsync(User user)
		{
			// TODO: do validation here using fluent validation

			SetDefaultParameters(user);

			await _userStore.CreateAsync(user);
			// ReSharper disable once PossibleInvalidOperationException
			return await _userQuery.GetAsync(user.Id.Value);
		}

		public async Task UpdateAsync(User user)
		{
			// TODO: do validation here using fluent validation

			await _userStore.UpdateAsync(user);
		}

		public async Task DeleteAsync(Guid id)
		{
			await _userStore.DeleteAsync(id);
		}

		private void SetDefaultParameters(User user)
		{
			var now = _dateTimeWrapper.UtcNow();
			user.Id = _guidWrapper.NewGuid();
			user.RegisteredOn = now;

			if (user.Notes != null && user.Notes.Any())
			{
				user.Notes.ForEach(n =>
				{
					n.CreatedOn = now;
					n.ModifiedOn = now;
				});
			}
		}
	}
}