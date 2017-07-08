namespace TodoLijstje
{
    partial class frmScheduledAction
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
            this.btOK = new System.Windows.Forms.Button();
            this.btApply = new System.Windows.Forms.Button();
            this.cbHerhaal = new System.Windows.Forms.GroupBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.mtbDaysBefore = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btWeekdays = new System.Windows.Forms.Button();
            this.cmWeekdays = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.miMa = new System.Windows.Forms.ToolStripMenuItem();
            this.miDi = new System.Windows.Forms.ToolStripMenuItem();
            this.miWo = new System.Windows.Forms.ToolStripMenuItem();
            this.miDo = new System.Windows.Forms.ToolStripMenuItem();
            this.miVr = new System.Windows.Forms.ToolStripMenuItem();
            this.miZa = new System.Windows.Forms.ToolStripMenuItem();
            this.miZo = new System.Windows.Forms.ToolStripMenuItem();
            this.label3 = new System.Windows.Forms.Label();
            this.udKeer = new System.Windows.Forms.NumericUpDown();
            this.mtbMJ = new System.Windows.Forms.MaskedTextBox();
            this.mtbDMJ = new System.Windows.Forms.MaskedTextBox();
            this.mtbUM = new System.Windows.Forms.MaskedTextBox();
            this.rbTijd = new System.Windows.Forms.RadioButton();
            this.rbWeek = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbAlertmsg = new System.Windows.Forms.TextBox();
            this.btDelete = new System.Windows.Forms.Button();
            this.udHours = new System.Windows.Forms.NumericUpDown();
            this.udMinutes = new System.Windows.Forms.NumericUpDown();
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.btNew = new System.Windows.Forms.Button();
            this.lvActions = new System.Windows.Forms.ListView();
            this.Taak = new System.Windows.Forms.ColumnHeader();
            this.cbHerhaal.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.cmWeekdays.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udKeer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udHours)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udMinutes)).BeginInit();
            this.SuspendLayout();
            // 
            // btOK
            // 
            this.btOK.Location = new System.Drawing.Point(351, 310);
            this.btOK.Name = "btOK";
            this.btOK.Size = new System.Drawing.Size(104, 23);
            this.btOK.TabIndex = 5;
            this.btOK.Text = "Sluiten";
            this.btOK.UseVisualStyleBackColor = true;
            this.btOK.Click += new System.EventHandler(this.btOK_Click);
            // 
            // btApply
            // 
            this.btApply.Enabled = false;
            this.btApply.Location = new System.Drawing.Point(204, 231);
            this.btApply.Name = "btApply";
            this.btApply.Size = new System.Drawing.Size(104, 23);
            this.btApply.TabIndex = 5;
            this.btApply.Text = "Toepassen";
            this.btApply.UseVisualStyleBackColor = true;
            this.btApply.Click += new System.EventHandler(this.btApply_Click);
            // 
            // cbHerhaal
            // 
            this.cbHerhaal.Controls.Add(this.checkBox1);
            this.cbHerhaal.Controls.Add(this.groupBox2);
            this.cbHerhaal.Controls.Add(this.label2);
            this.cbHerhaal.Controls.Add(this.label1);
            this.cbHerhaal.Controls.Add(this.tbAlertmsg);
            this.cbHerhaal.Controls.Add(this.btDelete);
            this.cbHerhaal.Controls.Add(this.btApply);
            this.cbHerhaal.Controls.Add(this.udHours);
            this.cbHerhaal.Controls.Add(this.udMinutes);
            this.cbHerhaal.Controls.Add(this.monthCalendar1);
            this.cbHerhaal.Location = new System.Drawing.Point(143, 12);
            this.cbHerhaal.Name = "cbHerhaal";
            this.cbHerhaal.Size = new System.Drawing.Size(312, 292);
            this.cbHerhaal.TabIndex = 6;
            this.cbHerhaal.TabStop = false;
            this.cbHerhaal.Text = "Eigenschappen";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(203, 45);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(63, 17);
            this.checkBox1.TabIndex = 8;
            this.checkBox1.Text = "Herhaal";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.mtbDaysBefore);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.btWeekdays);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.udKeer);
            this.groupBox2.Controls.Add(this.mtbMJ);
            this.groupBox2.Controls.Add(this.mtbDMJ);
            this.groupBox2.Controls.Add(this.mtbUM);
            this.groupBox2.Controls.Add(this.rbTijd);
            this.groupBox2.Controls.Add(this.rbWeek);
            this.groupBox2.Enabled = false;
            this.groupBox2.Location = new System.Drawing.Point(198, 45);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(109, 180);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            // 
            // mtbDaysBefore
            // 
            this.mtbDaysBefore.Enabled = false;
            this.mtbDaysBefore.Location = new System.Drawing.Point(77, 118);
            this.mtbDaysBefore.Name = "mtbDaysBefore";
            this.mtbDaysBefore.Size = new System.Drawing.Size(22, 20);
            this.mtbDaysBefore.TabIndex = 16;
            this.mtbDaysBefore.Text = "0";
            this.mtbDaysBefore.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.mtbDaysBefore.Leave += new System.EventHandler(this.mtbDaysBefore_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 121);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Dagen ervoor";
            // 
            // btWeekdays
            // 
            this.btWeekdays.ContextMenuStrip = this.cmWeekdays;
            this.btWeekdays.Enabled = false;
            this.btWeekdays.Location = new System.Drawing.Point(51, 89);
            this.btWeekdays.Name = "btWeekdays";
            this.btWeekdays.Size = new System.Drawing.Size(52, 23);
            this.btWeekdays.TabIndex = 15;
            this.btWeekdays.Text = "...";
            this.btWeekdays.UseVisualStyleBackColor = true;
            // 
            // cmWeekdays
            // 
            this.cmWeekdays.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miMa,
            this.miDi,
            this.miWo,
            this.miDo,
            this.miVr,
            this.miZa,
            this.miZo});
            this.cmWeekdays.Name = "cmWeekdays";
            this.cmWeekdays.Size = new System.Drawing.Size(139, 158);
            // 
            // miMa
            // 
            this.miMa.Name = "miMa";
            this.miMa.Size = new System.Drawing.Size(138, 22);
            this.miMa.Text = "Maandag";
            this.miMa.Click += new System.EventHandler(this.checkMe);
            // 
            // miDi
            // 
            this.miDi.Name = "miDi";
            this.miDi.Size = new System.Drawing.Size(138, 22);
            this.miDi.Text = "Dinsdag";
            this.miDi.Click += new System.EventHandler(this.checkMe);
            // 
            // miWo
            // 
            this.miWo.Name = "miWo";
            this.miWo.Size = new System.Drawing.Size(138, 22);
            this.miWo.Text = "Woensdag";
            this.miWo.Click += new System.EventHandler(this.checkMe);
            // 
            // miDo
            // 
            this.miDo.Name = "miDo";
            this.miDo.Size = new System.Drawing.Size(138, 22);
            this.miDo.Text = "Donderdag";
            this.miDo.Click += new System.EventHandler(this.checkMe);
            // 
            // miVr
            // 
            this.miVr.Name = "miVr";
            this.miVr.Size = new System.Drawing.Size(138, 22);
            this.miVr.Text = "Vrijdag";
            this.miVr.Click += new System.EventHandler(this.checkMe);
            // 
            // miZa
            // 
            this.miZa.Name = "miZa";
            this.miZa.Size = new System.Drawing.Size(138, 22);
            this.miZa.Text = "Zaterdag";
            this.miZa.Click += new System.EventHandler(this.checkMe);
            // 
            // miZo
            // 
            this.miZo.Name = "miZo";
            this.miZo.Size = new System.Drawing.Size(138, 22);
            this.miZo.Text = "Zondag";
            this.miZo.Click += new System.EventHandler(this.checkMe);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 156);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "keren:";
            // 
            // udKeer
            // 
            this.udKeer.Location = new System.Drawing.Point(51, 154);
            this.udKeer.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.udKeer.Name = "udKeer";
            this.udKeer.Size = new System.Drawing.Size(41, 20);
            this.udKeer.TabIndex = 13;
            this.udKeer.Value = new decimal(new int[] {
            99,
            0,
            0,
            0});
            // 
            // mtbMJ
            // 
            this.mtbMJ.Enabled = false;
            this.mtbMJ.Location = new System.Drawing.Point(11, 91);
            this.mtbMJ.Mask = "00/00";
            this.mtbMJ.Name = "mtbMJ";
            this.mtbMJ.Size = new System.Drawing.Size(34, 20);
            this.mtbMJ.TabIndex = 12;
            this.mtbMJ.Text = "0000";
            this.mtbMJ.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // mtbDMJ
            // 
            this.mtbDMJ.Location = new System.Drawing.Point(11, 42);
            this.mtbDMJ.Mask = "00/00/00";
            this.mtbDMJ.Name = "mtbDMJ";
            this.mtbDMJ.Size = new System.Drawing.Size(49, 20);
            this.mtbDMJ.TabIndex = 12;
            this.mtbDMJ.Text = "010000";
            this.mtbDMJ.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // mtbUM
            // 
            this.mtbUM.Location = new System.Drawing.Point(66, 42);
            this.mtbUM.Mask = "00:00";
            this.mtbUM.Name = "mtbUM";
            this.mtbUM.Size = new System.Drawing.Size(37, 20);
            this.mtbUM.TabIndex = 11;
            this.mtbUM.Text = "0000";
            this.mtbUM.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.mtbUM.ValidatingType = typeof(System.DateTime);
            // 
            // rbTijd
            // 
            this.rbTijd.AutoSize = true;
            this.rbTijd.Checked = true;
            this.rbTijd.Location = new System.Drawing.Point(6, 19);
            this.rbTijd.Name = "rbTijd";
            this.rbTijd.Size = new System.Drawing.Size(99, 17);
            this.rbTijd.TabIndex = 10;
            this.rbTijd.TabStop = true;
            this.rbTijd.Text = "Vaste tussentijd";
            this.rbTijd.UseVisualStyleBackColor = true;
            this.rbTijd.CheckedChanged += new System.EventHandler(this.rbTijd_CheckedChanged);
            // 
            // rbWeek
            // 
            this.rbWeek.AutoSize = true;
            this.rbWeek.Location = new System.Drawing.Point(6, 68);
            this.rbWeek.Name = "rbWeek";
            this.rbWeek.Size = new System.Drawing.Size(99, 17);
            this.rbWeek.TabIndex = 9;
            this.rbWeek.Text = "Vaste weekdag";
            this.rbWeek.UseVisualStyleBackColor = true;
            this.rbWeek.CheckedChanged += new System.EventHandler(this.rbWeek_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 220);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Tijdstip";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Bericht";
            // 
            // tbAlertmsg
            // 
            this.tbAlertmsg.Location = new System.Drawing.Point(55, 19);
            this.tbAlertmsg.Name = "tbAlertmsg";
            this.tbAlertmsg.Size = new System.Drawing.Size(251, 20);
            this.tbAlertmsg.TabIndex = 7;
            this.tbAlertmsg.TextChanged += new System.EventHandler(this.tbAlertmsg_TextChanged);
            // 
            // btDelete
            // 
            this.btDelete.Enabled = false;
            this.btDelete.Location = new System.Drawing.Point(204, 260);
            this.btDelete.Name = "btDelete";
            this.btDelete.Size = new System.Drawing.Size(104, 23);
            this.btDelete.TabIndex = 5;
            this.btDelete.Text = "Verwijderen";
            this.btDelete.UseVisualStyleBackColor = true;
            this.btDelete.Click += new System.EventHandler(this.btDelete_Click);
            // 
            // udHours
            // 
            this.udHours.Location = new System.Drawing.Point(55, 218);
            this.udHours.Maximum = new decimal(new int[] {
            23,
            0,
            0,
            0});
            this.udHours.Name = "udHours";
            this.udHours.Size = new System.Drawing.Size(44, 20);
            this.udHours.TabIndex = 6;
            // 
            // udMinutes
            // 
            this.udMinutes.Location = new System.Drawing.Point(105, 218);
            this.udMinutes.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.udMinutes.Name = "udMinutes";
            this.udMinutes.Size = new System.Drawing.Size(44, 20);
            this.udMinutes.TabIndex = 5;
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.Location = new System.Drawing.Point(12, 51);
            this.monthCalendar1.MaxSelectionCount = 30;
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 4;
            this.monthCalendar1.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.SetButton);
            // 
            // btNew
            // 
            this.btNew.Location = new System.Drawing.Point(9, 281);
            this.btNew.Name = "btNew";
            this.btNew.Size = new System.Drawing.Size(125, 23);
            this.btNew.TabIndex = 5;
            this.btNew.Text = "Nieuw";
            this.btNew.UseVisualStyleBackColor = true;
            this.btNew.Click += new System.EventHandler(this.btNew_Click);
            // 
            // lvActions
            // 
            this.lvActions.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Taak});
            this.lvActions.HideSelection = false;
            this.lvActions.LabelWrap = false;
            this.lvActions.Location = new System.Drawing.Point(14, 12);
            this.lvActions.MultiSelect = false;
            this.lvActions.Name = "lvActions";
            this.lvActions.Size = new System.Drawing.Size(120, 263);
            this.lvActions.TabIndex = 7;
            this.lvActions.UseCompatibleStateImageBehavior = false;
            this.lvActions.View = System.Windows.Forms.View.Details;
            this.lvActions.SelectedIndexChanged += new System.EventHandler(this.SetTaskControls);
            // 
            // Taak
            // 
            this.Taak.Text = "Taak";
            this.Taak.Width = 116;
            // 
            // frmScheduledAction
            // 
            this.AcceptButton = this.btOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(466, 345);
            this.Controls.Add(this.lvActions);
            this.Controls.Add(this.cbHerhaal);
            this.Controls.Add(this.btNew);
            this.Controls.Add(this.btOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmScheduledAction";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Herinneringen";
            this.Load += new System.EventHandler(this.frmScheduledAction_Load);
            this.cbHerhaal.ResumeLayout(false);
            this.cbHerhaal.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.cmWeekdays.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.udKeer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udHours)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udMinutes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btOK;
        private System.Windows.Forms.Button btApply;
        private System.Windows.Forms.GroupBox cbHerhaal;
        private System.Windows.Forms.TextBox tbAlertmsg;
        private System.Windows.Forms.Button btDelete;
        private System.Windows.Forms.NumericUpDown udHours;
        private System.Windows.Forms.NumericUpDown udMinutes;
        private System.Windows.Forms.MonthCalendar monthCalendar1;
        private System.Windows.Forms.Button btNew;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListView lvActions;
        private System.Windows.Forms.ColumnHeader Taak;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.MaskedTextBox mtbDMJ;
        private System.Windows.Forms.MaskedTextBox mtbUM;
        private System.Windows.Forms.RadioButton rbTijd;
        private System.Windows.Forms.RadioButton rbWeek;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown udKeer;
        private System.Windows.Forms.MaskedTextBox mtbMJ;
        private System.Windows.Forms.Button btWeekdays;
        private System.Windows.Forms.ContextMenuStrip cmWeekdays;
        private System.Windows.Forms.ToolStripMenuItem miMa;
        private System.Windows.Forms.ToolStripMenuItem miDi;
        private System.Windows.Forms.ToolStripMenuItem miWo;
        private System.Windows.Forms.ToolStripMenuItem miDo;
        private System.Windows.Forms.ToolStripMenuItem miVr;
        private System.Windows.Forms.ToolStripMenuItem miZa;
        private System.Windows.Forms.ToolStripMenuItem miZo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox mtbDaysBefore;
    }
}