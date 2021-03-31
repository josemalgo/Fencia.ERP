using Fenicia.Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fenicia.Application.Common.Validators
{
    public class AddressValidator : AbstractValidator<Address>
    {
        public AddressValidator()
        {
            RuleFor(a => a.Description)
                .NotEmpty().WithMessage("La calle no puede estar vacía.");

            RuleFor(a => a.ZipCode)
                .NotEmpty().WithMessage("La código postal no puede estar vacío.");

            //RuleFor(a => a.City)
            //    .SetValidator(new CityValidator());
        }
    }
}
