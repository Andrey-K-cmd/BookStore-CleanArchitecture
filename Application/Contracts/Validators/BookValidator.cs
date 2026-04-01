using Application.Contracts.Store;
using FluentValidation;

namespace Application.Contracts.Validators
{
    public class BookValidator : AbstractValidator<BookRequest>
    {
        public BookValidator()
        {
            RuleFor(b => b.Title)
                .NotEmpty().WithMessage("Книга не может быть без названия")
                .MaximumLength(250).WithMessage("Назвние должно быть не более 250 символов");

            RuleFor(b => b.Author)
                .NotEmpty().WithMessage("Автор должен быть обязательно указан");

            RuleFor(b => b.PublishingYear)
                .InclusiveBetween(1500, DateTime.Now.Year)
                .WithMessage("Неправильный год");

            RuleFor(b => b.CountPages)
                .GreaterThan(0)
                .WithMessage("Кол-во страниц должно быть положительным");

            RuleFor(b => b.Price)
                .GreaterThan(0)
                .WithMessage("Цена должна быть положительной");
        }
    }
}
