using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Protocols;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkTestProject.Domain;
using WorkTestProject.Persistence.EntityTypeConfiguration;
using System.Configuration;
using Microsoft.Extensions.Configuration;
using WorkTestProject.App.Interfaces;

namespace WorkTestProject.Persistence
{
    public class CompanyDbContext : DbContext, ICompaniesDbContext
    {
        public DbSet<Company> Companies { get; set; }

        #region constructor
        public CompanyDbContext(DbContextOptions<CompanyDbContext> options)
            :base(options)
        {
        }
        #endregion


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new CompanyConfiguration());
            //builder.Entity<Company>().ToTable("Test$");
            base.OnModelCreating(builder);
        }
    }
}
