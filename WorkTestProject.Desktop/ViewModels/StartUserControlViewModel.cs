using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WorkTestProject.Desktop.Commands;
using WorkTestProject.Desktop.Interfaces;
using WorkTestProject.Desktop.ViewModels.BaseVM;
using WorkTestProject.Persistence;

namespace WorkTestProject.Desktop.ViewModels
{
    internal class StartUserControlViewModel : BaseViewModel, IChangeableContent
    {
        public event Action<BaseViewModel, string> ChangeContent;
        private readonly CompanyDbContext _dbContext;

        #region commands
        private readonly ICommand _toOpenedCompaniesCommand;
        public ICommand ToOpenedCompaniesCommand => _toOpenedCompaniesCommand;

        private readonly ICommand _toClosedCompaniesCommand;
        public ICommand ToClosedCompaniesCommand => _toClosedCompaniesCommand;

        private readonly ICommand _closeDbConnectionCommand;
        public ICommand CloseDbConnectionCommand => _closeDbConnectionCommand;

        private readonly ICommand _toStartMenu;
        public ICommand ToStartMenu => _toStartMenu;

        #endregion

        #region constructor
        public StartUserControlViewModel()
        {
            _dbContext = DbInitializer.Initialize();
            _dbContext.Database.EnsureCreated();

            _toOpenedCompaniesCommand = new RelayCommand(p =>
                ChangeContentCommandHandler(new OpenedCompaniesUserControlViewModel(_dbContext), "Visible"));

            _toClosedCompaniesCommand = new RelayCommand(p =>
                ChangeContentCommandHandler(new ClosedCompaniesUserControlViewModel(_dbContext), "Visible"));

            _closeDbConnectionCommand = new RelayCommand(p => DbInitializer.Destroy(_dbContext));
        }
        #endregion

        #region methods

        private void ChangeContentCommandHandler(BaseViewModel viewModel, string backButtonVisibility)
        {
            ChangeContent?.Invoke(viewModel, backButtonVisibility);
        }
        #endregion


    }
}
