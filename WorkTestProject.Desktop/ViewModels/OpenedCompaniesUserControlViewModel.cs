using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkTestProject.App.Queries;
using WorkTestProject.Desktop.ViewModels.BaseVM;
using WorkTestProject.Persistence;

namespace WorkTestProject.Desktop.ViewModels
{
    class OpenedCompaniesUserControlViewModel : BaseViewModel, IDisposable
    {
        #region fields
        private readonly GetOpenedCompaniesQuery _openedCompaniesQuery;
        private readonly CompanyDbContext _dbContext;
        #endregion

        #region properties
        private ObservableCollection<CompanyViewModel> _openedCompanies;
        public ObservableCollection<CompanyViewModel> OpenedCompanies
        {
            get => _openedCompanies;
            set
            {
                _openedCompanies = value;
                OnPropertyChanged(nameof(OpenedCompanies));
            }
        }
        #endregion

        #region constructor
        public OpenedCompaniesUserControlViewModel(CompanyDbContext dbContext)
        {
            _dbContext = dbContext;
            //_dbContext.Database.EnsureCreated();

            _openedCompaniesQuery = new GetOpenedCompaniesQuery(_dbContext);
            OpenedCompanies = new ObservableCollection<CompanyViewModel>(_openedCompaniesQuery.Get());
        }
        #endregion

        public void Dispose()
        {
            DbInitializer.Destroy(_dbContext);
        }
    }
}
