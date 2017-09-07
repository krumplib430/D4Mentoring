using System;
using System.Collections.Generic;
using NoteTaking.Wcf.Contracts.Models;
using NoteTaking.Wcf.TestClient.UserServiceReference;

namespace NoteTaking.Wcf.TestClient
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var userServiceClient = new UserServiceClient();

			var userCreateDto = new UserCreateDto
			{
				UserName = Guid.NewGuid().ToString().Substring(0, 10),
				FirstName = "b",
				Lastname = "c",
				Notes = new List<NoteCreateDto>
				{
					new NoteCreateDto
					{
						Text = "Salala",
						Title = Guid.NewGuid().ToString().Substring(0, 10)
					},
					new NoteCreateDto
					{
						Text = "Salala",
						Title = Guid.NewGuid().ToString().Substring(0, 10)
					}
				}
			};

			var userDto = userServiceClient.Create(userCreateDto);
		}
	}
}