using System;
using System.Runtime.Serialization;

namespace NoteTaking.Wcf.Contracts.Models
{
	[DataContract]
	public class UserListItemDto
	{
		[DataMember]
		public Guid Id { get; set; }

		[DataMember]
		public string UserName { get; set; }

		[DataMember]
		public string FirstName { get; set; }

		[DataMember]
		public string Lastname { get; set; }

		[DataMember]
		public DateTime RegisteredOn { get; set; }
	}
}