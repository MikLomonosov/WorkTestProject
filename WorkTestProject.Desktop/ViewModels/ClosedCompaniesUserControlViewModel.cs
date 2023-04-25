using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WorkTestProject.App.Queries;
using WorkTestProject.Desktop.Commands;
using WorkTestProject.Desktop.Interfaces;
using WorkTestProject.Desktop.ViewModels.BaseVM;
using WorkTestProject.Persistence;

namespace WorkTestProject.Desktop.ViewModels
{
    class ClosedCompaniesUserControlViewModel : BaseViewModel, IDisposable
    {
        #region fields
        private readonly GetClosedCompaniesQuery _closedCompaniesQuery;
        private readonly CompanyDbContext _dbContext;
        //public event Action<BaseViewModel, string> ChangeContent;
        #endregion

        #region properties
        private ObservableCollection<CompanyViewModel> _closedCompanies;
        public ObservableCollection<CompanyViewModel> ClosedCompanies
        {
            get => _closedCompanies;
            set
            {
                _closedCompanies = value;
                OnPropertyChanged(nameof(ClosedCompanies));
            }
        }
        #endregion

        #region constructor
        public ClosedCompaniesUserControlViewModel()
        {

            _dbContext = DbInitializer.Initialize();
            _dbContext.Database.EnsureCreated();

            _closedCompaniesQuery = new GetClosedCompaniesQuery(_dbContext);
            ClosedCompanies = new ObservableCollection<CompanyViewModel>(_closedCompaniesQuery.Get());
        }
        #endregion

        public void Dispose()
        {
            DbInitializer.Destroy(_dbContext);
        }
    }
}
