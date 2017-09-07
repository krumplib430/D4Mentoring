using System;
using System.Collections.Generic;
using NoteTaking.Wcf.Contracts.Models;
using NoteTaking.Wcf.TestClient.UserServiceReference;

namespace NoteTaking.Wcf.TestClient
{
	public class Program
	{
		private const string BASIC_HTTP_ENDPOINT_NAME = "basicHttp";
		private const string NET_NAMED_PIPE_ENDPOINT_NAME = "netNamedPipe";

		public static void Main(string[] args)
		{
			var userServiceClient = new UserServiceClient(NET_NAMED_PIPE_ENDPOINT_NAME);

			var userListItemDtos = userServiceClient.GetAll();

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
			var userDtoagain = userServiceClient.Get(userDto.Id);
		}
	}
}