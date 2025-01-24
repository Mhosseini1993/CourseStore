using FluentValidation;

namespace CourseStore.Application.Courses.Add
{
    public class AddCourseCommandValidator:AbstractValidator<AddCourseCommand> 
    {
        public AddCourseCommandValidator()
        {
            RuleFor(r=>r.Name)
                .NotEmpty()
                .WithMessage("نام نمی تواند خالی باشد");

            RuleFor(r => r.Description)
                .NotEmpty()
                .WithMessage("توضیحات نمی تواند خالی باشد")
                .MinimumLength(10)
                .WithMessage("حداقل طول باید 5 باشد");

        }
    }
    
}
