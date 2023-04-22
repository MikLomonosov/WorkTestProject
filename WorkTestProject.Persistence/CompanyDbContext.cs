using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Protocols;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkTestProject.Application.Interfaces;
using WorkTestProject.Domain;
using WorkTestProject.Persistence.EntityTypeConfiguration;
using System.Configuration;
using Microsoft.Extensions.Configuration;

namespace WorkTestProject.Persistence
{
    public class CompanyDbContext : DbContext, ICompaniesDbContext
    {
        public DbSet<Company> Companies { get; set; }

        #region constructor
        public CompanyDbContext(DbContextOptions<CompanyDbContext> options)
            : base(options)
        {
            DbInitializer.Initialize(this);
        }
        #endregion

        //скорее всего лишний метод!!!
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new CompanyConfiguration());
            base.OnModelCreating(builder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            var connectionString = GetConfigurationOfDbConnection().GetConnectionString("DefaultConnection");
            builder.UseSqlServer(connectionString);
        }

        private IConfigurationRoot GetConfigurationOfDbConnection()
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();

            return configuration;
        }
    }
}
