using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fenicia.Application.Common.Interfaces.UseCases
{
    public abstract class ResponseMessageInteractor
    {
        public ValidationResult ValidationResult { get; set; }
        public Guid? Id { get; private set; }
    }
}
