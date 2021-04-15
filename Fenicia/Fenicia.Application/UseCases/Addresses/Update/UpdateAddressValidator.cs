using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fenicia.Application.UseCases.Addresses.Update
{
    class UpdateAddressValidator: AbstractValidator<UpdateAddressRequest>
    {
        public UpdateAddressValidator()
        {
            RuleFor(a => a.Description)
                .NotEmpty().WithMessage("La calle no puede estar vacía.");

            RuleFor(a => a.ZipCode)
                .NotEmpty().WithMessage("La código postal no puede estar vacío.");

            RuleFor(a => a.City)
                .NotEmpty().WithMessage("La ciudad no puede estar vacía.");

            RuleFor(a => a.CountryId)
                .NotEmpty().WithMessage("El país no puede estar vacío.");
        }
    }
}
