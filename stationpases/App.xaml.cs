using stationpases.Model;
using stationpases.Views;
using stationpases.VMs;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace stationpases
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public DisplayRootRegistry displayRootRegistry = new DisplayRootRegistry();

        public App()
        {
           // displayRootRegistry.RegisterWindowType<MainWindowVM, Views.MainWindowView>();
            displayRootRegistry.RegisterWindowType<AddVisitorVM, AddVisitorWindow>();
            displayRootRegistry.RegisterWindowType<DocumentType, OneValueV>();
        }

        protected override async void OnStartup(StartupEventArgs e)
        {        
            base.OnStartup(e);

            var MainWindowVM = new AddVisitorVM();

            await displayRootRegistry.ShowModalPresentation(MainWindowVM);

            Shutdown();
        }

        protected override void OnExit(ExitEventArgs e)
        {           
            base.OnExit(e);
        }

    }
}
