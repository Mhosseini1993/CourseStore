using FluentValidation;

namespace CourseStore.Application.Users.Register
{
    public class RegisterUserCommandValidator : AbstractValidator<RegisterUserCommand>
    {
        public RegisterUserCommandValidator()
        {
            RuleFor(ef => ef.PhoneNumber)
                .NotNull()
                .WithMessage("شماره تلفن نمی تواند خالی باشد");


            RuleFor(ef => ef.PhoneNumber.Number)
                .NotNull()
                .NotEmpty()
                .WithMessage("شماره تلفن نمی تواند خالی باشد");

                RuleFor(ef => ef.PhoneNumber.Number)
                .MinimumLength(11)
                .MaximumLength(11)
                .WithMessage("شماره تلفن معتبر نمی باشد");


        }
    }
}
