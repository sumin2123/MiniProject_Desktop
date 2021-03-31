using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
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
using WpfSMSApp.View;
using WpfSMSApp.View.User;

namespace WpfSMSApp
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MetroWindow_ContentRendered(object sender, EventArgs e)
        {
            ShowLoginView();
        }

        private void MetroWindow_Activated(object sender, EventArgs e)
        {
            if (Commons.LOGINED_USER != null)
                BtnLoginedId.Content = $"{ Commons.LOGINED_USER.UserEmail} ({ Commons.LOGINED_USER.UserName})";
        }

        private async void BtnLogOut_Click(object sender, RoutedEventArgs e)
        {
            //TODO : 모든 화면을 해제하고 첫 화면으로 돌려놓아야 한다.
            var result = await this.ShowMessageAsync("로그아웃", "로그아웃하시겠습니까?",
                MessageDialogStyle.AffirmativeAndNegative,null);

            if (result == MessageDialogResult.Affirmative)
            {
                Commons.LOGINED_USER = null;//로그인했던 사용자 정보를 삭제
                ShowLoginView();
            }
        }
    
        private void ShowLoginView()
        {
            LoginView view = new LoginView();
            view.Owner = this;
            view.ShowDialog();
            view.WindowStartupLocation = WindowStartupLocation.CenterOwner;
        }

        private void BtnAccount_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ActiveControl.Content = new Account.MyAccountView();//이거 아닌데? MyAccount에서 시스템 자원 새로 할당하는 건데? 뭐지? // 답은 내가 View의 Account에서 생성하지 않고 프로젝트 영역에 cs를 생성해서 그렇다.
                //사소한 실수가 네임스페이스를 다 꼬이게 만들 수 있어..
            }
            catch (Exception ex)
            {
                Commons.LOGGER.Error($"예외발생 BtnAccount_Click : {ex}");
            }
        }

        private async void BtnUser_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ActiveControl.Content = new UserList();
            }
            catch (Exception ex)
            {
                Commons.LOGGER.Error($"예외발생 BtnAccount_Click : {ex}");
                await this.ShowMessageAsync("예외", $"예외발생 : {ex}");
            }
        }
    }
}
