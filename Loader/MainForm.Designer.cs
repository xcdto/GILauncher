namespace GILoader
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.UpdaterTimer = new System.Windows.Forms.Timer(this.components);
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panelBackWhreePicrueBox = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2Panel3 = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.panelSettings = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2GroupBox1 = new Guna.UI2.WinForms.Guna2GroupBox();
            this.patcherMetatdaBox = new Guna.UI2.WinForms.Guna2CheckBox();
            this.genshinBox = new Guna.UI2.WinForms.Guna2ComboBox();
            this.GenshinClinetOpenFolder = new Guna.UI2.WinForms.Guna2Button();
            this.AddGenshin = new Guna.UI2.WinForms.Guna2Button();
            this.guna2GroupBox2 = new Guna.UI2.WinForms.Guna2GroupBox();
            this.laucnGrassBox = new Guna.UI2.WinForms.Guna2CheckBox();
            this.grassBox = new Guna.UI2.WinForms.Guna2ComboBox();
            this.grassOpenFolder = new Guna.UI2.WinForms.Guna2Button();
            this.AddGrass = new Guna.UI2.WinForms.Guna2Button();
            this.guna2GroupBox3 = new Guna.UI2.WinForms.Guna2GroupBox();
            this.mitmproxyBox = new Guna.UI2.WinForms.Guna2RadioButton();
            this.fiddlerBox = new Guna.UI2.WinForms.Guna2RadioButton();
            this.panelCheckProxy = new Guna.UI2.WinForms.Guna2Panel();
            this.concviaproxyBox = new Guna.UI2.WinForms.Guna2CheckBox();
            this.panelIPandPort = new Guna.UI2.WinForms.Guna2Panel();
            this.textboxPort = new Guna.UI2.WinForms.Guna2TextBox();
            this.ipTextBox = new Guna.UI2.WinForms.Guna2TextBox();
            this.panelBtnLaucn = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2GradientButton1 = new Guna.UI2.WinForms.Guna2GradientButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.guna2ResizeBox1 = new Guna.UI2.WinForms.Guna2ResizeBox();
            this.guna2Button5 = new Guna.UI2.WinForms.Guna2Button();
            this.picturePoxBack = new Guna.UI2.WinForms.Guna2PictureBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.guna2Button4 = new Guna.UI2.WinForms.Guna2Button();
            this.btnSettings = new Guna.UI2.WinForms.Guna2Button();
            this.btnMin = new Guna.UI2.WinForms.Guna2Button();
            this.btnClose = new Guna.UI2.WinForms.Guna2Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.FormElipse = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.panelSettingsElipse = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            this.panelBackWhreePicrueBox.SuspendLayout();
            this.guna2Panel1.SuspendLayout();
            this.panelSettings.SuspendLayout();
            this.guna2GroupBox1.SuspendLayout();
            this.guna2GroupBox2.SuspendLayout();
            this.guna2GroupBox3.SuspendLayout();
            this.panelCheckProxy.SuspendLayout();
            this.panelIPandPort.SuspendLayout();
            this.panelBtnLaucn.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picturePoxBack)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // UpdaterTimer
            // 
            this.UpdaterTimer.Enabled = true;
            this.UpdaterTimer.Tick += new System.EventHandler(this.UpdaterTimer_Tick);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panelBackWhreePicrueBox, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(830, 550);
            this.tableLayoutPanel1.TabIndex = 17;
            // 
            // panelBackWhreePicrueBox
            // 
            this.panelBackWhreePicrueBox.BackColor = System.Drawing.Color.Transparent;
            this.panelBackWhreePicrueBox.Controls.Add(this.guna2Panel3);
            this.panelBackWhreePicrueBox.Controls.Add(this.guna2Panel1);
            this.panelBackWhreePicrueBox.Controls.Add(this.picturePoxBack);
            this.panelBackWhreePicrueBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBackWhreePicrueBox.Location = new System.Drawing.Point(0, 30);
            this.panelBackWhreePicrueBox.Margin = new System.Windows.Forms.Padding(0);
            this.panelBackWhreePicrueBox.Name = "panelBackWhreePicrueBox";
            this.panelBackWhreePicrueBox.Size = new System.Drawing.Size(830, 520);
            this.panelBackWhreePicrueBox.TabIndex = 0;
            // 
            // guna2Panel3
            // 
            this.guna2Panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.guna2Panel3.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel3.Name = "guna2Panel3";
            this.guna2Panel3.Size = new System.Drawing.Size(412, 520);
            this.guna2Panel3.TabIndex = 21;
            this.guna2Panel3.UseTransparentBackground = true;
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.Controls.Add(this.panelSettings);
            this.guna2Panel1.Controls.Add(this.panelCheckProxy);
            this.guna2Panel1.Controls.Add(this.panelIPandPort);
            this.guna2Panel1.Controls.Add(this.panelBtnLaucn);
            this.guna2Panel1.Controls.Add(this.panel1);
            this.guna2Panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.guna2Panel1.Location = new System.Drawing.Point(418, 0);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(412, 520);
            this.guna2Panel1.TabIndex = 20;
            this.guna2Panel1.UseTransparentBackground = true;
            // 
            // panelSettings
            // 
            this.panelSettings.Controls.Add(this.guna2GroupBox1);
            this.panelSettings.Controls.Add(this.guna2GroupBox2);
            this.panelSettings.Controls.Add(this.guna2GroupBox3);
            this.panelSettings.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSettings.Location = new System.Drawing.Point(0, 0);
            this.panelSettings.Name = "panelSettings";
            this.panelSettings.Size = new System.Drawing.Size(352, 338);
            this.panelSettings.TabIndex = 23;
            this.panelSettings.UseTransparentBackground = true;
            this.panelSettings.Visible = false;
            // 
            // guna2GroupBox1
            // 
            this.guna2GroupBox1.BackColor = System.Drawing.Color.Transparent;
            this.guna2GroupBox1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.guna2GroupBox1.BorderRadius = 5;
            this.guna2GroupBox1.Controls.Add(this.patcherMetatdaBox);
            this.guna2GroupBox1.Controls.Add(this.genshinBox);
            this.guna2GroupBox1.Controls.Add(this.GenshinClinetOpenFolder);
            this.guna2GroupBox1.Controls.Add(this.AddGenshin);
            this.guna2GroupBox1.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.guna2GroupBox1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.guna2GroupBox1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2GroupBox1.ForeColor = System.Drawing.Color.White;
            this.guna2GroupBox1.Location = new System.Drawing.Point(31, 215);
            this.guna2GroupBox1.Name = "guna2GroupBox1";
            this.guna2GroupBox1.ShadowDecoration.BorderRadius = 10;
            this.guna2GroupBox1.ShadowDecoration.Depth = 10;
            this.guna2GroupBox1.ShadowDecoration.Enabled = true;
            this.guna2GroupBox1.Size = new System.Drawing.Size(290, 118);
            this.guna2GroupBox1.TabIndex = 25;
            this.guna2GroupBox1.Text = "Genshin";
            // 
            // patcherMetatdaBox
            // 
            this.patcherMetatdaBox.Animated = true;
            this.patcherMetatdaBox.AutoSize = true;
            this.patcherMetatdaBox.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(198)))), ((int)(((byte)(25)))));
            this.patcherMetatdaBox.CheckedState.BorderRadius = 2;
            this.patcherMetatdaBox.CheckedState.BorderThickness = 1;
            this.patcherMetatdaBox.CheckedState.FillColor = System.Drawing.Color.White;
            this.patcherMetatdaBox.CheckMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(198)))), ((int)(((byte)(25)))));
            this.patcherMetatdaBox.Font = new System.Drawing.Font("Segoe UI Black", 12F, System.Drawing.FontStyle.Bold);
            this.patcherMetatdaBox.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.patcherMetatdaBox.Location = new System.Drawing.Point(13, 43);
            this.patcherMetatdaBox.Name = "patcherMetatdaBox";
            this.patcherMetatdaBox.Size = new System.Drawing.Size(153, 25);
            this.patcherMetatdaBox.TabIndex = 24;
            this.patcherMetatdaBox.Text = "Patch Metedata";
            this.patcherMetatdaBox.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.patcherMetatdaBox.UncheckedState.BorderRadius = 2;
            this.patcherMetatdaBox.UncheckedState.BorderThickness = 1;
            this.patcherMetatdaBox.UncheckedState.FillColor = System.Drawing.Color.White;
            // 
            // genshinBox
            // 
            this.genshinBox.BackColor = System.Drawing.Color.Transparent;
            this.genshinBox.BorderRadius = 5;
            this.genshinBox.BorderThickness = 2;
            this.genshinBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.genshinBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.genshinBox.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(198)))), ((int)(((byte)(25)))));
            this.genshinBox.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(198)))), ((int)(((byte)(25)))));
            this.genshinBox.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.genshinBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.genshinBox.IntegralHeight = false;
            this.genshinBox.ItemHeight = 26;
            this.genshinBox.Location = new System.Drawing.Point(12, 74);
            this.genshinBox.Name = "genshinBox";
            this.genshinBox.ShadowDecoration.BorderRadius = 10;
            this.genshinBox.ShadowDecoration.Depth = 10;
            this.genshinBox.ShadowDecoration.Enabled = true;
            this.genshinBox.Size = new System.Drawing.Size(191, 32);
            this.genshinBox.TabIndex = 21;
            // 
            // GenshinClinetOpenFolder
            // 
            this.GenshinClinetOpenFolder.Animated = true;
            this.GenshinClinetOpenFolder.BackColor = System.Drawing.Color.Transparent;
            this.GenshinClinetOpenFolder.BorderRadius = 3;
            this.GenshinClinetOpenFolder.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.GenshinClinetOpenFolder.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.GenshinClinetOpenFolder.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.GenshinClinetOpenFolder.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.GenshinClinetOpenFolder.FillColor = System.Drawing.Color.Transparent;
            this.GenshinClinetOpenFolder.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.GenshinClinetOpenFolder.ForeColor = System.Drawing.Color.White;
            this.GenshinClinetOpenFolder.Image = global::Loader.Properties.Resources.icons8_folder_96px;
            this.GenshinClinetOpenFolder.ImageSize = new System.Drawing.Size(21, 21);
            this.GenshinClinetOpenFolder.Location = new System.Drawing.Point(209, 72);
            this.GenshinClinetOpenFolder.Margin = new System.Windows.Forms.Padding(0);
            this.GenshinClinetOpenFolder.Name = "GenshinClinetOpenFolder";
            this.GenshinClinetOpenFolder.Size = new System.Drawing.Size(35, 35);
            this.GenshinClinetOpenFolder.TabIndex = 23;
            this.GenshinClinetOpenFolder.Click += new System.EventHandler(this.btnopenGenshin_Click);
            // 
            // AddGenshin
            // 
            this.AddGenshin.Animated = true;
            this.AddGenshin.BackColor = System.Drawing.Color.Transparent;
            this.AddGenshin.BorderRadius = 3;
            this.AddGenshin.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.AddGenshin.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.AddGenshin.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.AddGenshin.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.AddGenshin.FillColor = System.Drawing.Color.Transparent;
            this.AddGenshin.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.AddGenshin.ForeColor = System.Drawing.Color.White;
            this.AddGenshin.Image = global::Loader.Properties.Resources.icons8_plus_math_96px;
            this.AddGenshin.Location = new System.Drawing.Point(249, 72);
            this.AddGenshin.Margin = new System.Windows.Forms.Padding(0);
            this.AddGenshin.Name = "AddGenshin";
            this.AddGenshin.Size = new System.Drawing.Size(35, 35);
            this.AddGenshin.TabIndex = 22;
            this.AddGenshin.Click += new System.EventHandler(this.btnAddClient_Click);
            // 
            // guna2GroupBox2
            // 
            this.guna2GroupBox2.BackColor = System.Drawing.Color.Transparent;
            this.guna2GroupBox2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.guna2GroupBox2.BorderRadius = 5;
            this.guna2GroupBox2.Controls.Add(this.laucnGrassBox);
            this.guna2GroupBox2.Controls.Add(this.grassBox);
            this.guna2GroupBox2.Controls.Add(this.grassOpenFolder);
            this.guna2GroupBox2.Controls.Add(this.AddGrass);
            this.guna2GroupBox2.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.guna2GroupBox2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.guna2GroupBox2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2GroupBox2.ForeColor = System.Drawing.Color.White;
            this.guna2GroupBox2.Location = new System.Drawing.Point(31, 91);
            this.guna2GroupBox2.Name = "guna2GroupBox2";
            this.guna2GroupBox2.ShadowDecoration.BorderRadius = 10;
            this.guna2GroupBox2.ShadowDecoration.Depth = 10;
            this.guna2GroupBox2.ShadowDecoration.Enabled = true;
            this.guna2GroupBox2.Size = new System.Drawing.Size(290, 118);
            this.guna2GroupBox2.TabIndex = 24;
            this.guna2GroupBox2.Text = "Grasscutter";
            // 
            // laucnGrassBox
            // 
            this.laucnGrassBox.Animated = true;
            this.laucnGrassBox.AutoSize = true;
            this.laucnGrassBox.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(198)))), ((int)(((byte)(25)))));
            this.laucnGrassBox.CheckedState.BorderRadius = 2;
            this.laucnGrassBox.CheckedState.BorderThickness = 1;
            this.laucnGrassBox.CheckedState.FillColor = System.Drawing.Color.White;
            this.laucnGrassBox.CheckMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(198)))), ((int)(((byte)(25)))));
            this.laucnGrassBox.Font = new System.Drawing.Font("Segoe UI Black", 12F, System.Drawing.FontStyle.Bold);
            this.laucnGrassBox.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.laucnGrassBox.Location = new System.Drawing.Point(13, 43);
            this.laucnGrassBox.Name = "laucnGrassBox";
            this.laucnGrassBox.Size = new System.Drawing.Size(151, 25);
            this.laucnGrassBox.TabIndex = 24;
            this.laucnGrassBox.Text = "Launch with GC";
            this.laucnGrassBox.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.laucnGrassBox.UncheckedState.BorderRadius = 2;
            this.laucnGrassBox.UncheckedState.BorderThickness = 1;
            this.laucnGrassBox.UncheckedState.FillColor = System.Drawing.Color.White;
            // 
            // grassBox
            // 
            this.grassBox.BackColor = System.Drawing.Color.Transparent;
            this.grassBox.BorderRadius = 5;
            this.grassBox.BorderThickness = 2;
            this.grassBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.grassBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.grassBox.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(198)))), ((int)(((byte)(25)))));
            this.grassBox.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(198)))), ((int)(((byte)(25)))));
            this.grassBox.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.grassBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.grassBox.IntegralHeight = false;
            this.grassBox.ItemHeight = 26;
            this.grassBox.Location = new System.Drawing.Point(12, 74);
            this.grassBox.Name = "grassBox";
            this.grassBox.ShadowDecoration.BorderRadius = 10;
            this.grassBox.ShadowDecoration.Depth = 10;
            this.grassBox.ShadowDecoration.Enabled = true;
            this.grassBox.Size = new System.Drawing.Size(191, 32);
            this.grassBox.TabIndex = 21;
            // 
            // grassOpenFolder
            // 
            this.grassOpenFolder.Animated = true;
            this.grassOpenFolder.BackColor = System.Drawing.Color.Transparent;
            this.grassOpenFolder.BorderRadius = 3;
            this.grassOpenFolder.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.grassOpenFolder.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.grassOpenFolder.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.grassOpenFolder.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.grassOpenFolder.FillColor = System.Drawing.Color.Transparent;
            this.grassOpenFolder.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.grassOpenFolder.ForeColor = System.Drawing.Color.White;
            this.grassOpenFolder.Image = global::Loader.Properties.Resources.icons8_folder_96px;
            this.grassOpenFolder.ImageSize = new System.Drawing.Size(21, 21);
            this.grassOpenFolder.Location = new System.Drawing.Point(209, 72);
            this.grassOpenFolder.Margin = new System.Windows.Forms.Padding(0);
            this.grassOpenFolder.Name = "grassOpenFolder";
            this.grassOpenFolder.Size = new System.Drawing.Size(35, 35);
            this.grassOpenFolder.TabIndex = 23;
            this.grassOpenFolder.Click += new System.EventHandler(this.btnOpenServer_Click);
            // 
            // AddGrass
            // 
            this.AddGrass.Animated = true;
            this.AddGrass.BackColor = System.Drawing.Color.Transparent;
            this.AddGrass.BorderRadius = 3;
            this.AddGrass.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.AddGrass.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.AddGrass.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.AddGrass.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.AddGrass.FillColor = System.Drawing.Color.Transparent;
            this.AddGrass.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.AddGrass.ForeColor = System.Drawing.Color.White;
            this.AddGrass.Image = global::Loader.Properties.Resources.icons8_plus_math_96px;
            this.AddGrass.Location = new System.Drawing.Point(249, 72);
            this.AddGrass.Margin = new System.Windows.Forms.Padding(0);
            this.AddGrass.Name = "AddGrass";
            this.AddGrass.Size = new System.Drawing.Size(35, 35);
            this.AddGrass.TabIndex = 22;
            this.AddGrass.Click += new System.EventHandler(this.btnAddGrass_Click);
            // 
            // guna2GroupBox3
            // 
            this.guna2GroupBox3.BackColor = System.Drawing.Color.Transparent;
            this.guna2GroupBox3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.guna2GroupBox3.BorderRadius = 5;
            this.guna2GroupBox3.Controls.Add(this.mitmproxyBox);
            this.guna2GroupBox3.Controls.Add(this.fiddlerBox);
            this.guna2GroupBox3.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.guna2GroupBox3.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.guna2GroupBox3.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2GroupBox3.ForeColor = System.Drawing.Color.White;
            this.guna2GroupBox3.Location = new System.Drawing.Point(31, 10);
            this.guna2GroupBox3.Name = "guna2GroupBox3";
            this.guna2GroupBox3.ShadowDecoration.BorderRadius = 10;
            this.guna2GroupBox3.ShadowDecoration.Depth = 10;
            this.guna2GroupBox3.ShadowDecoration.Enabled = true;
            this.guna2GroupBox3.Size = new System.Drawing.Size(290, 75);
            this.guna2GroupBox3.TabIndex = 24;
            this.guna2GroupBox3.Text = "Proxy Method";
            // 
            // mitmproxyBox
            // 
            this.mitmproxyBox.Animated = true;
            this.mitmproxyBox.AutoSize = true;
            this.mitmproxyBox.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(198)))), ((int)(((byte)(25)))));
            this.mitmproxyBox.CheckedState.BorderThickness = 0;
            this.mitmproxyBox.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(198)))), ((int)(((byte)(25)))));
            this.mitmproxyBox.CheckedState.InnerColor = System.Drawing.Color.White;
            this.mitmproxyBox.CheckedState.InnerOffset = -4;
            this.mitmproxyBox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.mitmproxyBox.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.mitmproxyBox.Location = new System.Drawing.Point(90, 47);
            this.mitmproxyBox.Name = "mitmproxyBox";
            this.mitmproxyBox.Padding = new System.Windows.Forms.Padding(1, 0, 0, 0);
            this.mitmproxyBox.Size = new System.Drawing.Size(85, 19);
            this.mitmproxyBox.TabIndex = 19;
            this.mitmproxyBox.Text = "Mitmproxy";
            this.mitmproxyBox.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(218)))), ((int)(((byte)(223)))));
            this.mitmproxyBox.UncheckedState.BorderThickness = 3;
            this.mitmproxyBox.UncheckedState.FillColor = System.Drawing.Color.Transparent;
            this.mitmproxyBox.UncheckedState.InnerColor = System.Drawing.Color.Transparent;
            // 
            // fiddlerBox
            // 
            this.fiddlerBox.Animated = true;
            this.fiddlerBox.AutoSize = true;
            this.fiddlerBox.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(198)))), ((int)(((byte)(25)))));
            this.fiddlerBox.CheckedState.BorderThickness = 0;
            this.fiddlerBox.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(198)))), ((int)(((byte)(25)))));
            this.fiddlerBox.CheckedState.InnerColor = System.Drawing.Color.White;
            this.fiddlerBox.CheckedState.InnerOffset = -4;
            this.fiddlerBox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.fiddlerBox.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.fiddlerBox.Location = new System.Drawing.Point(13, 47);
            this.fiddlerBox.Name = "fiddlerBox";
            this.fiddlerBox.Padding = new System.Windows.Forms.Padding(1, 0, 0, 0);
            this.fiddlerBox.Size = new System.Drawing.Size(62, 19);
            this.fiddlerBox.TabIndex = 18;
            this.fiddlerBox.Text = "Fiddler";
            this.fiddlerBox.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(218)))), ((int)(((byte)(223)))));
            this.fiddlerBox.UncheckedState.BorderThickness = 3;
            this.fiddlerBox.UncheckedState.FillColor = System.Drawing.Color.Transparent;
            this.fiddlerBox.UncheckedState.InnerColor = System.Drawing.Color.Transparent;
            // 
            // panelCheckProxy
            // 
            this.panelCheckProxy.Controls.Add(this.concviaproxyBox);
            this.panelCheckProxy.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelCheckProxy.Location = new System.Drawing.Point(0, 353);
            this.panelCheckProxy.Name = "panelCheckProxy";
            this.panelCheckProxy.Size = new System.Drawing.Size(352, 27);
            this.panelCheckProxy.TabIndex = 22;
            this.panelCheckProxy.UseTransparentBackground = true;
            // 
            // concviaproxyBox
            // 
            this.concviaproxyBox.Animated = true;
            this.concviaproxyBox.AutoSize = true;
            this.concviaproxyBox.Checked = true;
            this.concviaproxyBox.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(198)))), ((int)(((byte)(25)))));
            this.concviaproxyBox.CheckedState.BorderRadius = 2;
            this.concviaproxyBox.CheckedState.BorderThickness = 1;
            this.concviaproxyBox.CheckedState.FillColor = System.Drawing.Color.White;
            this.concviaproxyBox.CheckMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(198)))), ((int)(((byte)(25)))));
            this.concviaproxyBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.concviaproxyBox.Font = new System.Drawing.Font("Segoe UI Black", 12F, System.Drawing.FontStyle.Bold);
            this.concviaproxyBox.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.concviaproxyBox.Location = new System.Drawing.Point(36, 3);
            this.concviaproxyBox.Name = "concviaproxyBox";
            this.concviaproxyBox.Size = new System.Drawing.Size(170, 25);
            this.concviaproxyBox.TabIndex = 0;
            this.concviaproxyBox.Text = "Connect via Proxy";
            this.concviaproxyBox.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.concviaproxyBox.UncheckedState.BorderRadius = 2;
            this.concviaproxyBox.UncheckedState.BorderThickness = 1;
            this.concviaproxyBox.UncheckedState.FillColor = System.Drawing.Color.White;
            // 
            // panelIPandPort
            // 
            this.panelIPandPort.Controls.Add(this.textboxPort);
            this.panelIPandPort.Controls.Add(this.ipTextBox);
            this.panelIPandPort.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelIPandPort.Location = new System.Drawing.Point(0, 380);
            this.panelIPandPort.Name = "panelIPandPort";
            this.panelIPandPort.Size = new System.Drawing.Size(352, 40);
            this.panelIPandPort.TabIndex = 21;
            this.panelIPandPort.UseTransparentBackground = true;
            // 
            // textboxPort
            // 
            this.textboxPort.Animated = true;
            this.textboxPort.BackColor = System.Drawing.Color.Transparent;
            this.textboxPort.BorderRadius = 5;
            this.textboxPort.BorderThickness = 2;
            this.textboxPort.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textboxPort.DefaultText = "443";
            this.textboxPort.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.textboxPort.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.textboxPort.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.textboxPort.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.textboxPort.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(198)))), ((int)(((byte)(25)))));
            this.textboxPort.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.textboxPort.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(198)))), ((int)(((byte)(25)))));
            this.textboxPort.Location = new System.Drawing.Point(242, 4);
            this.textboxPort.Name = "textboxPort";
            this.textboxPort.PasswordChar = '\0';
            this.textboxPort.PlaceholderText = "";
            this.textboxPort.SelectedText = "";
            this.textboxPort.ShadowDecoration.BorderRadius = 10;
            this.textboxPort.ShadowDecoration.Depth = 10;
            this.textboxPort.ShadowDecoration.Enabled = true;
            this.textboxPort.Size = new System.Drawing.Size(74, 32);
            this.textboxPort.TabIndex = 19;
            this.textboxPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ipTextBox
            // 
            this.ipTextBox.Animated = true;
            this.ipTextBox.BackColor = System.Drawing.Color.Transparent;
            this.ipTextBox.BorderRadius = 5;
            this.ipTextBox.BorderThickness = 2;
            this.ipTextBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.ipTextBox.DefaultText = "localhost";
            this.ipTextBox.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.ipTextBox.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.ipTextBox.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.ipTextBox.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.ipTextBox.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(198)))), ((int)(((byte)(25)))));
            this.ipTextBox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.ipTextBox.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(198)))), ((int)(((byte)(25)))));
            this.ipTextBox.Location = new System.Drawing.Point(36, 4);
            this.ipTextBox.Name = "ipTextBox";
            this.ipTextBox.PasswordChar = '\0';
            this.ipTextBox.PlaceholderText = "";
            this.ipTextBox.SelectedText = "";
            this.ipTextBox.ShadowDecoration.BorderRadius = 10;
            this.ipTextBox.ShadowDecoration.Depth = 10;
            this.ipTextBox.ShadowDecoration.Enabled = true;
            this.ipTextBox.Size = new System.Drawing.Size(200, 32);
            this.ipTextBox.TabIndex = 18;
            // 
            // panelBtnLaucn
            // 
            this.panelBtnLaucn.Controls.Add(this.guna2GradientButton1);
            this.panelBtnLaucn.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBtnLaucn.Location = new System.Drawing.Point(0, 420);
            this.panelBtnLaucn.Name = "panelBtnLaucn";
            this.panelBtnLaucn.Size = new System.Drawing.Size(352, 100);
            this.panelBtnLaucn.TabIndex = 20;
            this.panelBtnLaucn.UseTransparentBackground = true;
            // 
            // guna2GradientButton1
            // 
            this.guna2GradientButton1.Animated = true;
            this.guna2GradientButton1.BackColor = System.Drawing.Color.Transparent;
            this.guna2GradientButton1.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2GradientButton1.BorderRadius = 5;
            this.guna2GradientButton1.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2GradientButton1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2GradientButton1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2GradientButton1.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2GradientButton1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2GradientButton1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(211)))), ((int)(((byte)(40)))));
            this.guna2GradientButton1.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(198)))), ((int)(((byte)(25)))));
            this.guna2GradientButton1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.guna2GradientButton1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(74)))), ((int)(((byte)(29)))));
            this.guna2GradientButton1.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(198)))), ((int)(((byte)(25)))));
            this.guna2GradientButton1.HoverState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(211)))), ((int)(((byte)(40)))));
            this.guna2GradientButton1.Location = new System.Drawing.Point(36, 5);
            this.guna2GradientButton1.Name = "guna2GradientButton1";
            this.guna2GradientButton1.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(74)))), ((int)(((byte)(29)))));
            this.guna2GradientButton1.ShadowDecoration.BorderRadius = 10;
            this.guna2GradientButton1.ShadowDecoration.Depth = 15;
            this.guna2GradientButton1.ShadowDecoration.Enabled = true;
            this.guna2GradientButton1.Size = new System.Drawing.Size(280, 60);
            this.guna2GradientButton1.TabIndex = 18;
            this.guna2GradientButton1.Text = "Launch";
            this.guna2GradientButton1.UseTransparentBackground = true;
            this.guna2GradientButton1.Click += new System.EventHandler(this.btnLaunch_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.panel1.Controls.Add(this.guna2ResizeBox1);
            this.panel1.Controls.Add(this.guna2Button5);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(352, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(60, 520);
            this.panel1.TabIndex = 19;
            // 
            // guna2ResizeBox1
            // 
            this.guna2ResizeBox1.BackColor = System.Drawing.Color.Transparent;
            this.guna2ResizeBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.guna2ResizeBox1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.guna2ResizeBox1.ForeColor = System.Drawing.Color.Black;
            this.guna2ResizeBox1.Location = new System.Drawing.Point(0, 500);
            this.guna2ResizeBox1.Margin = new System.Windows.Forms.Padding(5);
            this.guna2ResizeBox1.Name = "guna2ResizeBox1";
            this.guna2ResizeBox1.Size = new System.Drawing.Size(60, 20);
            this.guna2ResizeBox1.TabIndex = 18;
            this.guna2ResizeBox1.TargetControl = this;
            // 
            // guna2Button5
            // 
            this.guna2Button5.Animated = true;
            this.guna2Button5.BackColor = System.Drawing.Color.Transparent;
            this.guna2Button5.BorderRadius = 20;
            this.guna2Button5.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button5.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button5.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button5.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button5.FillColor = System.Drawing.Color.Transparent;
            this.guna2Button5.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2Button5.ForeColor = System.Drawing.Color.White;
            this.guna2Button5.Image = global::Loader.Properties.Resources.icons8_github_96px;
            this.guna2Button5.ImageSize = new System.Drawing.Size(30, 30);
            this.guna2Button5.Location = new System.Drawing.Point(11, 10);
            this.guna2Button5.Margin = new System.Windows.Forms.Padding(10);
            this.guna2Button5.Name = "guna2Button5";
            this.guna2Button5.Size = new System.Drawing.Size(40, 40);
            this.guna2Button5.TabIndex = 18;
            // 
            // picturePoxBack
            // 
            this.picturePoxBack.BackColor = System.Drawing.Color.Transparent;
            this.picturePoxBack.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picturePoxBack.Image = global::Loader.Properties.Resources.Raiden_Shogun_Build_Guide_For_Genshin_Impact;
            this.picturePoxBack.ImageRotate = 0F;
            this.picturePoxBack.Location = new System.Drawing.Point(0, 0);
            this.picturePoxBack.Margin = new System.Windows.Forms.Padding(0);
            this.picturePoxBack.Name = "picturePoxBack";
            this.picturePoxBack.Size = new System.Drawing.Size(830, 520);
            this.picturePoxBack.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picturePoxBack.TabIndex = 19;
            this.picturePoxBack.TabStop = false;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.panel2, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.panel3, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(830, 30);
            this.tableLayoutPanel2.TabIndex = 1;
            this.tableLayoutPanel2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.xcdto_MouseDown);
            this.tableLayoutPanel2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.xcdto_MouseMove);
            this.tableLayoutPanel2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.xcdto_MouseUp);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.guna2Button4);
            this.panel2.Controls.Add(this.btnSettings);
            this.panel2.Controls.Add(this.btnMin);
            this.panel2.Controls.Add(this.btnClose);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(630, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(200, 30);
            this.panel2.TabIndex = 0;
            this.panel2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.xcdto_MouseDown);
            this.panel2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.xcdto_MouseMove);
            this.panel2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.xcdto_MouseUp);
            // 
            // guna2Button4
            // 
            this.guna2Button4.Animated = true;
            this.guna2Button4.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button4.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button4.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button4.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button4.Dock = System.Windows.Forms.DockStyle.Right;
            this.guna2Button4.FillColor = System.Drawing.Color.Transparent;
            this.guna2Button4.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2Button4.ForeColor = System.Drawing.Color.White;
            this.guna2Button4.Image = global::Loader.Properties.Resources.icons8_download_96px;
            this.guna2Button4.ImageOffset = new System.Drawing.Point(1, 1);
            this.guna2Button4.ImageSize = new System.Drawing.Size(17, 17);
            this.guna2Button4.Location = new System.Drawing.Point(80, 0);
            this.guna2Button4.Margin = new System.Windows.Forms.Padding(0);
            this.guna2Button4.Name = "guna2Button4";
            this.guna2Button4.Size = new System.Drawing.Size(30, 30);
            this.guna2Button4.TabIndex = 21;
            this.guna2Button4.Visible = false;
            // 
            // btnSettings
            // 
            this.btnSettings.Animated = true;
            this.btnSettings.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSettings.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSettings.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSettings.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSettings.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnSettings.FillColor = System.Drawing.Color.Transparent;
            this.btnSettings.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnSettings.ForeColor = System.Drawing.Color.White;
            this.btnSettings.Image = global::Loader.Properties.Resources.icons8_settings_96px;
            this.btnSettings.ImageOffset = new System.Drawing.Point(1, 1);
            this.btnSettings.ImageSize = new System.Drawing.Size(17, 17);
            this.btnSettings.Location = new System.Drawing.Point(110, 0);
            this.btnSettings.Margin = new System.Windows.Forms.Padding(0);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(30, 30);
            this.btnSettings.TabIndex = 20;
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // btnMin
            // 
            this.btnMin.Animated = true;
            this.btnMin.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnMin.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnMin.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnMin.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnMin.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnMin.FillColor = System.Drawing.Color.Transparent;
            this.btnMin.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnMin.ForeColor = System.Drawing.Color.White;
            this.btnMin.Image = global::Loader.Properties.Resources.icons8_minus_96px;
            this.btnMin.Location = new System.Drawing.Point(140, 0);
            this.btnMin.Margin = new System.Windows.Forms.Padding(0);
            this.btnMin.Name = "btnMin";
            this.btnMin.Size = new System.Drawing.Size(30, 30);
            this.btnMin.TabIndex = 19;
            this.btnMin.Click += new System.EventHandler(this.btnMin_Click);
            // 
            // btnClose
            // 
            this.btnClose.Animated = true;
            this.btnClose.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnClose.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnClose.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnClose.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnClose.FillColor = System.Drawing.Color.Transparent;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Image = global::Loader.Properties.Resources.icons8_close_96px;
            this.btnClose.Location = new System.Drawing.Point(170, 0);
            this.btnClose.Margin = new System.Windows.Forms.Padding(0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(30, 30);
            this.btnClose.TabIndex = 18;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(200, 30);
            this.panel3.TabIndex = 1;
            this.panel3.MouseDown += new System.Windows.Forms.MouseEventHandler(this.xcdto_MouseDown);
            this.panel3.MouseMove += new System.Windows.Forms.MouseEventHandler(this.xcdto_MouseMove);
            this.panel3.MouseUp += new System.Windows.Forms.MouseEventHandler(this.xcdto_MouseUp);
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Left;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 7F);
            this.label2.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.label2.Location = new System.Drawing.Point(79, 0);
            this.label2.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.label2.Size = new System.Drawing.Size(85, 30);
            this.label2.TabIndex = 1;
            this.label2.Text = "v1.0.0.5-beta";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.xcdto_MouseDown);
            this.label2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.xcdto_MouseMove);
            this.label2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.xcdto_MouseUp);
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 30);
            this.label1.TabIndex = 0;
            this.label1.Text = "GILaucnher";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.xcdto_MouseDown);
            this.label1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.xcdto_MouseMove);
            this.label1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.xcdto_MouseUp);
            // 
            // FormElipse
            // 
            this.FormElipse.BorderRadius = 13;
            this.FormElipse.TargetControl = this;
            // 
            // panelSettingsElipse
            // 
            this.panelSettingsElipse.BorderRadius = 13;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(830, 550);
            this.Controls.Add(this.tableLayoutPanel1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(830, 550);
            this.Name = "MainForm";
            this.Opacity = 0D;
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " ";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panelBackWhreePicrueBox.ResumeLayout(false);
            this.guna2Panel1.ResumeLayout(false);
            this.panelSettings.ResumeLayout(false);
            this.guna2GroupBox1.ResumeLayout(false);
            this.guna2GroupBox1.PerformLayout();
            this.guna2GroupBox2.ResumeLayout(false);
            this.guna2GroupBox2.PerformLayout();
            this.guna2GroupBox3.ResumeLayout(false);
            this.guna2GroupBox3.PerformLayout();
            this.panelCheckProxy.ResumeLayout(false);
            this.panelCheckProxy.PerformLayout();
            this.panelIPandPort.ResumeLayout(false);
            this.panelBtnLaucn.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picturePoxBack)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer UpdaterTimer;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Guna.UI2.WinForms.Guna2Panel panelBackWhreePicrueBox;
        private Guna.UI2.WinForms.Guna2PictureBox picturePoxBack;
        private Guna.UI2.WinForms.Guna2GradientButton guna2GradientButton1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2Button btnClose;
        private System.Windows.Forms.Panel panel1;
        private Guna.UI2.WinForms.Guna2Elipse FormElipse;
        private System.Windows.Forms.Panel panel2;
        private Guna.UI2.WinForms.Guna2Button guna2Button4;
        private Guna.UI2.WinForms.Guna2Button btnSettings;
        private Guna.UI2.WinForms.Guna2Button btnMin;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2Button guna2Button5;
        private Guna.UI2.WinForms.Guna2Panel panelIPandPort;
        private Guna.UI2.WinForms.Guna2TextBox ipTextBox;
        private Guna.UI2.WinForms.Guna2Panel panelBtnLaucn;
        private Guna.UI2.WinForms.Guna2TextBox textboxPort;
        private Guna.UI2.WinForms.Guna2Panel panelCheckProxy;
        private Guna.UI2.WinForms.Guna2CheckBox concviaproxyBox;
        private Guna.UI2.WinForms.Guna2ResizeBox guna2ResizeBox1;
        private Guna.UI2.WinForms.Guna2Elipse panelSettingsElipse;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel3;
        private Guna.UI2.WinForms.Guna2Panel panelSettings;
        private Guna.UI2.WinForms.Guna2GroupBox guna2GroupBox2;
        private Guna.UI2.WinForms.Guna2CheckBox laucnGrassBox;
        private Guna.UI2.WinForms.Guna2ComboBox grassBox;
        private Guna.UI2.WinForms.Guna2Button grassOpenFolder;
        private Guna.UI2.WinForms.Guna2Button AddGrass;
        private Guna.UI2.WinForms.Guna2GroupBox guna2GroupBox3;
        private Guna.UI2.WinForms.Guna2RadioButton mitmproxyBox;
        private Guna.UI2.WinForms.Guna2RadioButton fiddlerBox;
        private Guna.UI2.WinForms.Guna2GroupBox guna2GroupBox1;
        private Guna.UI2.WinForms.Guna2CheckBox patcherMetatdaBox;
        private Guna.UI2.WinForms.Guna2ComboBox genshinBox;
        private Guna.UI2.WinForms.Guna2Button GenshinClinetOpenFolder;
        private Guna.UI2.WinForms.Guna2Button AddGenshin;
    }
}

