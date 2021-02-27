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
using System.IO;

namespace XhgdMinecraft
{
    /// <summary>
    /// uninstall.xaml 的交互逻辑
    /// </summary>
    public partial class uninstall : Window
    {
        public uninstall()
        {
            InitializeComponent();
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
        private void menu(object sender, RoutedEventArgs e)
        {
            XhgdMinecraft.MenuPage sw = new XhgdMinecraft.MenuPage();
            sw.Show();
            this.Close();
        }

        private void deljg(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("即将卸载本地游戏！请备份好文件！");
            System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(".\\.minecraft\\");
            di.Delete(true);
            File.Delete(".\\rapo.rar");
        }

        private void delbe(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("即将删除本地基岩版安装包。");
            File.Delete(".\\MCUWP.Appx");
        }

        private void uncore(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("即将卸载运行库与核心JRE！这可能让游戏脚本无法运行。");
            System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(".\\jre\\");
            di.Delete(true);
            File.Delete(".\\unrar.exe");
        }
    }
}
