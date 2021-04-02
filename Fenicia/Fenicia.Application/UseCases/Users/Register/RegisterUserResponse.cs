using Fenicia.Application.Common.Interfaces.UseCases;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fenicia.Application.UseCases.Users.Register
{
    public class RegisterUserResponse : ResponseMessageInteractor
    {
        public RegisterUserResponse(ValidationResult validationResult, Guid? id = null)
            : base(validationResult, id)
        {

        }
    }
}
