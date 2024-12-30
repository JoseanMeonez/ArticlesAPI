using Application.Features.Articles.Command;
using Application.Features.Articles.Queries;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("[controller]")]
public class ArticleController : ControllerBase
{
	[HttpGet]
	public async Task<IActionResult> GetAll([FromQuery] GetAllQuery query)
	{
		return Ok(await Mediator.Send(query));
	}

	[HttpPost]
	public async Task<IActionResult> Create([FromBody] CreateCommand command)
	{
		return Ok(await Mediator.Send(command));
	}
}
