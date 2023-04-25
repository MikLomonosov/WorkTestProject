using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkTestProject.App.Interfaces;

namespace WorkTestProject.App.Queries
{
    public class GetClosedCompaniesQuery
    {
        private readonly ICompaniesDbContext _dbContext;

        #region constructor
        public GetClosedCompaniesQuery(ICompaniesDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        #endregion

        #region methods
        public async Task<List<CompanyViewModel>> GetAsync()
        {
            var result = await _dbContext.Companies
                    .Where(company => company.IsOpen == true)
                    .Select(company => new CompanyViewModel
                    {
                        INN = company.INN,
                        Name = company.Name,
                        City = company.City,
                        Region = company.Region
                    })
                    .ToListAsync();

            return result;
        }

        public List<CompanyViewModel> Get()
        {
            var result = _dbContext.Companies
                    .Where(company => company.IsOpen == false)
                    .Select(company => new CompanyViewModel
                    {
                        INN = company.INN,
                        Name = company.Name,
                        City = company.City,
                        Region = company.Region
                    })
                    .ToList();

            return result;
        }
        #endregion
    }
}
