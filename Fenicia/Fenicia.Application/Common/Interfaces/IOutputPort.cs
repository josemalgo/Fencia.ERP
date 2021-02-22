using System;
using System.Collections.Generic;
using System.Text;

namespace Fenicia.Application.Common.Interfaces
{
    public interface IOutputPort<in TUseCaseResponse>
    {
        void Handle(TUseCaseResponse response);
    }
}
