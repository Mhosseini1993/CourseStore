using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseStore.Application.Courses.Remove
{
    public record RemoveCourseCommand(int id) : IRequest
    {

    }

}
