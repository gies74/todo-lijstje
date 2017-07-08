namespace TodoLijstje
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.cmActiviteit = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.verwijderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hernoemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
            this.eigenschappenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sorteerTakenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verwijderVoltooidToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verwijderAllesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.verbergToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toonverbergTabToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.geagendeerdeTakenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.opslaanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btNewAct = new System.Windows.Forms.Button();
            this.cmTaak = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.verwijderToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.verplaatsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.bovenaanToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.naarBovenToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.naarOnderToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.onderaanToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.btPausestart = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.cbAlwaysOnTop = new System.Windows.Forms.CheckBox();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.btForceTick = new System.Windows.Forms.Button();
            this.tcActLijst = new DraggableTabControl.DraggableTabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.cmActiviteit.SuspendLayout();
            this.cmTaak.SuspendLayout();
            this.tcActLijst.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmActiviteit
            // 
            this.cmActiviteit.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.verwijderToolStripMenuItem,
            this.hernoemToolStripMenuItem,
            this.eigenschappenToolStripMenuItem,
            this.sorteerTakenToolStripMenuItem,
            this.verwijderVoltooidToolStripMenuItem,
            this.verwijderAllesToolStripMenuItem,
            this.toolStripSeparator1,
            this.verbergToolStripMenuItem,
            this.toonverbergTabToolStripMenuItem,
            this.toolStripSeparator2,
            this.geagendeerdeTakenToolStripMenuItem,
            this.toolStripSeparator3,
            this.opslaanToolStripMenuItem});
            this.cmActiviteit.Name = "cmActiviteit";
            resources.ApplyResources(this.cmActiviteit, "cmActiviteit");
            // 
            // verwijderToolStripMenuItem
            // 
            this.verwijderToolStripMenuItem.Name = "verwijderToolStripMenuItem";
            resources.ApplyResources(this.verwijderToolStripMenuItem, "verwijderToolStripMenuItem");
            this.verwijderToolStripMenuItem.Click += new System.EventHandler(this.verwijderActiviteit);
            // 
            // hernoemToolStripMenuItem
            // 
            this.hernoemToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripTextBox1});
            this.hernoemToolStripMenuItem.Name = "hernoemToolStripMenuItem";
            resources.ApplyResources(this.hernoemToolStripMenuItem, "hernoemToolStripMenuItem");
            // 
            // toolStripTextBox1
            // 
            this.toolStripTextBox1.Name = "toolStripTextBox1";
            resources.ApplyResources(this.toolStripTextBox1, "toolStripTextBox1");
            this.toolStripTextBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.hernoemAct);
            // 
            // eigenschappenToolStripMenuItem
            // 
            this.eigenschappenToolStripMenuItem.Name = "eigenschappenToolStripMenuItem";
            resources.ApplyResources(this.eigenschappenToolStripMenuItem, "eigenschappenToolStripMenuItem");
            this.eigenschappenToolStripMenuItem.Click += new System.EventHandler(this.showProps);
            // 
            // sorteerTakenToolStripMenuItem
            // 
            this.sorteerTakenToolStripMenuItem.Name = "sorteerTakenToolStripMenuItem";
            resources.ApplyResources(this.sorteerTakenToolStripMenuItem, "sorteerTakenToolStripMenuItem");
            this.sorteerTakenToolStripMenuItem.Click += new System.EventHandler(this.sorteerTakenToolStripMenuItem_Click);
            // 
            // verwijderVoltooidToolStripMenuItem
            // 
            this.verwijderVoltooidToolStripMenuItem.Name = "verwijderVoltooidToolStripMenuItem";
            resources.ApplyResources(this.verwijderVoltooidToolStripMenuItem, "verwijderVoltooidToolStripMenuItem");
            this.verwijderVoltooidToolStripMenuItem.Click += new System.EventHandler(this.VerwijderVoltooid_Click);
            // 
            // verwijderAllesToolStripMenuItem
            // 
            this.verwijderAllesToolStripMenuItem.Name = "verwijderAllesToolStripMenuItem";
            resources.ApplyResources(this.verwijderAllesToolStripMenuItem, "verwijderAllesToolStripMenuItem");
            this.verwijderAllesToolStripMenuItem.Click += new System.EventHandler(this.VerwijderVoltooid_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            // 
            // verbergToolStripMenuItem
            // 
            this.verbergToolStripMenuItem.Name = "verbergToolStripMenuItem";
            resources.ApplyResources(this.verbergToolStripMenuItem, "verbergToolStripMenuItem");
            this.verbergToolStripMenuItem.Click += new System.EventHandler(this.verbergToolStripMenuItem_Click);
            // 
            // toonverbergTabToolStripMenuItem
            // 
            this.toonverbergTabToolStripMenuItem.Name = "toonverbergTabToolStripMenuItem";
            resources.ApplyResources(this.toonverbergTabToolStripMenuItem, "toonverbergTabToolStripMenuItem");
            this.toonverbergTabToolStripMenuItem.Click += new System.EventHandler(this.button1_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            resources.ApplyResources(this.toolStripSeparator2, "toolStripSeparator2");
            // 
            // geagendeerdeTakenToolStripMenuItem
            // 
            this.geagendeerdeTakenToolStripMenuItem.Name = "geagendeerdeTakenToolStripMenuItem";
            resources.ApplyResources(this.geagendeerdeTakenToolStripMenuItem, "geagendeerdeTakenToolStripMenuItem");
            this.geagendeerdeTakenToolStripMenuItem.Click += new System.EventHandler(this.geagendeerdeTakenToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            resources.ApplyResources(this.toolStripSeparator3, "toolStripSeparator3");
            // 
            // opslaanToolStripMenuItem
            // 
            this.opslaanToolStripMenuItem.Name = "opslaanToolStripMenuItem";
            resources.ApplyResources(this.opslaanToolStripMenuItem, "opslaanToolStripMenuItem");
            this.opslaanToolStripMenuItem.Click += new System.EventHandler(this.opslaanToolStripMenuItem_Click);
            // 
            // btNewAct
            // 
            resources.ApplyResources(this.btNewAct, "btNewAct");
            this.btNewAct.Image = global::TodoLijstje.Resource1.plus;
            this.btNewAct.Name = "btNewAct";
            this.btNewAct.UseVisualStyleBackColor = true;
            this.btNewAct.Click += new System.EventHandler(this.btNewAct_Click);
            // 
            // cmTaak
            // 
            this.cmTaak.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.verwijderToolStripMenuItem1,
            this.verplaatsToolStripMenuItem1});
            this.cmTaak.Name = "cmTaak";
            resources.ApplyResources(this.cmTaak, "cmTaak");
            // 
            // verwijderToolStripMenuItem1
            // 
            this.verwijderToolStripMenuItem1.Name = "verwijderToolStripMenuItem1";
            resources.ApplyResources(this.verwijderToolStripMenuItem1, "verwijderToolStripMenuItem1");
            this.verwijderToolStripMenuItem1.Click += new System.EventHandler(this.verwijderTaak);
            // 
            // verplaatsToolStripMenuItem1
            // 
            this.verplaatsToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bovenaanToolStripMenuItem1,
            this.naarBovenToolStripMenuItem1,
            this.naarOnderToolStripMenuItem1,
            this.onderaanToolStripMenuItem1});
            this.verplaatsToolStripMenuItem1.Name = "verplaatsToolStripMenuItem1";
            resources.ApplyResources(this.verplaatsToolStripMenuItem1, "verplaatsToolStripMenuItem1");
            // 
            // bovenaanToolStripMenuItem1
            // 
            this.bovenaanToolStripMenuItem1.Name = "bovenaanToolStripMenuItem1";
            resources.ApplyResources(this.bovenaanToolStripMenuItem1, "bovenaanToolStripMenuItem1");
            this.bovenaanToolStripMenuItem1.Click += new System.EventHandler(this.bovenaanToolStripMenuItem1_Click);
            // 
            // naarBovenToolStripMenuItem1
            // 
            this.naarBovenToolStripMenuItem1.Name = "naarBovenToolStripMenuItem1";
            resources.ApplyResources(this.naarBovenToolStripMenuItem1, "naarBovenToolStripMenuItem1");
            this.naarBovenToolStripMenuItem1.Click += new System.EventHandler(this.naarBovenToolStripMenuItem1_Click);
            // 
            // naarOnderToolStripMenuItem1
            // 
            this.naarOnderToolStripMenuItem1.Name = "naarOnderToolStripMenuItem1";
            resources.ApplyResources(this.naarOnderToolStripMenuItem1, "naarOnderToolStripMenuItem1");
            this.naarOnderToolStripMenuItem1.Click += new System.EventHandler(this.naarOnderToolStripMenuItem1_Click);
            // 
            // onderaanToolStripMenuItem1
            // 
            this.onderaanToolStripMenuItem1.Name = "onderaanToolStripMenuItem1";
            resources.ApplyResources(this.onderaanToolStripMenuItem1, "onderaanToolStripMenuItem1");
            this.onderaanToolStripMenuItem1.Click += new System.EventHandler(this.onderaanToolStripMenuItem1_Click);
            // 
            // btPausestart
            // 
            resources.ApplyResources(this.btPausestart, "btPausestart");
            this.btPausestart.Image = global::TodoLijstje.Resource1.play;
            this.btPausestart.Name = "btPausestart";
            this.btPausestart.UseVisualStyleBackColor = true;
            this.btPausestart.Click += new System.EventHandler(this.btPausestart_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.IncrCurrTijd);
            // 
            // cbAlwaysOnTop
            // 
            resources.ApplyResources(this.cbAlwaysOnTop, "cbAlwaysOnTop");
            this.cbAlwaysOnTop.Name = "cbAlwaysOnTop";
            this.cbAlwaysOnTop.UseVisualStyleBackColor = true;
            this.cbAlwaysOnTop.CheckedChanged += new System.EventHandler(this.changeAlwaysOnTop);
            // 
            // timer2
            // 
            this.timer2.Enabled = true;
            this.timer2.Interval = 60000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // btForceTick
            // 
            resources.ApplyResources(this.btForceTick, "btForceTick");
            this.btForceTick.Image = global::TodoLijstje.Resource1.klok;
            this.btForceTick.Name = "btForceTick";
            this.btForceTick.UseVisualStyleBackColor = true;
            this.btForceTick.Click += new System.EventHandler(this.btForceTick_Click);
            // 
            // tcActLijst
            // 
            this.tcActLijst.AllowDrop = true;
            resources.ApplyResources(this.tcActLijst, "tcActLijst");
            this.tcActLijst.Controls.Add(this.tabPage1);
            this.tcActLijst.Name = "tcActLijst";
            this.tcActLijst.SelectedIndex = 0;
            this.tcActLijst.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tcActLijst_MouseDown);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.webBrowser1);
            resources.ApplyResources(this.tabPage1, "tabPage1");
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // webBrowser1
            // 
            resources.ApplyResources(this.webBrowser1, "webBrowser1");
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Url = new System.Uri("", System.UriKind.Relative);
            // 
            // MainForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cbAlwaysOnTop);
            this.Controls.Add(this.btPausestart);
            this.Controls.Add(this.btNewAct);
            this.Controls.Add(this.btForceTick);
            this.Controls.Add(this.tcActLijst);
            this.Name = "MainForm";
            this.TopMost = true;
            this.MaximizedBoundsChanged += new System.EventHandler(this.Form1_Resize);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_Unload);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.OpenOpties);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.cmActiviteit.ResumeLayout(false);
            this.cmTaak.ResumeLayout(false);
            this.tcActLijst.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip cmActiviteit;
        private System.Windows.Forms.ToolStripMenuItem verwijderToolStripMenuItem;
        private System.Windows.Forms.Button btNewAct;
        private System.Windows.Forms.ContextMenuStrip cmTaak;
        private System.Windows.Forms.Button btPausestart;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripMenuItem verwijderToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem hernoemToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox1;
        private DraggableTabControl.DraggableTabControl tcActLijst;
        private System.Windows.Forms.ToolStripMenuItem verplaatsToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem bovenaanToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem naarBovenToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem naarOnderToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem onderaanToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toonverbergTabToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem eigenschappenToolStripMenuItem;
        private System.Windows.Forms.CheckBox cbAlwaysOnTop;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem geagendeerdeTakenToolStripMenuItem;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem opslaanToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sorteerTakenToolStripMenuItem;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.ToolStripMenuItem verbergToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem verwijderVoltooidToolStripMenuItem;
        private System.Windows.Forms.Button btForceTick;
        private System.Windows.Forms.ToolStripMenuItem verwijderAllesToolStripMenuItem;
    }
}

