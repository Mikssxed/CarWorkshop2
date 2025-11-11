using CarWorkshop.Domain.Interfaces;
using FluentValidation;

namespace CarWorkshop.Application.CarWorkshop.Commands.CreateCarWorkshop;

public class CreateCarWorkshopCommandValidator : AbstractValidator<CreateCarWorkshopCommand>
{
    public CreateCarWorkshopCommandValidator(ICarWorkshopRepository carWorkshopRepository)
    {
        RuleFor(r => r.Name)
            .NotEmpty()
            .MaximumLength(20)
            .MinimumLength(2)
            .Custom((value, context) =>
            {
                var existingCarWorkshop = carWorkshopRepository.GetByName(value).Result;

                if (existingCarWorkshop != null)
                {
                    context.AddFailure($"{value} is not unique name for car workshop.");
                }
            });

        RuleFor(r => r.Description)
            .NotEmpty()
            .WithMessage("Description is required.");

        RuleFor(r => r.PhoneNumber)
            .MinimumLength(8)
            .MaximumLength(12);
    }
}