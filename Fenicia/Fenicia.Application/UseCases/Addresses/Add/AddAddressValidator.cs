using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fenicia.Application.UseCases.Addresses.Add
{
    public class AddAddressValidator : AbstractValidator<AddAddressRequest>
    {
        public AddAddressValidator()
        {
            RuleFor(a => a.Description)
                .NotEmpty().WithMessage("La calle no puede estar vacía.");

            RuleFor(a => a.ZipCode)
                .NotEmpty().WithMessage("La código postal no puede estar vacío.");

            RuleFor(a => a.Country)
                .NotEmpty().WithMessage("El país no puede estar vacío.");
        }
    }
}
