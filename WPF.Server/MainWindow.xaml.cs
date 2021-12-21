using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
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
using WPF.Model;

namespace WPF.Server
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Field & Property
        private ServiceHost serviceHost;
        const string addres = "net.tcp://localhost:8080/WPF";
        private string Now
        {
            get
            {
                return DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            }
        }

        #endregion
        public MainWindow()
        {
            InitializeComponent();
        }
        private void ServiceHostSettong()
        {
            serviceHost = new ServiceHost(typeof(Service));
            var customNetTcpBinding = new CustomNetTcpBinding().GetNetTcpBinding();
            serviceHost.AddServiceEndpoint(typeof(IService), customNetTcpBinding, addres);
            TextBoxLog.Text += $"[{Now}] 서버 시작\n";
        }

        #region Event
        private void BtnOpen_Click(object sender, RoutedEventArgs e)
        {
            ServiceHostSettong();
            this.BtnOpen.IsEnabled = false;
            this.BtnClose.IsEnabled = true;
            serviceHost.Open();
        }
        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            this.BtnClose.IsEnabled = false;
            this.BtnOpen.IsEnabled = true;
            serviceHost.Close();
            TextBoxLog.Text += $"[{Now}] 서버 종료\n";

        }
        #endregion

    }
}
