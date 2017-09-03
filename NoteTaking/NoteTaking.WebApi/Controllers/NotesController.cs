using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NoteTaking.WebApi.Models;

namespace NoteTaking.WebApi.Controllers
{
	[Route("api/users/{userId}/notes")]
	public class NotesController : Controller
	{
		[ProducesResponseType(200)]
		[HttpGet]
		public async Task<IActionResult> Get()
		{
			throw new NotImplementedException();
		}

		[ProducesResponseType(200)]
		[ProducesResponseType(404)]
		[HttpGet("{noteId}", Name = "GetNote")]
		public async Task<IActionResult> Get([FromRoute] Guid userId, Guid noteId)
		{
			throw new NotImplementedException();
		}

		[ProducesResponseType(201)]
		[ProducesResponseType(400)]
		[ProducesResponseType(409)]
		[HttpPost]
		public async Task<IActionResult> Post([FromRoute] Guid userId, [FromBody] NoteCreateDto noteCreateDto)
		{
			throw new NotImplementedException();
		}

		[ProducesResponseType(200)]
		[ProducesResponseType(400)]
		[ProducesResponseType(404)]
		[HttpPut("{noteId}")]
		public async Task<IActionResult> Put([FromRoute] Guid userId, [FromRoute] Guid noteId, [FromBody] NoteUpdateDto noteUpdateDto)
		{
			throw new NotImplementedException();
		}

		[ProducesResponseType(200)]
		[ProducesResponseType(400)]
		[ProducesResponseType(404)]
		[HttpPatch("{noteId}")]
		public async Task<IActionResult> Patch([FromRoute] Guid userId, [FromRoute] Guid noteId, [FromBody] NoteUpdateDto noteUpdateDto)
		{
			throw new NotImplementedException();
		}

		[ProducesResponseType(200)]
		[ProducesResponseType(404)]
		[HttpDelete("{noteId}")]
		public async Task<IActionResult> Delete([FromRoute] Guid userId, [FromRoute] Guid noteId)
		{
			throw new NotImplementedException();
		}
	}
}