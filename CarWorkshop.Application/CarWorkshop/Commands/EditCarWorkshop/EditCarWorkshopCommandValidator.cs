using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarWorkshop.Domain.Interfaces;
using FluentValidation;

namespace CarWorkshop.Application.CarWorkshop.Commands.EditCarWorkshop
{
    public class EditCarWorkshopCommandValidator : AbstractValidator<EditCarWorkshopCommand>
    {
        public EditCarWorkshopCommandValidator(ICarWorkshopRepository carWorkshopRepository)
        {
            RuleFor(r => r.Description)
                .NotEmpty()
                .WithMessage("Description is required.");

            RuleFor(r => r.PhoneNumber)
                .MinimumLength(8)
                .MaximumLength(12);
        }
    }
}