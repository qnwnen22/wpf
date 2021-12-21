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
using System.Windows.Shapes;
using WPF.Model;

namespace WPF.Client.View.Member
{
    /// <summary>
    /// MemberWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MemberWindow : Window
    {
        private IService iService;
        public MemberWindow(Model.IService iService)
        {
            InitializeComponent();
            this.iService = iService;
            this.TitleBar.Window = this;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
        }

        private void ButtonLogin_Click(object sender, RoutedEventArgs e)
        {
            var pass = this.Password.Password;
            var member = new Model.Member()
            {
                account = this.Account.Text,
                password = Password.Password,
            };
            iService.SignIn(member);
            var a = iService.Hello(this.Account.Text);
            MessageBox.Show(a);
        }
        private void LabelFindAccount_MouseLeave(object sender, MouseEventArgs e)
        {
            var convertFrom = new BrushConverter().ConvertFrom("#969497");
            this.LabelFindAccount.Foreground = (Brush)convertFrom;
        }

        private void LabelFindAccount_MouseMove(object sender, MouseEventArgs e)
        {
            this.LabelFindAccount.Foreground = Brushes.White;
        }

        private void LabelSignUp_MouseLeave(object sender, MouseEventArgs e)
        {
            var convertFrom = new BrushConverter().ConvertFrom("#969497");
            this.LabelSignUp.Foreground = (Brush)convertFrom;
        }

        private void LabelSignUp_MouseMove(object sender, MouseEventArgs e)
        {
            this.LabelSignUp.Foreground = Brushes.White;

        }
    }
}
