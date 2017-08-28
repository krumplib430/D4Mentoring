using Microsoft.AspNetCore.Mvc;
using NoteTaking.WebApi.Models;
using NoteTaking.WebApi.Repositories;

namespace NoteTaking.WebApi.Controllers
{
	[Route("api/users")]
	public class UsersController : Controller
	{
		private readonly IUserRepository _userRepository;

		public UsersController(IUserRepository userRepository)
		{
			_userRepository = userRepository;
		}

		[ProducesResponseType(200)]
		[HttpGet]
		public IActionResult Get()
		{
			var userListItemDtos = _userRepository.GetAll();

			return Ok(userListItemDtos);
		}

		[ProducesResponseType(201)]
		[ProducesResponseType(400)]
		[ProducesResponseType(409)]
		[HttpPost]
		public IActionResult Post([FromBody] UserCreateDto userCreateDto)
		{
			if (userCreateDto == null)
			{
				return BadRequest();
			}

			var userDto = _userRepository.Create(userCreateDto);

			return CreatedAtRoute("GetUser", new { UserId = userDto.Id }, userDto);
		}
	}
}