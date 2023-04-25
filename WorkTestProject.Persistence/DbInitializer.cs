using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkTestProject.Persistence
{
    public class DbInitializer
    {
        #region constructor
        public DbInitializer()
        {

        }
        #endregion

        #region methods
        public static CompanyDbContext Initialize()
        {
            //var appSettingsJson = GetAppSettings();
            //var connectionString = appSettingsJson["DefaultConnection"];
            var connectionString = GetAppSettings().GetConnectionString("DefaultConnection");

            var contextOptions = new DbContextOptionsBuilder<CompanyDbContext>()
                .UseSqlServer(connectionString)
                .Options;

            var context = new CompanyDbContext(contextOptions);
            return context;
        }

        private static IConfigurationRoot GetAppSettings()
        {
            string projectPath = AppDomain.CurrentDomain.BaseDirectory
                .Split(new String[] { @"bin\" }, StringSplitOptions.None)[0];
            var builder = new ConfigurationBuilder()
                .SetBasePath(projectPath)
                .AddJsonFile("appsettings.json")
                .Build();

            return builder;
        }

        public async static void Destroy(CompanyDbContext context)
        {
            await context.Database.EnsureDeletedAsync();
            await context.DisposeAsync();
        }
        #endregion
    }
}
