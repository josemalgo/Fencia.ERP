using Fenicia.Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fenicia.Application.Common.Validators
{
    class CityValidator : AbstractValidator<City>
    {
        public CityValidator()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("El nombre de la ciudad no puede estar vacía.");

            RuleFor(c => c.Country)
                .SetValidator(new CountryValidator());
        }
    }
}
