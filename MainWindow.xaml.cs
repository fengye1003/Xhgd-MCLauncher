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
using System.IO;


namespace ServerGUI
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        
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
        private string ExeCommand(string commandText)
        {
            System.Diagnostics.Process p = new System.Diagnostics.Process();  //创建并实例化一个操作进程的类：Process
            p.StartInfo.FileName = "cmd.exe";    //设置要启动的应用程序
            p.StartInfo.UseShellExecute = false;   //设置是否使用操作系统shell启动进程
            p.StartInfo.RedirectStandardInput = true;  //指示应用程序是否从StandardInput流中读取
            p.StartInfo.RedirectStandardOutput = true; //将应用程序的输入写入到StandardOutput流中
            p.StartInfo.RedirectStandardError = true;  //将应用程序的错误输出写入到StandarError流中
            p.StartInfo.CreateNoWindow = true;    //是否在新窗口中启动进程
            string strOutput = null;
            try
            {
                p.Start();
                p.StandardInput.WriteLine(commandText);    //将CMD命令写入StandardInput流中
                p.StandardInput.WriteLine("exit");         //将 exit 命令写入StandardInput流中
                strOutput = p.StandardOutput.ReadToEnd();   //读取所有输出的流的所有字符
                p.WaitForExit();                           //无限期等待，直至进程退出
                p.Close();                                  //释放进程，关闭进程
            }
            catch (Exception e)
            {
                strOutput = e.Message;
            }
            return strOutput;
        }
        public MainWindow()
        {
            InitializeComponent();
        }
        
        private void getupdate(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("即将清空本地目录！请备份好文件！");
            System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(".\\.minecraft\\");
            di.Delete(true);
            System.IO.DirectoryInfo di2 = new System.IO.DirectoryInfo(".\\jre\\");
            di2.Delete(true);
            File.Delete(".\\rapo.rar");
            install();
        }
        private void install()
        {
            XhgdMinecraft.Window1 sw = new XhgdMinecraft.Window1();
            sw.Show();

        }
        private void rungames(object sender, RoutedEventArgs e)
        {
            string path = ".";
            if (Directory.Exists(path))
            {

                
                string filename = path + "\\" + "jre\\bin\\java.exe";//一定要在路径和文件名之间加 \\
                if (File.Exists(filename))
                {
                    DownloadFile("https://each-1302182755.cos.ap-nanjing.myqcloud.com/servers.dat", ".\\.minecraft\\servers.dat");
                    MessageBox.Show("服务器列表获取完成！");
                    string runshell = ".";
                    if (System.IO.Directory.Exists(runshell))
                    {
                        string runname = runshell + "\\" + "run.cmd";//一定要在路径和文件名之间加 \\
                        if (System.IO.File.Exists(runname))
                        {
                            //检查完成，接下来获取启动脚本
                            string str = System.Environment.CurrentDirectory;
                            System.IO.File.Copy(".\\rungame.bat", ".\\run.cmd", true);
                            //将原始文件拷贝到游戏目录
                            StreamReader reader2 = new StreamReader(@".\\run.cmd", Encoding.Default);
                            String b = reader2.ReadToEnd();
                            //将文件中玩家名称替换为设定项目。
                            b = b.Replace(@"C:\XhgdMinecraft", str);
                            //run.cmd重命名为b.hhp
                            //防止文本字符中有特殊字符。必须用Encoding.Default
                            StreamWriter readTxt2 = new StreamWriter(@"b.hhp", false, Encoding.Default);
                            readTxt2.Write(b);
                            readTxt2.Flush();
                            readTxt2.Close();
                            reader2.Close();
                            //b.hhp重命名为run.cmd,并删除b.hhp
                            File.Copy(@"b.hhp", @".\\run.cmd", true);
                            File.Delete(@"b.hhp");
                            //玩家名称设定完成
                            MessageBox.Show("保存成功！");
                            System.Diagnostics.Process.Start(@".\\startup1.vbs");
                            MessageBox.Show("一切准备就绪！游戏将在3分钟内启动。");
                            this.Close();
                        }
                        else
                        {
                            DownloadFile("https://each-1302182755.cos.ap-nanjing.myqcloud.com/run.cmd", ".\\run.cmd");
                            MessageBox.Show("您没有设置您的用户名！请修改用户名。");
                        }
                    }
                    else
                    {
                        MessageBox.Show("监测到您是首次运行启动器，正在为您加载文件");
                        System.IO.Directory.CreateDirectory(runshell);//创建路径
                    }
                }
                else
                {
                    MessageBox.Show("游戏未安装！！！");
                    install();
                }
            }
            else
            {
                MessageBox.Show("游戏未安装！！！");
                install();
            }

        }

        private void save(object sender, RoutedEventArgs e)
        {
            string path = ".";
            if (Directory.Exists(path))
            {


                string filename = path + "\\" + "run.cmd";//一定要在路径和文件名之间加 \\
                if (File.Exists(filename))
                {
                    System.IO.File.Copy(".\\rungame.bat", ".\\run.cmd", true);
                    //将原始文件拷贝到游戏目录
                    StreamReader reader2 = new StreamReader(@".\\run.cmd", Encoding.Default);
                    String b = reader2.ReadToEnd();
                    //将文件中玩家名称替换为设定项目。
                    b = b.Replace("玩家名称", name1.Text);
                    //run.cmd重命名为b.hhp
                    //防止文本字符中有特殊字符。必须用Encoding.Default
                    StreamWriter readTxt2 = new StreamWriter(@"b.hhp", false, Encoding.Default);
                    readTxt2.Write(b);
                    readTxt2.Flush();
                    readTxt2.Close();
                    reader2.Close();
                    //b.hhp重命名为run.cmd,并删除b.hhp
                    File.Copy(@"b.hhp", @".\\run.cmd", true);
                    File.Delete(@"b.hhp");
                    //玩家名称设定完成
                    MessageBox.Show("保存成功！");

                }
                else
                {
                    MessageBox.Show("游戏未安装！！！");
                    install();
                }
            }
            else
            {
                MessageBox.Show("游戏未安装！！！");
                install();
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
    }
}
