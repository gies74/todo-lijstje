namespace TodoLijstje
{
    partial class frmActProps
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox10 = new System.Windows.Forms.TextBox();
            this.textBox11 = new System.Windows.Forms.TextBox();
            this.textBox12 = new System.Windows.Forms.TextBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(2, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Buiten deze dag besteed";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(45, 130);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Beschikbare tijd";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(97, 155);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Over";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(45, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(167, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "Omschrijving activiteit";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(133, 76);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(33, 20);
            this.textBox1.TabIndex = 4;
            this.textBox1.TabStop = false;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(172, 76);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(33, 20);
            this.textBox2.TabIndex = 4;
            this.textBox2.TabStop = false;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(211, 76);
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(33, 20);
            this.textBox3.TabIndex = 4;
            this.textBox3.TabStop = false;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(133, 152);
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            this.textBox4.Size = new System.Drawing.Size(33, 20);
            this.textBox4.TabIndex = 4;
            this.textBox4.TabStop = false;
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(172, 152);
            this.textBox5.Name = "textBox5";
            this.textBox5.ReadOnly = true;
            this.textBox5.Size = new System.Drawing.Size(33, 20);
            this.textBox5.TabIndex = 4;
            this.textBox5.TabStop = false;
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(211, 152);
            this.textBox6.Name = "textBox6";
            this.textBox6.ReadOnly = true;
            this.textBox6.Size = new System.Drawing.Size(33, 20);
            this.textBox6.TabIndex = 4;
            this.textBox6.TabStop = false;
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(133, 127);
            this.textBox7.MaxLength = 2;
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(33, 20);
            this.textBox7.TabIndex = 4;
            this.textBox7.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CheckValue);
            this.textBox7.Leave += new System.EventHandler(this.CheckEmpty);
            this.textBox7.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.computeVals);
            // 
            // textBox8
            // 
            this.textBox8.Location = new System.Drawing.Point(172, 127);
            this.textBox8.MaxLength = 2;
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(33, 20);
            this.textBox8.TabIndex = 5;
            this.textBox8.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CheckValue);
            this.textBox8.Leave += new System.EventHandler(this.CheckEmpty);
            this.textBox8.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.computeVals);
            // 
            // textBox9
            // 
            this.textBox9.Location = new System.Drawing.Point(211, 127);
            this.textBox9.Name = "textBox9";
            this.textBox9.ReadOnly = true;
            this.textBox9.Size = new System.Drawing.Size(33, 20);
            this.textBox9.TabIndex = 6;
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Location = new System.Drawing.Point(172, 190);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "Toepassen";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Location = new System.Drawing.Point(91, 190);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 8;
            this.button2.Text = "Sluiten";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(36, 104);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Deze dag besteed";
            // 
            // textBox10
            // 
            this.textBox10.Location = new System.Drawing.Point(133, 101);
            this.textBox10.MaxLength = 2;
            this.textBox10.Name = "textBox10";
            this.textBox10.Size = new System.Drawing.Size(33, 20);
            this.textBox10.TabIndex = 1;
            this.textBox10.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CheckValue);
            this.textBox10.Leave += new System.EventHandler(this.CheckEmpty);
            this.textBox10.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.computeVals);
            // 
            // textBox11
            // 
            this.textBox11.Location = new System.Drawing.Point(172, 101);
            this.textBox11.MaxLength = 2;
            this.textBox11.Name = "textBox11";
            this.textBox11.Size = new System.Drawing.Size(33, 20);
            this.textBox11.TabIndex = 2;
            this.textBox11.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CheckValue);
            this.textBox11.Leave += new System.EventHandler(this.CheckEmpty);
            this.textBox11.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.computeVals);
            // 
            // textBox12
            // 
            this.textBox12.Location = new System.Drawing.Point(211, 101);
            this.textBox12.Name = "textBox12";
            this.textBox12.ReadOnly = true;
            this.textBox12.Size = new System.Drawing.Size(33, 20);
            this.textBox12.TabIndex = 3;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(15, 41);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(229, 20);
            this.dateTimePicker1.TabIndex = 9;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // frmActProps
            // 
            this.AcceptButton = this.button1;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.button2;
            this.ClientSize = new System.Drawing.Size(256, 222);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox9);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.textBox12);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox8);
            this.Controls.Add(this.textBox11);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox7);
            this.Controls.Add(this.textBox10);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmActProps";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Tijdbudget";
            this.Load += new System.EventHandler(this.formLoad);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.TextBox textBox9;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox10;
        private System.Windows.Forms.TextBox textBox11;
        private System.Windows.Forms.TextBox textBox12;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
    }
}