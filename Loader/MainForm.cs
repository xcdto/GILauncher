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
using System.Drawing.Drawing2D;
using System.Globalization;

namespace GILoader
{
    public partial  class MainForm : Form
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

            startConfigRead();
            UpdaterConfig();

            //Робимо форму за розмірами экрану.
            var widhscren = Screen.PrimaryScreen.Bounds.Width;
            var heightscren = Screen.PrimaryScreen.Bounds.Height;
            this.Width = widhscren - 600; //Чому саме 600 та 300, не знаю але виглядить не погано.
            this.Height = heightscren - 300;

        }

        private async void MainForm_Load(object sender, EventArgs e)
        {
            int i;
            for (i = 0; i < 16; i++)
            {
                await Task.Delay(100);
                if (i == 15)
                {
                   while (Opacity != 1) { Opacity += .1; await Task.Delay(10); }
                }
            }
        }

        public bool grasscuterStarted;

        public Process publicgrassproc;

        public bool startedgenshin;

        public bool proxyok;

        public string lasthash = "somehash";

        string grasscutteroutput = "sometext";

        private void btnLaunch_Click(object sender, EventArgs e)
        {
            //PatchMetadata
            if (!patchmetadata()) { return; }

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

            grassBox.Items.Clear();
            genshinBox.Items.Clear();

            try
            {
                for (int i = 1; i <= Convert.ToInt32(cfg.Read("Settings", "genshinclients")); i++)
                {
                    genshinBox.Items.Add(cfg.Read($"Genshin{i}", "name"));
                }
            }
            catch { }

            try
            {
                for (int i = 1; i <= Convert.ToInt32(cfg.Read("Settings", "grasscuters")); i++)
                {
                    grassBox.Items.Add(cfg.Read($"Grasscutter{i}", "name"));
                }
            }
            catch { }

            try
            {
                genshinBox.SelectedIndex = Convert.ToInt32(cfg.Read("Settings", "selectedgenshin"));
                grassBox.SelectedIndex = Convert.ToInt32(cfg.Read("Settings", "selectedgrass"));
                ipTextBox.Text = cfg.Read("Settings", "ip");
                textboxPort.Text = cfg.Read("Settings", "port");

                laucnGrassBox.Checked = Convert.ToBoolean(cfg.Read("Settings", "grassbox")); //Вибран грасс.
                patcherMetatdaBox.Checked = Convert.ToBoolean(cfg.Read("Settings", "patcher")); //Пачер.

                if (cfg.Read("Settings", "method") == "fiddler")
                    fiddlerBox.Checked = true;
                else if (cfg.Read("Settings", "method") == "mitmproxy")
                    mitmproxyBox.Checked = true;
                else if (cfg.Read("Settings", "method") == "no")
                   concviaproxyBox.Checked = false;

                if (cfg.Read("Settings", "proxy") == "true")
                    concviaproxyBox.Checked = true;

            }
            catch { }

            try
            {
                picturePoxBack.Load(cfg.Read("Settings", "backimg"));
            }
            catch { }
        }

        bool patchmetadata()
        {
            string patchgenshin = Path.GetDirectoryName(cfg.Read($"Genshin{genshinBox.SelectedIndex + 1}", "patch"));
            string isitgenshindata = "GenshinImpact_Data"; //Чекер чайна це чи глобал.
            if (Directory.Exists(patchgenshin + "/YuanShen_Data")) { isitgenshindata = "YuanShen_Data"; }
            else if (Directory.Exists(patchgenshin + "/GenshinImpact_Data")) { isitgenshindata = "GenshinImpact_Data"; }

            startagain:

            //Якщо не патчимо то:
            if (!patcherMetatdaBox.Checked) //Навсяк ставимо оріганал якщо моливо.
            {
                try
                {
                    if (File.Exists(patchgenshin + $"/{isitgenshindata}/Managed/Metadata/global-metadata-original.dat"))
                    {
                        File.Delete(patchgenshin + $"/{isitgenshindata}/Managed/Metadata/global-metadata.dat");
                        File.Copy(patchgenshin + $"/{isitgenshindata}/Managed/Metadata/global-metadata-original.dat", patchgenshin + $"/{isitgenshindata}/Managed/Metadata/global-metadata.dat");
                    }

                    if (File.Exists(patchgenshin + $"/{isitgenshindata}/Native/Data/Metadata/global-metadata-original.dat"))
                    {
                        File.Delete(patchgenshin + $"/{isitgenshindata}/Native/Data/Metadata/global-metadata.dat");
                        File.Copy(patchgenshin + $"/{isitgenshindata}/Native/Data/Metadata/global-metadata-original.dat", patchgenshin + $"/{isitgenshindata}/Native/Data/Metadata/global-metadata.dat");
                    }
                }
                catch { }

                return true;
            }


            if (File.Exists(patchgenshin + $"/{isitgenshindata}/Managed/Metadata/global-metadata-patched.dat"))
            {
                //Добре, файл є.
                //Тепер ми робимо резерну копію орігіналу.
                if (!File.Exists(patchgenshin + $"/{isitgenshindata}/Managed/Metadata/global-metadata-original.dat"))
                    File.Copy(patchgenshin + $"/{isitgenshindata}/Managed/Metadata/global-metadata.dat", patchgenshin + $"/{isitgenshindata}/Managed/Metadata/global-metadata-original.dat");

                //Потім просто заміняємо файл.
                File.Delete(patchgenshin + $"/{isitgenshindata}/Managed/Metadata/global-metadata.dat");
                File.Copy(patchgenshin + $"/{isitgenshindata}/Managed/Metadata/global-metadata-patched.dat", patchgenshin + $"/{isitgenshindata}/Managed/Metadata/global-metadata.dat");
            }
            else
            {
                goto patcher;
            }

            if (File.Exists(patchgenshin + $"/{isitgenshindata}/Native/Data/Metadata/global-metadata-patched.dat"))
            {
                //Добре, файл є.
                //Тепер ми робимо резерну копію орігіналу.
                if (!File.Exists(patchgenshin + $"/{isitgenshindata}/Native/Data/Metadata/global-metadata-original.dat"))
                    File.Copy(patchgenshin + $"/{isitgenshindata}/Native/Data/Metadata/global-metadata.dat", patchgenshin + $"/{isitgenshindata}/Native/Data/Metadata/global-metadata-original.dat");

                //Потім просто заміняємо файл.
                File.Delete(patchgenshin + $"/{isitgenshindata}/Native/Data/Metadata/global-metadata.dat");
                File.Copy(patchgenshin + $"/{isitgenshindata}/Native/Data/Metadata/global-metadata-patched.dat", patchgenshin + $"/{isitgenshindata}/Native/Data/Metadata/global-metadata.dat");
            }
            else
            {
                goto patcher;
            }

            return true;

            //PatchMetaData
            //Нажаль в мене не вийшло, чомусь розмір файлів не збігається коли робиш реплейс. Чомусь тут навіть не працює .Replace, чому так я не знаю. 
            //Також не можна сразу переводити у стрінг. Або читати файл текстом File.ReadAllText, бо тоды також розмір не збігається.
            patcher:
            if (File.Exists("global-metadata-patched.dat"))
            {
                File.Delete(patchgenshin + $"/{isitgenshindata}/Managed/Metadata/global-metadata-patched.dat");
                File.Copy("global-metadata-patched.dat", patchgenshin + $"/{isitgenshindata}/Managed/Metadata/global-metadata-patched.dat");
                File.Delete(patchgenshin + $"/{isitgenshindata}/Native/Data/Metadata/global-metadata-patched.dat");
                File.Copy("global-metadata-patched.dat", patchgenshin + $"/{isitgenshindata}/Native/Data/Metadata/global-metadata-patched.dat");

                goto startagain;
            }

            Process.Start("https://github.com/Hacker-TA/GILauncher/tree/main/Files/Metadata/");
            MessageBox.Show($"Could not find global-metadata-patched.dat file in program root folder.\nYou can try to find it for your version on our github or on the Internet.");
            return false;


            //try
            //{
            //    //Создаємо файл с ресурсів.
            //    if (!File.Exists(Application.StartupPath + "/metadata-extractor.exe")) { File.WriteAllBytes(Application.StartupPath + "/metadata-extractor.exe", Loader.Properties.Resources.metadata_extractor); }

            //    //Managed metadata \
            //    Process.Start(Application.StartupPath + "/metadata-extractor.exe", $"-i \"{patchgenshin + $"/{isitgenshindata}/Managed/Metadata/global-metadata.dat"}\" -o outputManaged.bin --decrypt").WaitForExit();
            //    var resultdecrypt = File.ReadAllBytes("outputManaged.bin");

            //    string pattern = @"<RSAKeyValue>((.|\n|\r)*?)</RSAKeyValue>";
            //    string input = System.Text.Encoding.ASCII.GetString(resultdecrypt);
            //    RegexOptions options = RegexOptions.Multiline | RegexOptions.RightToLeft;

            //    Regex reg = new Regex(pattern, options);
            //    MatchCollection match = reg.Matches(input);

            //    //for (int i = 0; i < match.Count; i++)
            //    //{
            //    //    string key = match[i].Value;
            //    //    Clipboard.SetText(match[i].Value);
            //    //    MessageBox.Show($"ID: {i}\n" +
            //    //        $"IsCountKey: {match[i].Value.Length}\n" +
            //    //        $"ExistsKeyCountDispatchLengt: {Resources.dispatcherKey.Length}\n" +
            //    //        $"ExisstKeyPasswordLengt{Resources.passwordKey.Length}\nRsaKeyWhatsFound: {match[i].Value}");
            //    //}

            //    string hexinput = BitConverter.ToString(resultdecrypt).Replace("-", " ");

            //    string hexDispatcher = BitConverter.ToString(Encoding.ASCII.GetBytes(match[3].Value)).Replace("-", " ");
            //    string hexpPass = BitConverter.ToString(Encoding.ASCII.GetBytes(match[4].Value));

            //    string hexKeyDis = BitConverter.ToString(Encoding.ASCII.GetBytes(Loader.Properties.Resources.dispatcherKey)).Replace("-", " ");
            //    string hexKeyPass = BitConverter.ToString(Encoding.ASCII.GetBytes(Loader.Properties.Resources.passwordKey)).Replace("-", " ");

            //    Clipboard.SetText(hexDispatcher); MessageBox.Show(hexDispatcher);
            //    Clipboard.SetText(hexKeyDis); MessageBox.Show(hexKeyDis);

            //    //File.WriteAllText("put.txt", hexinput);

            //    hexinput.Replace(hexDispatcher, hexKeyDis);
            //    hexinput.Replace(hexpPass, hexKeyPass);

            //    byte[] replceskey = Convert.FromBase64String(hexinput);

            //    //File.WriteAllText("ppput.txt", BitConverter.ToString(replceskey).Replace("-", " "));

            //    File.WriteAllBytes("input.bin", replceskey);
            //    File.Delete("global-metadata-patched.dat");

            //    Process.Start(Application.StartupPath + "/metadata-extractor.exe", $"-i input.bin -o global-metadata-patched.dat --encrypt").WaitForExit();

            //    File.Delete(patchgenshin + $"/{isitgenshindata}/Managed/Metadata/global-metadata-patched.dat");
            //    File.Copy("global-metadata-patched.dat", patchgenshin + $"/{isitgenshindata}/Managed/Metadata/global-metadata-patched.dat");


            //    File.Delete(patchgenshin + $"/{isitgenshindata}/Native/Data/Metadata/global-metadata-patched.dat");
            //    File.Copy("global-metadata-patched.dat", patchgenshin + $"/{isitgenshindata}/Native/Data/Metadata/global-metadata-patched.dat");

            //    goto startagain;
            //}
            //catch (Exception e) { MessageBox.Show(e.ToString()); return false; }
        }

        async void StartGenshin() //Запускаємо геншин.
        {
            while (!startedgenshin)
            {
                await Task.Delay(100);
                if (laucnGrassBox.Checked) //Якщо грасскутер.
                {
                    if (grasscutteroutput.Contains("Done"))
                    {
                        if (proxyok)
                        {
                            Process.Start(cfg.Read($"Genshin{genshinBox.SelectedIndex + 1}", "patch"));
                            startedgenshin = true;
                        }
                    }

                    await Task.Delay(100);
                }
                else //Якщо ні.
                {
                    if (proxyok)
                    {
                        Process.Start(cfg.Read($"Genshin{genshinBox.SelectedIndex + 1}", "patch"));
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

            if (laucnGrassBox.Checked) //Галка з грасскуттером чи ні.
            {
                string grasscutterfile = cfg.Read($"Grasscutter{grassBox.SelectedIndex + 1}", "patch"); //Шлях отримаємо з конфігу.
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
                grassutterProcess.OutputDataReceived += (s, a) => { grasscutteroutput += Environment.NewLine + a.Data; }; // Показуємо в label те що нам виводить консоль. 
                grassutterProcess.ErrorDataReceived += (s, a) => { grasscutteroutput += Environment.NewLine + a.Data; }; // Можливо для дебагу це допоможе, ах.
                #elif DEBUG
                grasscutteroutput += "In DEBUG mode output now workink :<";
                #endif
            }
        }

        void StartChangeProxyorHost()
        {
            if (!concviaproxyBox.Checked) //Якщо нічого не вибрано.
            {
                proxyok = true;
                return;
            }

            if (fiddlerBox.Checked) //Фіддлер чи ні.
            {
                string patchDoc = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                string patchFiddlerWhereSaveScript = Path.Combine(patchDoc + @"\Fiddler2\Scripts\CustomRules.js");

                if (File.Exists(patchFiddlerWhereSaveScript))
                {
                    //Ok скрипт є.
                    string fiddlerscrip = Resources.FiddlerScript.Replace("SCRPTIPREPLACER", ipTextBox.Text);
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
            else if (mitmproxyBox.Checked) //Через Хост чи ні.
            {
                //Через mitmproxy

                if (!File.Exists(Application.StartupPath + "/proxy.py")) //є прокси.пай? ні, создай.
                {
                    File.WriteAllText(Application.StartupPath + "/proxy.py", Loader.Properties.Resources.proxy_py);
                }

                File.WriteAllText(Application.StartupPath + "/proxy_config.py", Loader.Properties.Resources.config_proxy_py
                    .Replace("REPLACEHEREIP", ipTextBox.Text)
                    .Replace("REPLACEHEREPORT", textboxPort.Text ?? "443"));

                Ext.CMD("taskkill /F /IM mitmproxy.exe"); //Вбиваємо його якщо з ним щось не так.

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
            cfg.Write("Settings", "selectedgenshin", genshinBox.SelectedIndex.ToString()); //Вибраний геншин.
            cfg.Write("Settings", "selectedgrass", grassBox.SelectedIndex.ToString()); //Вибраний геншин.
            cfg.Write("Settings", "ip", ipTextBox.Text); //Вибраний ip.
            cfg.Write("Settings", "port", textboxPort.Text); //Вибраний port.
            cfg.Write("Settings", "grassbox", laucnGrassBox.Checked.ToString()); //Вибран грасс.
            cfg.Write("Settings", "patcher", patcherMetatdaBox.Checked.ToString()); //Пачер.
            if (fiddlerBox.Checked)
                cfg.Write("Settings", "method", "fiddler");
            else if (mitmproxyBox.Checked)
                cfg.Write("Settings", "method", "mitmproxy");
            
            if (concviaproxyBox.Checked)
                cfg.Write("Settings", "proxy", "true");


            //Вбиваємо GenshinImpact YuanShen Fiddler Java mitmproxy.exe
            Ext.CMD("taskkill /F /IM GenshinImpact.exe &" +
                "taskkill /F /IM YuanShen.exe &" +
                 "taskkill /F /IM mitmproxy.exe &" +
                "taskkill /IM Fiddler.exe &" + //без /F бо якщо принуждаючи він проксі ламає.
                "taskkill /F /IM Java.exe");

            clearHost(); //Очищюємо хост від зайвого сміття залишиного нами.


            try
            {
                //Робимо нормальним метадату.
                string patchgenshin = Path.GetDirectoryName(cfg.Read($"Genshin{genshinBox.SelectedIndex + 1}", "patch"));
                string isitgenshindata = "GenshinImpact_Data"; //Чекер чайна це чи глобал.
                if (Directory.Exists(patchgenshin + "/YuanShen_Data")) { isitgenshindata = "YuanShen_Data"; }
                else if (Directory.Exists(patchgenshin + "/GenshinImpact_Data")) { isitgenshindata = "GenshinImpact_Data"; }

                if (File.Exists(patchgenshin + $"/{isitgenshindata}/Managed/Metadata/global-metadata-original.dat"))
                {
                    File.Delete(patchgenshin + $"/{isitgenshindata}/Managed/Metadata/global-metadata.dat");
                    File.Copy(patchgenshin + $"/{isitgenshindata}/Managed/Metadata/global-metadata-original.dat", patchgenshin + $"/{isitgenshindata}/Managed/Metadata/global-metadata.dat");
                }

                if (File.Exists(patchgenshin + $"/{isitgenshindata}/Native/Data/Metadata/global-metadata-original.dat"))
                {
                    File.Delete(patchgenshin + $"/{isitgenshindata}/Native/Data/Metadata/global-metadata.dat");
                    File.Copy(patchgenshin + $"/{isitgenshindata}/Native/Data/Metadata/global-metadata-original.dat", patchgenshin + $"/{isitgenshindata}/Native/Data/Metadata/global-metadata.dat");
                }

            }
            catch (ArgumentException) { } //Це нормльно.
            catch (Exception ex) { MessageBox.Show($"Failed to restore global-metadata, reason:\n{ex}"); }

            //Вимикаємо проксі.
            RegistryKey registry = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Internet Settings", true);
            registry.SetValue("ProxyEnable", 0);
        }

        //Перемщение окна.
        private bool dragging = false;
        private Point offset;
        private Point start_point = new Point(0, 0);

        private void xcdto_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            start_point = new Point(e.X, e.Y);
        }

        private void xcdto_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point p = PointToScreen(e.Location);
                Location = new Point(p.X - this.start_point.X, p.Y - this.start_point.Y);
            }
        }

        private void xcdto_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }
        //Конец кода для перемещения.

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
            Ext.CMD("taskkill /F /IM java.exe");
        }

        private void btnOpenServer_Click(object sender, EventArgs e)
        {
            Ext.ExplorerOpen(cfg.Read($"Grasscutter{grassBox.SelectedIndex + 1}", "patch"));
        }

        private void btnopenGenshin_Click(object sender, EventArgs e)
        {
            Ext.CMD(cfg.Read($"Genshin{genshinBox.SelectedIndex + 1}", "patch"));
        }

        private async void btnSettings_Click(object sender, EventArgs e)
        {
            if (panelSettings.Visible == false) { panelSettings.Update(); panelSettings.Show(); panelSettings.Invalidate(); }
            else { panelSettings.Hide(); }
        }

        private async void btnMin_Click(object sender, EventArgs e)
        {
            while (Opacity != 0) { Opacity -= .1; await Task.Delay(1); }

            this.WindowState = FormWindowState.Minimized;
            this.Opacity = 1;
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/Hacker-TA/GILauncher");
        }

        private async void btnClose_Click(object sender, EventArgs e)
        {
            while (Opacity != 0) { Opacity -= .1; await Task.Delay(5); }

            Application.Exit();
        }

    }

    public static class Ext
    {
        public static void CMD(string command) //Метод для запуску консолі з очікуванням виходу.
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = "cmd",
                Arguments = $"/c chcp 65001 & {command}",
                UseShellExecute = false,
                CreateNoWindow = true
            }).WaitForExit();
        }
        public static void ExplorerOpen(string patch)
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = "explorer",
                Arguments = $"/n, /select, {patch}"
            });
        }
    }
}
