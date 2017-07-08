using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TodoLijstje
{
    public partial class frmActProps : Form
    {
        public Activiteit m_actCurr;
        public long m_timespentBeforeToday;

        public frmActProps()
        {
            InitializeComponent();
        }

        public void setNaam(string desc)
        {
            label4.Text = desc;
        }

        private void button1_Click(object sender, EventArgs e)
        {
                m_actCurr.SetTimespent(dateTimePicker1.Value, getTicks());
                m_actCurr.totalAvailable = getTicksAvail();
                button1.Enabled = false;
        }

        public void setTicks(long ticks)
        {
            FillTbxs(ticks, textBox10, textBox11, textBox12);
        }
        public void setTicksAvail(long ticks)
        {
            FillTbxs(ticks, textBox7, textBox8, textBox9);
        }

        public void FillTbxs(long ticks, TextBox tb1, TextBox tb2, TextBox tb3)
        {
            long mtime, iSecs, iMins, iHours;
            iSecs = System.Convert.ToInt32(ticks % 60);
            iMins = System.Convert.ToInt32(Math.Floor(System.Convert.ToDouble(ticks) / 60L));
            mtime = (long)iMins;
            iMins = System.Convert.ToInt32(mtime % 60);
            iHours = System.Convert.ToInt32(Math.Floor(System.Convert.ToDouble(mtime) / 60L));
            tb1.Text = String.Format("{0:00}", iHours);
            tb2.Text = String.Format("{0:00}", iMins);
            tb3.Text = String.Format("{0:00}", iSecs);
        }

        public long getTicks()
        {
            return ExtractTbxs(textBox10, textBox11, textBox12);
        }

        public long getTicksAvail()
        {
            return ExtractTbxs(textBox7, textBox8, textBox9);
        }

        public long ExtractTbxs(TextBox tb1, TextBox tb2, TextBox tb3)
        {
            if (tb1.Text.Equals(String.Empty) || tb2.Text.Equals(String.Empty) || tb3.Text.Equals(String.Empty))
                return 0;
            long iSecs, iMins, iHours;
            iSecs = Convert.ToInt64(tb3.Text);
            iMins = Convert.ToInt64(tb2.Text);
            iHours = Convert.ToInt64(tb1.Text);
            return iSecs + 60 * (iMins + 60 * iHours);
        }


        private void formLoad(object sender, EventArgs e)
        {
            setTicksAvail(m_actCurr.totalAvailable);
            setTimeBoxes();
        }

        private void setTimeBoxes()
        {
            m_timespentBeforeToday = 0L;
            foreach (long dayTicks in this.m_actCurr.m_Hash.Values)
                m_timespentBeforeToday += dayTicks;
            m_timespentBeforeToday -= m_actCurr.GetTimespent(dateTimePicker1.Value);
            setTicks(m_actCurr.GetTimespent(dateTimePicker1.Value));

            FillTbxs(m_timespentBeforeToday, textBox1, textBox2, textBox3);

            computeVals(null, null);
        }

        private void computeVals(object sender, EventArgs e)
        {
            long today, available, diff;
            today = getTicks();
            available = getTicksAvail();
            diff = available - (today + m_timespentBeforeToday);
            FillTbxs(diff, textBox4, textBox5, textBox6);
            if (sender != null || e != null)
                button1.Enabled = true;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            setTimeBoxes();
            button1.Enabled = false;
        }

        private void computeVals(object sender, KeyPressEventArgs e)
        {
            long today, available, diff;
            today = getTicks();
            available = getTicksAvail();
            diff = available - (today + m_timespentBeforeToday);
            FillTbxs(diff, textBox4, textBox5, textBox6);
            if (sender != null || e != null)
                button1.Enabled = true;

        }

        private void CheckValue(object sender, KeyEventArgs e)
        {
            if (e != null) // 8 46 37 39
                    e.SuppressKeyPress = !((e.KeyValue >= 48 && e.KeyValue <= 59) || e.KeyValue == 8 || e.KeyValue == 37 || e.KeyValue == 39 || e.KeyValue == 46);
        }

        private void CheckEmpty(object sender, EventArgs e)
        {
            if (sender != null)
            {
                TextBox tb = sender as TextBox;
                if (tb.Text == "")
                    tb.Text = "00";
                else if (tb.Text.Length == 1)
                    tb.Text = "0" + tb.Text;
            }
        }

    }
}