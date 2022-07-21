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
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GILoader
{
    public partial class MainForm : Form
    {
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
                    if (label1.Text.Contains("Done"))
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
            if (lnchGC.Checked) //Галка з грасскуттером чи ні.
            {
                string grasscutterfile = cfg.Read($"Grasscutter{comboBoxGenshin.SelectedIndex + 1}", "patch"); //Шлях отримаємо з конфігу.
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

                grassutterProcess.BeginOutputReadLine();
                grassutterProcess.BeginErrorReadLine();
                grassutterProcess.OutputDataReceived += (s, a) => { label1.Text += Environment.NewLine + a.Data; }; // Показуємо в label те що нам виводить консоль. 
                grassutterProcess.ErrorDataReceived += (s, a) => { label1.Text += Environment.NewLine + a.Data; }; // Можливо для дебагу це допоможе, ах.
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
            else if (hostcheck.Checked) //Через Хост чи ні.
            {
                //to do: Зробити через файл хост.
                proxyok = true;
            }
            else if (nochange.Checked) //Якщо нічого не вибрано.
            {
                proxyok = true;
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Зберінаємо налаштування.
            cfg.Write("Settings", "selectedgenshin", comboBoxGenshin.SelectedIndex.ToString()); //Вибраний геншин.
            cfg.Write("Settings", "selectedgrass", comboBox2.SelectedIndex.ToString()); //Вибраний геншин.
            cfg.Write("Settings", "ip", textBox1.Text); //Вибраний ip.

            //Вбиваємо Геншин.
            Process[] processesGen = Process.GetProcessesByName("GenshinImpact");
            foreach (Process worker in processesGen)
            {
                worker.Kill();
            }
            Process[] processesYan = Process.GetProcessesByName("YuanShen");
            foreach (Process worker in processesYan)
            {
                worker.Kill();
            }

            //Вбиваємо фідлер.
            Process[] processesFid = Process.GetProcessesByName("Fiddler");
            foreach (Process worker in processesFid)
            {
                worker.Kill();
            }

            //Вбиваємо Java.
            Process[] processesJava = Process.GetProcessesByName("Java");
            foreach (Process worker in processesFid)
            {
                worker.Kill();
            }

            //Буває таке, що процесс з cmd відкритий, та й ще з відкритим грасскутером. Тому робимо кілл процес.
            try { publicgrassproc.Kill(); } catch { } //Якщо він не зміг його вбити, то нічого страшного. Обробляти також не треба.
        }

        private void btnAddClient_Click(object sender, EventArgs e)
        {
            Form frmadd = new Loader.AddClient();
            frmadd.ShowDialog();
        }

        private void btnAddGrass_Click(object sender, EventArgs e)
        {
            Form frmadd = new Loader.AddGrassJar();
            frmadd.ShowDialog();
        }
    }
}
