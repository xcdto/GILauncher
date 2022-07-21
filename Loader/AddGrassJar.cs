using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Loader
{
    public partial class AddGrassJar : Form
    {
        public AddGrassJar()
        {
            InitializeComponent();
        }

        private void clickTextBoxClientPatch(object sender, MouseEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Grasscutter Jar (.jar)|*.jar|All Files (*.*)|*.*";
            ofd.RestoreDirectory = true;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    Stream stream;
                    if ((stream = ofd.OpenFile()) != null)
                    {
                        using (stream)
                        {
                            textBox2.Text = (ofd.FileName);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Debug:" + ex.Message, "Error");
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == null && textBox2.Text == null) { return; }

            Loader.Config cfg = new Config(Application.StartupPath + "/config.ini"); //Підключаєм конфіг.

            int allclients = Convert.ToInt32(cfg.Read("Settings", "grasscuters")); //Отримуємо число того скільки в нас клієнтів.

            int addedclient = allclients + 1;

            cfg.Write($"Grasscutter{addedclient}", "name", textBox1.Text); //нейм.
            cfg.Write($"Grasscutter{addedclient}", "patch", textBox2.Text); //його шлях
            cfg.Write("Settings", "grasscuters", addedclient.ToString()); //скільки всього клієнтів.

            this.Close();
        }
    }
}
