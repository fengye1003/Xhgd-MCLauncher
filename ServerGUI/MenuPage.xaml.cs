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
    /// MenuPage.xaml 的交互逻辑
    /// </summary>
    public partial class MenuPage : Window
    {
        public MenuPage()
        {
            InitializeComponent();
        }

        private void java(object sender, RoutedEventArgs e)
        {
            ServerGUI.MainWindow sw = new ServerGUI.MainWindow();
            sw.Show();
            this.Close();
        }

        private void bedrock(object sender, RoutedEventArgs e)
        {
            XhgdMinecraft.Bedrock sw = new Bedrock ();
            sw.Show();
            this.Close();

        }

        private void aboutpage(object sender, RoutedEventArgs e)
        {
            XhgdMinecraft.About sw = new XhgdMinecraft.About();
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
