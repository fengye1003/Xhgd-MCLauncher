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
using System.Net;
using System.IO;
using System.Threading;
using System.Drawing;


namespace XhgdMinecraft
{
    /// <summary>
    /// Window1.xaml 的交互逻辑
    /// </summary>
    public partial class Window1 : Window
    {
        public delegate void ProgressBarSetter(double value);
        public void SetProgressBar(double value)
        {
            pbDown.Value = value;
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
                
                byte[] by = new byte[1024];
                
                int realReadLen = st.Read(by, 0, by.Length);
                long progressBarValue = 0;
                while (realReadLen > 0)
                {
                    so.Write(by, 0, realReadLen);
                    progressBarValue += realReadLen;
                    pbDown.Dispatcher.BeginInvoke(new ProgressBarSetter(SetProgressBar), progressBarValue);
                    realReadLen = st.Read(by, 0, by.Length);
                }
                so.Close();
                st.Close();
            }
            catch (System.Exception)
            {
                throw;
            }
        }
        private void install()
        {
            string path = ".";
            if (System.IO.Directory.Exists(path))
            {
                string filename = path + "\\" + "unrar.exe";//一定要在路径和文件名之间加 \\
                if (System.IO.File.Exists(filename))
                {
                    //检查完成，接下来检测游戏是否存在
                    string game = ".";
                    if (System.IO.Directory.Exists(game))
                    {
                        string gamename = game + "\\" + "rapo.rar";//一定要在路径和文件名之间加 \\
                        if (System.IO.File.Exists(gamename))
                        {
                            //检查完成，接下来获取启动脚本
                        }
                        else
                        {
                            MessageBox.Show("您的电脑尚未安装游戏，点击“确认”后开始下载。可能出现“未响应，”，请耐心等待，游戏大小1GB左右，安装过程中请勿关闭窗口。安装完成后将会弹出“安装完成”对话框。");
                            stadu.Text = "正在下载游戏资源，可能出现程序未响应，请勿关闭窗口";
                            DownloadFile("https://each-1302182755.cos.ap-nanjing.myqcloud.com/rapo.rar", ".\\rapo.rar");//从cdn下载rapo.rar游戏本体
                            
                            DownloadFile("https://each-1302182755.cos.ap-nanjing.myqcloud.com/install.bat", ".\\install.bat");//从cdn下载游戏引导文件
                           

                            System.Diagnostics.Process.Start(@".\\install.bat");
                            MessageBox.Show("恭喜！游戏安装成功！");
                        }
                    }
                    else
                    {
                        MessageBox.Show("监测到您是首次运行启动器，正在为您加载文件");
                        System.IO.Directory.CreateDirectory(path);//创建路径
                        MessageBox.Show("您的电脑尚未安装游戏，点击“确认”后开始下载。游戏大小1GB左右，可能出现“未响应，”，请耐心等待，安装过程中请勿关闭窗口。安装完成后将会弹出“安装完成”对话框。");
                        stadu.Text = "正在下载游戏资源，可能出现程序未响应，请勿关闭窗口";
                        DownloadFile("https://each-1302182755.cos.ap-nanjing.myqcloud.com/rapo.rar", ".\\rapo.rar");//从cdn下载rapo.rar游戏本体
                        
                        DownloadFile("https://each-1302182755.cos.ap-nanjing.myqcloud.com/install.bat", ".\\install.bat");//从cdn下载游戏引导文件
                        System.Diagnostics.Process.Start(@".\\install.bat");
                        MessageBox.Show("恭喜！游戏安装成功！");
                    }
                }
                else
                {
                    MessageBox.Show("您的电脑尚未安装游戏运行库，请以管理员身份进行安装。");
                    DownloadFile("https://each-1302182755.cos.ap-nanjing.myqcloud.com/unrar.exe", ".\\unrar.exe");//从cdn下载unrar.exe，用于解压游戏安装包
                    
                    MessageBox.Show("您的电脑尚未安装游戏，点击“确认”后开始下载。游戏大小1GB左右，安装过程中请勿关闭窗口。可能出现“未响应，”，请耐心等待，安装完成后将会弹出“安装完成”对话框。");
                    stadu.Text = "正在下载游戏资源，可能出现程序未响应，请勿关闭窗口";
                    DownloadFile("https://each-1302182755.cos.ap-nanjing.myqcloud.com/rapo.rar", ".\\rapo.rar");//从cdn下载rapo.rar游戏本体
                    DownloadFile("https://each-1302182755.cos.ap-nanjing.myqcloud.com/install.bat", ".\\install.bat");//从cdn下载游戏引导文件
                    System.Diagnostics.Process.Start(@".\\install.bat");
                    MessageBox.Show("恭喜！游戏安装成功！");
                }
            }
            else
            {
                MessageBox.Show("监测到您是首次运行启动器，正在为您加载文件");
                System.IO.Directory.CreateDirectory(path);//创建路径
                MessageBox.Show("您的电脑尚未安装游戏运行库，请以管理员身份进行安装。");
                DownloadFile("https://each-1302182755.cos.ap-nanjing.myqcloud.com/unrar.exe", ".\\unrar.exe");//从cdn下载unrar.exe，用于解压游戏安装包

                MessageBox.Show("您的电脑尚未安装游戏，点击“确认”后开始下载。游戏大小1GB左右，可能出现“未响应，”，请耐心等待，安装过程中请勿关闭窗口。安装完成后将会弹出“安装完成”对话框。");
                stadu.Text = "正在下载游戏资源，可能出现程序未响应，请勿关闭窗口";
                DownloadFile("https://each-1302182755.cos.ap-nanjing.myqcloud.com/rapo.rar", ".\\rapo.rar");//从cdn下载rapo.rar游戏本体
                DownloadFile("https://each-1302182755.cos.ap-nanjing.myqcloud.com/install.bat", ".\\install.bat");//从cdn下载游戏引导文件
                MessageBox.Show("接下来将调用命令行解压游戏资源。此过程不消耗流量，在显示“按任意键继续”之前请不要关闭弹出的命令窗口");
                System.Diagnostics.Process.Start(@".\\install.bat");
                MessageBox.Show("恭喜！游戏安装成功！");
            }//本地游戏补全完毕
            MessageBox.Show("检测到本地游戏.\\.mineccraft\\");
        }
        public Window1()
        {
            InitializeComponent();
        }

        private void startinstall(object sender, RoutedEventArgs e)
        {
            start.IsEnabled=false;
            install();
            this.Close();
        }

        private void cancal(object sender, RoutedEventArgs e)
        {
            File.Delete(".\\rapo.rar");
        }
    }
}
