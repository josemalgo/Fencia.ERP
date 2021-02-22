using Fenicia.Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fenicia.Application.Common.Validators
{
    class CountryValidator : AbstractValidator<Country>
    {
        public CountryValidator()
        {
            RuleFor(a => a.Name)
                    .NotEmpty().WithMessage("El nombre del país no puede estar vacío.");
        }
    }
}
