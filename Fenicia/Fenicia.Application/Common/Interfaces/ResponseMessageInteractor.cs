using System;
using System.Collections.Generic;
using System.Text;

namespace Fenicia.Application.Common.Interfaces.UseCases
{
    public abstract class ResponseMessageInteractor
    {
        public bool Success { get; }
        public string Message { get; }

        protected ResponseMessageInteractor(bool success = false, string message = null)
        {
            Success = success;
            Message = message;
        }
    }
}
