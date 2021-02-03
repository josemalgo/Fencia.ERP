using Fenicia.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fenicia.Application.Common.Interfaces
{
    public interface IFeniciaDbContext
    {
        DbSet<Person> Persons { get; set; }

        DbSet<Menu> Menus { get; set; }

        //Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
