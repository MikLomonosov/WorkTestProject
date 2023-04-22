using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkTestProject.Domain;

namespace WorkTestProject.Application.Interfaces
{
    public interface ICompaniesDbContext
    {
        DbSet<Company> Companies { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
