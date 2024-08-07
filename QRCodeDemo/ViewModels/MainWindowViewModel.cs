using MaterialDesignThemes.Wpf;
using Prism.Commands;
using Prism.Mvvm;
using QRCodeDemo.SDK;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows;

namespace QRCodeDemo.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private string _text;
        public string Text
        {
            get { return _text; }
            set { SetProperty(ref _text, value); }
        }
        /// <summary>
        /// 正经2维码
        /// </summary>
        private Bitmap _QRCode_1;
        public Bitmap QRCode_1
        {
            get { return _QRCode_1; }
            set { SetProperty(ref _QRCode_1, value); }
        }
        /// <summary>
        /// 一维码
        /// </summary>
        private Image _QRCode_2;
        public Image QRCode_2
        {
            get { return _QRCode_2; }
            set { SetProperty(ref _QRCode_2, value); }
        }
        /// <summary>
        /// 带LOGO的二维码
        /// </summary>
        private Bitmap _QRCode_3;
        public Bitmap QRCode_3
        {
            get { return _QRCode_3; }
            set { SetProperty(ref _QRCode_3, value); }
        }
        private DelegateCommand<string> _GetQRCodeCommand;
        public DelegateCommand<string> GetQRCodeCommand =>
            _GetQRCodeCommand ?? (_GetQRCodeCommand = new DelegateCommand<string>(GetQRCode));

        private void GetQRCode(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                MessageBox.Show("请输入内容！");
                return;
            }
           QRtest.GenerateQRCode(text,300,300);
            ExportCode();
        }

        private DelegateCommand _ExportCodeCommand;
        public DelegateCommand ExportCodeCommand =>
            _ExportCodeCommand ?? (_ExportCodeCommand = new DelegateCommand(ExportCode));


        private void ExportCode()
        {

            if (File.Exists((@"二维码.png")))
            {
                Process.Start("explorer", "/select,\"" +(@"二维码.png") + "\"");
            }
        }
        private DelegateCommand _toggleThemeCommand;
        public DelegateCommand ToggleThemeCommand =>
           _toggleThemeCommand ?? (_toggleThemeCommand = new DelegateCommand(ToggleTheme));

        private bool _IsDarkTheme;
        public bool IsDarkTheme
        {
            get { return _IsDarkTheme; }
            set { SetProperty(ref _IsDarkTheme, value); }
        }
        private readonly PaletteHelper paletteHelper = new PaletteHelper();

        private void ToggleTheme()
        {
            ITheme theme = paletteHelper.GetTheme();
            if (IsDarkTheme = theme.GetBaseTheme() == BaseTheme.Dark)
            {
                IsDarkTheme = false;
                theme.SetBaseTheme(Theme.Light);
            }
            else
            {
                IsDarkTheme = true;
                theme.SetBaseTheme(Theme.Dark);
            }

            paletteHelper.SetTheme(theme);
        }


        public DelegateCommand ExitCommand { get; set; }


        private void Exit()
        {
            Application.Current.Shutdown();
        }

        public MainWindowViewModel()
        {
            ExitCommand = new DelegateCommand(Exit);
        }
    }
}
