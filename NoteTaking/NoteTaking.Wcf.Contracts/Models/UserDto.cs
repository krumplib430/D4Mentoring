using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace NoteTaking.Wcf.Contracts.Models
{
	[DataContract]
	public class UserDto
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

		[DataMember]
		public List<NoteDto> Notes { get; set; }
	}
}