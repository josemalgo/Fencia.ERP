using Fenicia.Application.Common.Interfaces;
using Fenicia.Application.UseCases.RegisterEmployee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fenicia.ERP.Api.Presenter
{
    public class RegisterEmployeePresenter : IOutputPort<RegisterEmployeeResponse>
    {

        public void Handle(RegisterEmployeeResponse response)
        {
            throw new NotImplementedException();
        }
    }
}
