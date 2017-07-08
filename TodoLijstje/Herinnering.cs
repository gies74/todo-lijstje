using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TodoLijstje
{
    public partial class Herinnering : Form
    {
        public bool RemoveReminder
        {
            set { cbRemove.Checked = value; }
            get { return cbRemove.Checked; }
        }

        public Herinnering()
        {
            InitializeComponent();
        }

        private void TekenLijn(object sender, PaintEventArgs e)
        {
            Pen aPen = new Pen(new SolidBrush(Color.Red));
            aPen.Width = 5;
            e.Graphics.DrawLine(aPen, new Point(15, 15), new Point(this.Width - 15, 15));
            e.Graphics.DrawLine(aPen, new Point(15, 15), new Point(15, this.Height - 15));
            e.Graphics.DrawLine(aPen, new Point(this.Width - 15, 15), new Point(this.Width - 15, this.Height - 15));
            e.Graphics.DrawLine(aPen, new Point(15, this.Height - 15), new Point(this.Width - 15, this.Height - 15));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hide();
        }

    }
}