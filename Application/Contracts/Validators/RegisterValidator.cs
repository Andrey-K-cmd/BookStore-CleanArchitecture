using Application.Contracts.Users;
using FluentValidation;

namespace Application.Contracts.Validators
{
    public class RegisterValidator : AbstractValidator<RegisterUserRequest>
    {
        public RegisterValidator()
        {
            RuleFor(u => u.Name)
                .NotEmpty().WithMessage("Имя должно быть указано");

            RuleFor(u => u.Email)
                .NotEmpty().WithMessage("Email должен бытть указан")
                .EmailAddress().WithMessage("Неверный формат адреса");

            RuleFor(u => u.Password)
                .NotEmpty().WithMessage("Пароль обязателен");
        }
    }
}
