using Application.Contracts.Users;
using FluentValidation;

namespace Application.Contracts.Validators
{
    public class LoginValidator : AbstractValidator<LoginUserRequest>
    {
        public LoginValidator()
        {
            RuleFor(u => u.Email)
                .NotEmpty().WithMessage("Email должен бытть указан")
                .EmailAddress().WithMessage("Неверный формат адреса");

            RuleFor(u => u.Password)
                .NotEmpty().WithMessage("Пароль обязателен");
        }
    }
}
