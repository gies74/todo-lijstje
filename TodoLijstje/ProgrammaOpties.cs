using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;

namespace TodoLijstje
{
    public partial class frmOptions : Form
    {
        public frmOptions()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RegistryKey regKey;
            regKey = Registry.CurrentUser.OpenSubKey(@"Software\ToDo", true);
            regKey.SetValue("LoadCompleted", Convert.ToString(cbLoadCompleted.Checked));
            regKey = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run", true);
            if (cbAutostart.Checked)
                regKey.SetValue("ToDo", "\"" + Application.ExecutablePath + "\"");
            else
            {
                regKey.DeleteValue("ToDo", false);
            }
            
            this.DialogResult = DialogResult.OK;
            this.Hide();
        }

        private void ReadRegistry(object sender, EventArgs e)
        {
            RegistryKey regKey;
            regKey = Registry.CurrentUser.OpenSubKey(@"Software\ToDo");
            if (regKey == null)
            {
                regKey = Registry.CurrentUser.CreateSubKey(@"Software\ToDo",RegistryKeyPermissionCheck.ReadWriteSubTree);
                regKey.SetValue("LoadCompleted", "False");
            }
            cbLoadCompleted.Checked = Convert.ToBoolean(regKey.GetValue("LoadCompleted"));
            regKey = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run");
            cbAutostart.Checked = !(regKey.GetValue("ToDo") == null);
        }
    }
}