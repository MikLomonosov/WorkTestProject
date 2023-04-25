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

namespace WorkTestProject.Desktop.ViewModels
{
    class MainWindowViewModels : BaseViewModel
    {
        private BaseViewModel _currentContent;
        private readonly IChangeableContent _changeableViewModel;

        public BaseViewModel CurrentContent
        {
            get => _currentContent;
            set
            {
                _currentContent = value;
                OnPropertyChanged(nameof(CurrentContent));
            }
        }

        private string _backMenuButtonVisibility;
        public string BackMenuButtonVisibility
        {
            get => _backMenuButtonVisibility;
            set
            {
                _backMenuButtonVisibility = value;
                OnPropertyChanged(nameof(BackMenuButtonVisibility));
            }
        }


        #region commands
        private readonly ICommand _toStartMenu;
        public ICommand ToStartMenu => _toStartMenu;
        #endregion

        #region constructor
        public MainWindowViewModels()
        {
            _changeableViewModel = new StartUserControlViewModel();
            CurrentContent = (BaseViewModel)_changeableViewModel;

            _changeableViewModel.ChangeContent += SwitchCurrentContent;

            _toStartMenu = new RelayCommand(p => SwitchCurrentContent((BaseViewModel)_changeableViewModel, "Collapsed"));

            BackMenuButtonVisibility = "Collapsed";
        }
        #endregion
        
        private void SwitchCurrentContent(BaseViewModel viewModel, string backButtonVisibility)
        {
            CurrentContent = viewModel;
            this.BackMenuButtonVisibility = backButtonVisibility;
        }
    }
}
