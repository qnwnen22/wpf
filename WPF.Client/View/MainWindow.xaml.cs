using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPF.Client.Properties;
using WPF.Client.ViewModel;

namespace WPF.Client.View
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : WindowBase
    {
        public MainWindow()
        {
            InitializeComponent();
            this.TitleBar.Window = this;
            this.DataContext = new MainViewModel();
        }
        private class MainConfigurationSettings : ConfigurableWindowSettings
        {
            const string IS_FIRST_RUN = "IsFirstRun";
            const string WINDOW_LOCATION = "WindowLocation";
            const string WINDOW_SIZE = "WindowSize";
            const string WINDOW_STATE = "WindowState";
            public MainConfigurationSettings(MainWindow window) : base(
                Settings.Default,
                IS_FIRST_RUN,
                WINDOW_LOCATION,
                WINDOW_SIZE,
                WINDOW_STATE
                )
            {
                window.Closed += delegate
                {
                    if (this.IsFirstRun)
                    {
                        this.IsFirstRun = false;
                    }
                };

            }
        }
        protected override IConfigurableWindowSettings CreateSettings()
        {
            return new MainConfigurationSettings(this);
        }
        private void ConfigurableWindow_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
