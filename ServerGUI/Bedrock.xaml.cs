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
    /// Bedrock.xaml 的交互逻辑
    /// </summary>
    public partial class Bedrock : Window
    {
        public Bedrock()
        {
            InitializeComponent();
        }
        public void DownloadFile(string URL, string filename)
        {
            try
            {
                System.Net.HttpWebRequest Myrq = (System.Net.HttpWebRequest)System.Net.HttpWebRequest.Create(URL);
                System.Net.HttpWebResponse myrp = (System.Net.HttpWebResponse)Myrq.GetResponse();
                long totalBytes = myrp.ContentLength;
                System.IO.Stream st = myrp.GetResponseStream();
                System.IO.Stream so = new System.IO.FileStream(filename, System.IO.FileMode.Create);
                long totalDownloadedByte = 0;
                byte[] by = new byte[1024];
                int osize = st.Read(by, 0, (int)by.Length);
                while (osize > 0)
                {
                    totalDownloadedByte = osize + totalDownloadedByte;
                    so.Write(by, 0, osize);
                    osize = st.Read(by, 0, (int)by.Length);
                }
                so.Close();
                st.Close();
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        private void dpkt(object sender, RoutedEventArgs e)
        {
            DownloadFile("https://each-1302182755.cos.ap-nanjing.myqcloud.com/MCUWP.Appx",".\\MCUWP.Appx");
            MessageBox.Show("即将开始下载安装包，期间可能出现程序未响应，请耐心等待。");
        }

        private void ist(object sender, RoutedEventArgs e)
        {
            string path = ".";
            if (Directory.Exists(path))
            {

                
                string filename = path + "\\" + "MCUWP.Appx";//一定要在路径和文件名之间加 \\
                if (File.Exists(filename))
                {
                    System.Diagnostics.Process.Start(".\\MCUWP.Appx");
                }
                else
                {
                    MessageBox.Show("未下载游戏，将为您下载游戏！");
                    MessageBox.Show("即将开始下载安装包，期间可能出现程序未响应，请耐心等待。");
                    DownloadFile("https://each-1302182755.cos.ap-nanjing.myqcloud.com/MCUWP.Appx", ".\\MCUWP.Appx");
                    System.Diagnostics.Process.Start(".\\MCUWP.Appx");

                }
            }
            else
            {
                MessageBox.Show("权限错误！");
                Directory.CreateDirectory(path);
            }

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
    }
}
