using Fenicia.Application.Common.Interfaces.UseCases;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fenicia.Application.UseCases.Categories.Get.GetById
{
    public class GetCategoryByIdRequest : IRequestInteractor<GetCategoryByIdResponse>
    {
        public Guid Id { get; set; }
    }
}
