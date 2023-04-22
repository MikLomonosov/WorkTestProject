using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkTestProject.Persistence
{
    public class DbInitializer
    {
        public static void Initialize(CompanyDbContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
