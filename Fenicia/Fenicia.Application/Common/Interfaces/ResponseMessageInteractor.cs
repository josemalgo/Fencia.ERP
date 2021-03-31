using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fenicia.Application.Common.Interfaces.UseCases
{
    public abstract class ResponseMessageInteractor
    {
        public ValidationResult ValidationResult { get; }
        public Guid? Id { get; private set; }

        protected ResponseMessageInteractor(ValidationResult validationResult, Guid? id = null)
        {
            Id = id;
            ValidationResult = validationResult;
        }
    }
}
