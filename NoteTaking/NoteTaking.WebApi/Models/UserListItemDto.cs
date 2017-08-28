using System;

namespace NoteTaking.WebApi.Models
{
	public class UserListItemDto
	{
		public Guid Id { get; set; }

		public string FirstName { get; set; }

		public string Lastname { get; set; }

		public byte[] ConcurrencyToken { get; set; }
	}
}