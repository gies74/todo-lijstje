namespace TodoLijstje
{
    partial class frmOptions
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
            this.cbLoadCompleted = new System.Windows.Forms.CheckBox();
            this.cbAutostart = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cbLoadCompleted
            // 
            this.cbLoadCompleted.AutoSize = true;
            this.cbLoadCompleted.Location = new System.Drawing.Point(12, 35);
            this.cbLoadCompleted.Name = "cbLoadCompleted";
            this.cbLoadCompleted.Size = new System.Drawing.Size(126, 17);
            this.cbLoadCompleted.TabIndex = 0;
            this.cbLoadCompleted.Text = "Laad voltooide taken";
            this.cbLoadCompleted.UseVisualStyleBackColor = true;
            // 
            // cbAutostart
            // 
            this.cbAutostart.AutoSize = true;
            this.cbAutostart.Location = new System.Drawing.Point(12, 12);
            this.cbAutostart.Name = "cbAutostart";
            this.cbAutostart.Size = new System.Drawing.Size(123, 17);
            this.cbAutostart.TabIndex = 1;
            this.cbAutostart.Text = "Start automatisch op";
            this.cbAutostart.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(39, 65);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(79, 27);
            this.button1.TabIndex = 2;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmOptions
            // 
            this.AcceptButton = this.button1;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(157, 104);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cbAutostart);
            this.Controls.Add(this.cbLoadCompleted);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmOptions";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Opties";
            this.Load += new System.EventHandler(this.ReadRegistry);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox cbLoadCompleted;
        private System.Windows.Forms.CheckBox cbAutostart;
        private System.Windows.Forms.Button button1;
    }
}