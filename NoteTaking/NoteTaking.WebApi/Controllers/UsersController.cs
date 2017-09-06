using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using NoteTaking.Common.Mapping;
using NoteTaking.WebApi.Models;
using NoteTaking.WebApi.Repositories;

namespace NoteTaking.WebApi.Controllers
{
	[Route("api/users")]
	public class UsersController : Controller
	{
		private readonly IUserRepository _userRepository;
		private readonly IMappingService _mappingService;

		public UsersController(IUserRepository userRepository, IMappingService mappingService)
		{
			_userRepository = userRepository;
			_mappingService = mappingService;
		}

		[ProducesResponseType(200)]
		[HttpGet]
		public async Task<IActionResult> Get()
		{
			var userListItemDtos = await _userRepository.GetAllAsync();

			return Ok(userListItemDtos);
		}

		[ProducesResponseType(200)]
		[ProducesResponseType(404)]
		[HttpGet("{userId}", Name = "GetUser")]
		public async Task<IActionResult> Get([FromRoute] Guid userId)
		{
			var userDto = await _userRepository.GetAsync(userId);

			if (userDto == null)
			{
				return NotFound();
			}

			return Ok(userDto);
		}

		[ProducesResponseType(201)]
		[ProducesResponseType(400)]
		[ProducesResponseType(409)]
		[HttpPost]
		public async Task<IActionResult> Post([FromBody] UserCreateDto userCreateDto)
		{
			if (userCreateDto == null)
			{
				return BadRequest();
			}

			var userDto = await _userRepository.CreateAsync(userCreateDto);

			return CreatedAtRoute("GetUser", new { UserId = userDto.Id }, userDto);
		}

		[ProducesResponseType(200)]
		[ProducesResponseType(400)]
		[ProducesResponseType(404)]
		[HttpPut("{userId}")]
		public async Task<IActionResult> Put([FromRoute] Guid userId, [FromBody] UserUpdateDto userUpdateDto)
		{
			if (userUpdateDto == null)
			{
				return BadRequest();
			}

			// TODO: implement exists
			var userDto = await _userRepository.GetAsync(userId);
			if (userDto == null)
			{
				return NotFound();
			}

			await _userRepository.UpdateAsync(userUpdateDto);

			return Ok();
		}

		[ProducesResponseType(200)]
		[ProducesResponseType(400)]
		[ProducesResponseType(404)]
		[HttpPatch("{userId}")]
		public async Task<IActionResult> Patch([FromRoute] Guid userId, [FromBody] JsonPatchDocument<UserUpdateDto> jsonPatchDocument)
		{
			if (jsonPatchDocument == null)
			{
				return BadRequest();
			}

			var storedUserDto = await _userRepository.GetAsync(userId);
			if (storedUserDto == null)
			{
				return NotFound();
			}

			var storedUserUpdateDto = _mappingService.Map<UserDto, UserUpdateDto>(storedUserDto);
			jsonPatchDocument.ApplyTo(storedUserUpdateDto);

			await _userRepository.UpdateAsync(storedUserUpdateDto);

			return Ok();
		}

		[ProducesResponseType(200)]
		[ProducesResponseType(404)]
		[HttpDelete("{userId}")]
		public async Task<IActionResult> Delete([FromRoute] Guid userId)
		{
			var storedUserDto = await _userRepository.GetAsync(userId);
			if (storedUserDto == null)
			{
				return NotFound();
			}

			await _userRepository.DeleteAsync(userId);

			return Ok();
		}
	}
}