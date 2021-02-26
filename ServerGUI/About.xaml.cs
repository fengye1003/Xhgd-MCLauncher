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

namespace XhgdMinecraft
{
    /// <summary>
    /// About.xaml 的交互逻辑
    /// </summary>
    public partial class About : Window
    {
        public About()
        {
            InitializeComponent();
        }

        private void menu(object sender, RoutedEventArgs e)
        {
            XhgdMinecraft.MenuPage sw = new XhgdMinecraft.MenuPage();
            sw.Show();
            this.Close();
        }
        private void ghublink(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/fengye1003/Xhgd-MCLauncher");
        }

        private void weblink(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://eachother.tech");
        }

        private void fbooklink(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.facebook.com/code.fengye");
        }

        private void qqlink(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://jq.qq.com/?_wv=1027&k=stOKb068");
        }
    }

}
