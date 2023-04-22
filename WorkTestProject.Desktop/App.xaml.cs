using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using WorkTestProject.Desktop.ViewModels;

namespace WorkTestProject.Desktop
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private MainWindowViewModels startViewModel;
        protected async override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            startViewModel = new MainWindowViewModels();
            new MainWindow
            {
                DataContext = startViewModel
            }.Show();
        }
    }
}
