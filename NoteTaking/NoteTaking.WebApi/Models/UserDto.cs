﻿using System;
using System.Collections.Generic;

namespace NoteTaking.WebApi.Models
{
	public class UserDto
	{
		public Guid Id { get; set; }

		public string UserName { get; set; }

		public string FirstName { get; set; }

		public string Lastname { get; set; }

		public DateTime RegisteredOn { get; set; }

		public List<NoteDto> Notes { get; set; }
	}
}