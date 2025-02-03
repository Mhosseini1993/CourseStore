using CourseStore.Application.Courses.Add;
using CourseStore.Application.Courses.Edit;
using CourseStore.Application.Courses.Remove;
using CourseStore.Query.Courses.GetById;
using CourseStore.Query.Courses.GetList;
using EndPoint.UI.Shared.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EndPoint.UI.Controllers
{
    public class Utilities
    {
        public const string ApiPrefix = "{version:apiVersion}";
    }

    [Route($"api/V{Utilities.ApiPrefix}/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CourseController(IMediator mediator)
        {
            this._mediator=mediator;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var res = await _mediator.Send(new GetCourseListQuery());
            return Ok(res.Select(ef => CourseMapper.MapCourseReadModelToCourseViewModel(ef)).ToList());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var res = await _mediator.Send(new GetCourseByIdQuery(id));
            return Ok(CourseMapper.MapCourseReadModelToCourseViewModel(res));
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddCourseViewModel addCourseCommand)
        {
            AddCourseCommand command = new AddCourseCommand(addCourseCommand.Name, addCourseCommand.Description, addCourseCommand.Author, addCourseCommand.ReleaseDate, addCourseCommand.Level);

            await _mediator.Send(command);
            string? url = Url.Action(nameof(Get), "Course", new { id = 1 });
            return Created(url, true);
        }
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] EditCourseViewModel editCourseCommand)
        {
            EditCourseCommand command = new EditCourseCommand(editCourseCommand.Id, editCourseCommand.Name, editCourseCommand.Description, editCourseCommand.Author, editCourseCommand.ReleaseDate, editCourseCommand.Level);
            await _mediator.Send(command);
            string? url = Url.Action(nameof(Get), "Course", new { id = 1 });
            return Created(url, true);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var res = await _mediator.Send(new RemoveCourseCommand(id));
            return Ok();
        }
    }
}
