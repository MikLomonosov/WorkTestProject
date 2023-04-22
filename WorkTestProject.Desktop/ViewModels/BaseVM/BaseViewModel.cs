using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WorkTestProject.Desktop.ViewModels.BaseVM
{
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        #region INPC
        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string property = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
        #endregion

        protected BaseViewModel ChangeContext(BaseViewModel newContext)
        {
            return newContext;
        }
    }
}
