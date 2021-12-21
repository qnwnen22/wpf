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

namespace WPF.Client.UserControls
{
    /// <summary>
    /// TitleBar.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class TitleBar : UserControl
    {
        public TitleBar()
        {
            InitializeComponent();
        }
        public Window Window { get; set; }
        public bool UserMax
        {
            set
            {
                if (value)
                {
                    this.BtnMax.Visibility = Visibility.Visible;
                }
                else
                {
                    this.BtnMax.Visibility = Visibility.Hidden;
                }
            }
        }
        public bool UserMin
        {
            set
            {
                if (value)
                {
                    this.BtnMin.Visibility = Visibility.Visible;
                }
                else
                {
                    this.BtnMin.Visibility = Visibility.Hidden;
                }
            }
        }
        private void UserControl_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }
        private void ConfigurableWindow_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.Window.DragMove();
        }
        private void BtnMin_Click(object sender, RoutedEventArgs e)
        {
            this.Window.WindowState = WindowState.Minimized;
        }

        private void BtnMax_Click(object sender, RoutedEventArgs e)
        {
            if (this.Window.WindowState == WindowState.Maximized)
            {
                this.Window.WindowState = WindowState.Normal;
            }
            else
            {
                this.Window.WindowState = WindowState.Maximized;
            }
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBoxResult = MessageBox.Show("프로그램을 종료하시겠습니까?", "", MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                this.Window.Close();
            }
        }
    }

}
