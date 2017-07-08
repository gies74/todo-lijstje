using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TodoLijstje
{
    public partial class frmActVis : Form
    {
        public frmActVis()
        {
            InitializeComponent();
        }

        public void clearList()
        {
            checkedListBox1.Items.Clear();
        }

        private void btOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Hide();
        }

        public void addBox(string actName, bool visible)
        {

            checkedListBox1.Items.Add(actName, visible);
        }

        public bool isVisible(string actName)
        {
            if (checkedListBox1.Items.Contains(actName))
                return checkedListBox1.GetItemChecked(checkedListBox1.Items.IndexOf(actName));
            else
                return false;
        }
    }
}