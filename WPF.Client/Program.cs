using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using WPF.Model;

namespace WPF.Client
{
    class Program
    {
        [STAThread]
        public static void Main(string[] arg)
        {
            System.Windows.Application.LoadComponent(new Uri("/WPF.Client;component/app.xaml", UriKind.Relative));
            System.Windows.Application.Current.ShutdownMode = System.Windows.ShutdownMode.OnExplicitShutdown;
            var channelFactory = new ChannelFactory<IService>();
            channelFactory.Endpoint.Address = new EndpointAddress("net.tcp://localhost:8080/WPF");
            channelFactory.Endpoint.Binding = new CustomNetTcpBinding().GetNetTcpBinding();
            channelFactory.Endpoint.Contract.ContractType = typeof(IService);
            IService iService = channelFactory.CreateChannel();

            while (true)
            {
                var memberWindow = new View.Member.MemberWindow(iService);
                bool? isLogin = memberWindow.ShowDialog();
                if (isLogin == true)
                {
                    var mainWindow = new View.MainWindow();
                    var mainShowDialog = mainWindow.ShowDialog();
                    if (mainShowDialog != true) { break; }
                }
                else
                {
                    break;
                }
            }
        }
    }
}
