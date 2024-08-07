using MaterialDesignThemes.Wpf;
using System.Windows;
using System.Windows.Input;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using QRCodeDemo.ViewModels;
using QRCodeDemo.Views; 

namespace QRCodeDemo.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {

            InitializeComponent();
        }

        //Theme Code ========================>
        //public bool IsDarkTheme { get; set; }
        //private readonly PaletteHelper paletteHelper = new PaletteHelper();
        //===================================>

        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
            DragMove();
        }

      

        //private void toggleTheme(object sender, RoutedEventArgs e)
        //{
        //    //Theme Code ========================>
        //    ITheme theme = paletteHelper.GetTheme();
        //    if (IsDarkTheme = theme.GetBaseTheme() == BaseTheme.Dark)
        //    {
        //        IsDarkTheme = false;
        //        theme.SetBaseTheme(Theme.Light);
        //    }
        //    else
        //    {
        //        IsDarkTheme = true;
        //        theme.SetBaseTheme(Theme.Dark);
        //    }

        //    paletteHelper.SetTheme(theme);
        //    //===================================>
        //}

        //private void exitApp(object sender, RoutedEventArgs e)
        //{
        //    Application.Current.Shutdown();
        //}

    }
}
