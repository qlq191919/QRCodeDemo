using Prism.DryIoc;
using Prism.Ioc;
using QRCodeDemo.ViewModels;
using QRCodeDemo.Views;
using System.Windows;

namespace QRCodeDemo
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<MainWindow, MainWindowViewModel>();
            containerRegistry.RegisterForNavigation<QRCode, QRCodeViewModel>();
        }
    }
}
