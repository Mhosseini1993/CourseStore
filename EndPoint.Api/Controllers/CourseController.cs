using AutoMapper;
using CourseStore.Application.Courses.Add;
using CourseStore.Application.Courses.Edit;
using CourseStore.Application.Courses.Remove;
using CourseStore.Query.Courses.GetById;
using CourseStore.Query.Courses.GetList;
using CourseStore.Query.Users.GetByPhoneNumber;
using EndPoint.Api.ViewModels.Course;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EndPoint.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CourseController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public CourseController(IMediator mediator, IMapper mapper)
        {
            this._mediator=mediator;
            this._mapper=mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetCourses()
        {
            var res = await _mediator.Send(new GetCourseListQuery());
            var res2 = _mapper.Map<List<CourseViewModel>>(res);
            res2.ForEach(t => t.GenerateLink());
            return Ok(res2);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCourseById(int id)
        {
            var res = await _mediator.Send(new GetCourseByIdQuery(id));
            return Ok(res);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCourse([FromBody] AddCourseCommand command)
        {
            var res = await _mediator.Send(command);
            string url = Url.Action(nameof(GetCourseById), nameof(CourseController), new { id = res }, HttpContext.Request.Scheme);
            return Created(url, res);
        }

        [HttpPut]
        public async Task<IActionResult> EditCourse([FromBody] EditCourseCommand command)
        {
            await _mediator.Send(command);
            //string url = Url.Action(nameof(GetCourseById), nameof(CourseController), new { id = res }, HttpContext.Request.Scheme);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourse(int id)
        {
            await _mediator.Send(new RemoveCourseCommand(id));
            return Ok();
        }

        [HttpPost("Image")]
        public async Task<IActionResult> CreateCourseImage([FromBody] AddCourseCommand command)
        {
            var res = await _mediator.Send(command);
            string url = Url.Action(nameof(GetCourseById), nameof(CourseController), new { id = res }, HttpContext.Request.Scheme);
            return Created(url, res);
        }
    }
}
