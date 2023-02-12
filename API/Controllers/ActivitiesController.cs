using Microsoft.AspNetCore.Mvc;
using Domain;
using MediatR;
using Application.Activities;

namespace API.Controllers
{
	public class ActivitiesController : BaseApiController
	{
		[HttpGet] // GET /api/activities
		public async Task<ActionResult<List<Activity>>> GetActivities(CancellationToken ct)
		{
			return await Mediator.Send(new List.Query(), ct);
		}

		[HttpGet("{id}")] // GET /api/activities/{id}
		public async Task<ActionResult<Activity>> GetActivity(Guid id)
		{
			return await Mediator.Send(new Details.Query { Id = id });
		}

		[HttpPost] // POST /api/activities
		public async Task<IActionResult> CreateActivity([FromBody] Activity activity)
		{
			return Ok(await Mediator.Send(new Create.Command { Activity = activity }));
		}

		[HttpPut("{id}")] // PUT /api/activities
		public async Task<IActionResult> EditActivity(Guid id, Activity activity)
		{
			activity.Id = id;
			return Ok(await Mediator.Send(new Edit.Command { Activity = activity }));
		}

		[HttpDelete("{id}")] // DELETE /api/activities
		public async Task<IActionResult> DeleteActivity(Guid id)
		{
			return Ok(await Mediator.Send(new Delete.Command { Id = id }));
		}
	}
}