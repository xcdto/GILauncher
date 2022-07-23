using Loader;
using Loader.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Management;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Microsoft.Win32;

namespace GILoader
{
    public partial class MainForm : Form
    {
        [DllImport("wininet.dll")] //For mitmproxy
        public static extern bool InternetSetOption(IntPtr hInternet, int dwOption, IntPtr lpBuffer, int dwBufferLength);
        public const int INTERNET_OPTION_SETTINGS_CHANGED = 39;
        public const int INTERNET_OPTION_REFRESH = 37;
        static bool settingsReturn, refreshReturn;

        Loader.Config cfg = new Config(Application.StartupPath + "/config.ini"); //Підключаєм конфіг.

        public MainForm()
        {
            InitializeComponent();

            UpdaterConfig();
        }

        public bool grasscuterStarted;

        public Process publicgrassproc;

        public bool startedgenshin;

        public bool proxyok;

        public string lasthash = "somehash";

        private void btnLaunch_Click(object sender, EventArgs e)
        {
            //Запускаємо грасскуттер.
            StartGrasscutterServer();

            //Змінюємо переадресацію трафіку.
            StartChangeProxyorHost();

            //Запускаємо геншин.
            StartGenshin();
        }

        private async void UpdaterTimer_Tick(object sender, EventArgs e)
        {
            UpdaterConfig(); //Запускаємо чекер конфігу.

            //Чекер геншину.
            Process[] processesGen = Process.GetProcessesByName("GenshinImpact");
            Process[] processesYan = Process.GetProcessesByName("YuanShen");
            if (processesGen.Length > 0 || processesYan.Length > 0)
            {
                if (startedgenshin) { await Task.Delay(10000); }
                startedgenshin = false;
            }
        }

        async void UpdaterConfig() //Чекер конфігу по хешу.
        {
            await Task.Run(() => 
            {
                Task.Delay(1000);
                if (Md5Hash.CalculateMD5(cfg.path) != lasthash)
                {
                    Task.Delay(1000);
                    lasthash = Md5Hash.CalculateMD5(cfg.path);
                    startConfigRead();
                }
            });
        }

        void startConfigRead()
        {
            if (!File.Exists(Application.StartupPath + "/config.ini")) { File.WriteAllText(Application.StartupPath + "/config.ini", Loader.Properties.Resources.StandartConfig); } //Якщо конфігу нема.

            comboBox2.Items.Clear();
            comboBoxGenshin.Items.Clear();

            try
            {
                for (int i = 1; i <= Convert.ToInt32(cfg.Read("Settings", "genshinclients")); i++)
                {
                    comboBoxGenshin.Items.Add(cfg.Read($"Genshin{i}", "name"));
                }
            }
            catch { }

            try
            {
                for (int i = 1; i <= Convert.ToInt32(cfg.Read("Settings", "grasscuters")); i++)
                {
                    comboBox2.Items.Add(cfg.Read($"Grasscutter{i}", "name"));
                }
            }
            catch { }

            try
            {
                comboBoxGenshin.SelectedIndex = Convert.ToInt32(cfg.Read("Settings", "selectedgenshin"));
                comboBox2.SelectedIndex = Convert.ToInt32(cfg.Read("Settings", "selectedgrass"));
                textBox1.Text = cfg.Read("Settings", "ip");
                textBox2.Text = cfg.Read("Settings", "port");

                if (cfg.Read("Settings", "method") == "fiddler")
                    fdlcheck.Checked = true;
                else if (cfg.Read("Settings", "method") == "mitmproxy")
                    mitmcheck.Checked = true;
                else if (cfg.Read("Settings", "method") == "no")
                    nochange.Checked = true;
            }
            catch { }
        }

        async void StartGenshin() //Запускаємо геншин.
        {
            while (!startedgenshin)
            {
                await Task.Delay(100);
                if (lnchGC.Checked) //Якщо грасскутер.
                {
                    if (ConsoleOutputRichBox.Text.Contains("Done"))
                    {
                        if (proxyok)
                        {
                            Process.Start(cfg.Read($"Genshin{comboBoxGenshin.SelectedIndex + 1}", "patch"));
                            startedgenshin = true;
                        }
                    }

                    await Task.Delay(100);
                }
                else //Якщо ні.
                {
                    if (proxyok)
                    {
                        Process.Start(cfg.Read($"Genshin{comboBoxGenshin.SelectedIndex + 1}", "patch"));
                        startedgenshin = true;
                    }
                }
            }
        }

        async void StartGrasscutterServer()
        {
            try
            {
                if (publicgrassproc.Id > 0)
                {
                    MessageBox.Show("Grasscutter alredy started.");
                    return;
                }
            }
            catch (NullReferenceException) { } //Its normal.

            if (lnchGC.Checked) //Галка з грасскуттером чи ні.
            {
                string grasscutterfile = cfg.Read($"Grasscutter{comboBox2.SelectedIndex + 1}", "patch"); //Шлях отримаємо з конфігу.
                string grasspatch = Path.GetDirectoryName(grasscutterfile) + Path.DirectorySeparatorChar; //Треба дізнатися шлях папки, так как грасскутер думає що він запускаеться у каталозі Windows де знаходиться CMD.

                Process grassutterProcess = Process.Start(new ProcessStartInfo
                {
                    FileName = "cmd",
                    Arguments = "/c chcp 65001 & cd " + grasspatch + " & java -jar " + grasscutterfile, //Просто знайте що воно працює; chcp 65001 - це формат відображення; cd grasspatch - щоб грасскутер не думав що він ззапускається там де cmd; java -jar grasscutterfile тут все просто, запускається грасскуттер.
                    UseShellExecute = false, //Потрібна штука.
                    RedirectStandardOutput = true, //Редірект щоб отриувати якусь інформацію.
                    RedirectStandardError = true, //Рідерект щоб отримувати ерорс та обробляти їх (мені лінь їх обробляти, пускай юзер сам мислить)
                    CreateNoWindow = true
                });

                publicgrassproc = grassutterProcess; //Сетаємо навсякий, щоб потім можна буле детектити його.

    
                #if !DEBUG
                grassutterProcess.BeginOutputReadLine();
                grassutterProcess.BeginErrorReadLine();
                grassutterProcess.OutputDataReceived += (s, a) => { ConsoleOutputRichBox.Text += Environment.NewLine + a.Data; }; // Показуємо в label те що нам виводить консоль. 
                grassutterProcess.ErrorDataReceived += (s, a) => { ConsoleOutputRichBox.Text += Environment.NewLine + a.Data; }; // Можливо для дебагу це допоможе, ах.
                #elif DEBUG
                ConsoleOutputRichBox.Text += "In DEBUG mode output now workink :<";
                #endif
            }
        }

        void StartChangeProxyorHost()
        {
            if (fdlcheck.Checked) //Фіддлер чи ні.
            {
                string patchDoc = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                string patchFiddlerWhereSaveScript = Path.Combine(patchDoc + @"\Fiddler2\Scripts\CustomRules.js");

                if (File.Exists(patchFiddlerWhereSaveScript))
                {
                    //Ok скрипт є.
                    string fiddlerscrip = Resources.FiddlerScript.Replace("SCRPTIPREPLACER", textBox1.Text);
                    File.WriteAllText(patchFiddlerWhereSaveScript, fiddlerscrip); //Змінюємо айпи.

                    Process[] processes = Process.GetProcessesByName("Fiddler");
                    if (processes.Length > 0)
                    {
                        //ok, фіддлер вже працює.
                    }
                    else
                    {
                        Process.Start("Fiddler"); //Запускаємо фіддлер.
                    }

                    proxyok = true;
                }
            }
            else if (mitmcheck.Checked) //Через Хост чи ні.
            {
                //Через mitmproxy

                if (!File.Exists(Application.StartupPath + "/proxy.py")) //є прокси.пай? ні, создай.
                {
                    File.WriteAllText(Application.StartupPath + "/proxy.py", Loader.Properties.Resources.proxy_py);
                }

                File.WriteAllText(Application.StartupPath + "/proxy_config.py", Loader.Properties.Resources.config_proxy_py
                    .Replace("REPLACEHEREIP", textBox1.Text)
                    .Replace("REPLACEHEREPORT", textBox2.Text ?? "443"));

                CMD("taskkill /F /IM mitmproxy.exe"); //Вбиваємо його якщо з ним щось не так.

                Process.Start(new ProcessStartInfo
                {
                    FileName = "cmd",
                    Arguments = $"/c chcp 65001 & mitmproxy -s {Application.StartupPath + "/proxy.py"} -k",
                    UseShellExecute = false,
                    CreateNoWindow = true
                });

                //Встанавлюємо глобал проксі.
                RegistryKey registry = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Internet Settings", true);
                registry.SetValue("ProxyEnable", 1);
                registry.SetValue("ProxyServer", "localhost:8080");

                settingsReturn = InternetSetOption(IntPtr.Zero, INTERNET_OPTION_SETTINGS_CHANGED, IntPtr.Zero, 0);
                refreshReturn = InternetSetOption(IntPtr.Zero, INTERNET_OPTION_REFRESH, IntPtr.Zero, 0);

                ////Воно прцює якось лячно.
                ////Отримуємо потрібні данні.
                //string system = Environment.GetFolderPath(Environment.SpecialFolder.System);
                //string path = Path.GetPathRoot(system);
                //string host = path + @"Windows\System32\drivers\etc\hosts";
                //if (textBox1.Text == "localhost") { textBox1.Text = "127.0.0.1"; }
                //string siteip = Dns.GetHostAddresses(textBox1.Text).FirstOrDefault().ToString();

                //clearHost(); //Очищюємо хост від зайвого сміття залишиного нами.

                //File.AppendAllText(host, Environment.NewLine + "# Added by GILaucnher" +
                //        Environment.NewLine + $"{siteip} dispatchosglobal.yuanshen.com" +
                //        Environment.NewLine + $"{siteip} dispatchcnglobal.yuanshen.com" +
                //        Environment.NewLine + $"{siteip} osusadispatch.yuanshen.com" +
                //        Environment.NewLine + $"{siteip} oseurodispatch.yuanshen.com" +
                //        Environment.NewLine + $"{siteip} osasiadispatch.yuanshen.com" +

                //        Environment.NewLine + $"{siteip} hk4e-api-os-static.mihoyo.com" +
                //        Environment.NewLine + $"{siteip} hk4e-api-static.mihoyo.com" +
                //        Environment.NewLine + $"{siteip} hk4e-api-os.mihoyo.com" +
                //        Environment.NewLine + $"{siteip} hk4e-api.mihoyo.com" +
                //        Environment.NewLine + $"{siteip} hk4e-sdk-os.mihoyo.com" +
                //        Environment.NewLine + $"{siteip} hk4e-sdk.mihoyo.com" +

                //        Environment.NewLine + $"{siteip} account.mihoyo.com" +
                //        Environment.NewLine + $"{siteip} api-os-takumi.mihoyo.com" +
                //        Environment.NewLine + $"{siteip} api-takumi.mihoyo.com" +
                //        Environment.NewLine + $"{siteip} sdk-os-static.mihoyo.com" +
                //        Environment.NewLine + $"{siteip} sdk-static.mihoyo.com" +
                //        Environment.NewLine + $"{siteip} webstatic-sea.mihoyo.com" +
                //        Environment.NewLine + $"{siteip} webstatic.mihoyo.com" +
                //        Environment.NewLine + $"{siteip} uploadstatic-sea.mihoyo.com" +
                //        Environment.NewLine + $"{siteip} uploadstatic.mihoyo.com" +

                //        Environment.NewLine + $"{siteip} api-os-takumi.hoyoverse.com" +
                //        Environment.NewLine + $"{siteip} sdk-os-static.hoyoverse.com" +
                //        Environment.NewLine + $"{siteip} sdk-os.hoyoverse.com" +
                //        Environment.NewLine + $"{siteip} webstatic-sea.hoyoverse.com" +
                //        Environment.NewLine + $"{siteip} uploadstatic-sea.hoyoverse.com" +
                //        Environment.NewLine + $"{siteip} api-takumi.hoyoverse.com" +
                //        Environment.NewLine + $"{siteip} sdk-static.hoyoverse.com" +
                //        Environment.NewLine + $"{siteip} sdk.hoyoverse.com" +
                //        Environment.NewLine + $"{siteip} webstatic.hoyoverse.com" +
                //        Environment.NewLine + $"{siteip} uploadstatic.hoyoverse.com" +
                //        Environment.NewLine + $"{siteip} account.hoyoverse.com" +
                //        Environment.NewLine + $"{siteip} api-account-os.hoyoverse.com" +
                //        Environment.NewLine + $"{siteip} api-account.hoyoverse.com" +

                //        Environment.NewLine + $"{siteip} hk4e-api-os.hoyoverse.com" +
                //        Environment.NewLine + $"{siteip} hk4e-api-os-static.hoyoverse.com" +
                //        Environment.NewLine + $"{siteip} hk4e-sdk-os.hoyoverse.com" +
                //        Environment.NewLine + $"{siteip} hk4e-sdk-os-static.hoyoverse.com" +
                //        Environment.NewLine + $"{siteip} hk4e-api.hoyoverse.com" +
                //        Environment.NewLine + $"{siteip} hk4e-api-static.hoyoverse.com" +
                //        Environment.NewLine + $"{siteip} hk4e-sdk.hoyoverse.com" +
                //        Environment.NewLine + $"{siteip} hk4e-sdk-static.hoyoverse.com" +

                //        Environment.NewLine + $"{siteip} log-upload.mihoyo.com" +
                //        Environment.NewLine + $"{siteip} log-upload-os.mihoyo.com" +
                //        Environment.NewLine + $"{siteip} log-upload-os.hoyoverse.com" +
                //        Environment.NewLine + $"{siteip} devlog-upload.mihoyo.com" +
                //        Environment.NewLine + $"{siteip} overseauspider.yuanshen.com" +

                //        Environment.NewLine + $"{siteip} yuanshen.com" +
                //        Environment.NewLine + $"{siteip} hoyoverse.com" +
                //        Environment.NewLine + $"{siteip} mihoyo.com" +
                //        Environment.NewLine + $"{siteip} genshin.yuanshen.com" +
                //        Environment.NewLine + $"{siteip} genshin.hoyoverse.com" +
                //        Environment.NewLine + $"{siteip} genshin.mihoyo.com" +
                //        Environment.NewLine + $"# End GILauncher");

                proxyok = true;
            }
            else if (nochange.Checked) //Якщо нічого не вибрано.
            {
                proxyok = true;
            }
        }

        void clearHost()
        {
            //Отримуємо потрібні данні.
            string system = Environment.GetFolderPath(Environment.SpecialFolder.System);
            string path = Path.GetPathRoot(system);
            string host = path + @"Windows\System32\drivers\etc\hosts";

            //Видаляємо можливливий текст котрий ми залишали раніше.
            string contetnthost = File.ReadAllText(host);
            Match regx = Regex.Match(contetnthost, @"# Added by GILaucnher(.*?)# End GILauncher", RegexOptions.Singleline);
            string content = regx.Value;
            if (content != null && content != "")
            {
                string clearedhost = contetnthost.Replace(content, "");
                File.WriteAllText(host, clearedhost);
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e) //Коли програма зачинаяється.
        {
            //Зберінаємо налаштування.
            cfg.Write("Settings", "selectedgenshin", comboBoxGenshin.SelectedIndex.ToString()); //Вибраний геншин.
            cfg.Write("Settings", "selectedgrass", comboBox2.SelectedIndex.ToString()); //Вибраний геншин.
            cfg.Write("Settings", "ip", textBox1.Text); //Вибраний ip.
            cfg.Write("Settings", "port", textBox2.Text); //Вибраний port.
            if(fdlcheck.Checked)
                cfg.Write("Settings", "method", "fiddler");
            else if (mitmcheck.Checked)
                cfg.Write("Settings", "method", "mitmproxy");
            else if (nochange.Checked)
                cfg.Write("Settings", "method", "no");

            //Вбиваємо GenshinImpact YuanShen Fiddler Java mitmproxy.exe
            CMD("taskkill /F /IM GenshinImpact.exe &" +
                "taskkill /F /IM YuanShen.exe &" +
                 "taskkill /F /IM mitmproxy.exe &" +
                "taskkill /IM Fiddler.exe &" + //без /F бо якщо принуждаючи він проксі ламає.
                "taskkill /F /IM Java.exe");

            clearHost(); //Очищюємо хост від зайвого сміття залишиного нами.

            //Вимикаємо проксі.
            RegistryKey registry = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Internet Settings", true);
            registry.SetValue("ProxyEnable", 0);
        }

        private void btnAddClient_Click(object sender, EventArgs e) //Кнопка додавання геншину.
        {
            Form frmadd = new Loader.AddClient();
            frmadd.ShowDialog();
        }

        private void btnAddGrass_Click(object sender, EventArgs e) //Кнопка додавання гарсскутеру.
        {
            Form frmadd = new Loader.AddGrassJar();
            frmadd.ShowDialog();
        }

        private void GrassStopProc(object sender, EventArgs e) //Вбиваємо всі процесси джави. Можливо це не добра ідея, але гарантована.
        {
            CMD("taskkill /F /IM java.exe");
        }

        void CMD(string command) //Метод для запуску консолі з очікуванням виходу.
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = "cmd",
                Arguments = $"/c chcp 65001 & {command}",
                UseShellExecute = false, 
                CreateNoWindow = true
            }).WaitForExit();
        }
    }
}
