using Fenicia.Application.Common.Interfaces.UseCases;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fenicia.Application.UseCases.RegisterEmployee
{
    public class RegisterEmployeeResponse : ResponseMessageInteractor
    {
        public RegisterEmployeeResponse(ValidationResult validationResult, Guid? id = null)
            : base(validationResult, id)
        {

        }
    }
}
