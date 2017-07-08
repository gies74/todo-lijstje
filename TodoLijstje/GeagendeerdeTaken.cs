using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TodoLijstje
{
    public partial class frmScheduledAction : Form
    {
        internal SortedDictionary<string, ScheduledAction> m_scheduledActions;

        public void RemoveSA(string key)
        {
            m_scheduledActions.Remove(key);
            if (lvActions.SelectedItems.Count > 0 && lvActions.SelectedItems[0].Tag.ToString() == key)
            {
                lvActions.Items.Remove(lvActions.SelectedItems[0]);
                btNew_Click(null, null);
            }
            else
            {
                foreach (ListViewItem lvi in lvActions.Items)
                {
                    if (lvi.Tag.ToString() == key)
                    {
                        lvActions.Items.Remove(lvi);
                        break;
                    }
                }
            }
        }


        public frmScheduledAction()
        {
            InitializeComponent();
            m_scheduledActions = new SortedDictionary<string, ScheduledAction>();
        }

        private void frmScheduledAction_Load(object sender, EventArgs e)
        {
            ListViewItem lvi;
            lvActions.Items.Clear();
            ScheduledAction saCurr;
            foreach (string saKey in m_scheduledActions.Keys)
            {
                saCurr = m_scheduledActions[saKey];
                lvi = new ListViewItem(saCurr.alertmsg);
                lvi.Tag = saKey;
                if (saCurr.hasbeenfired)
                    lvi.ForeColor = Color.Red;
                this.lvActions.Items.Add(lvi);
            }
            btNew_Click(sender, e);
        }

        private void btOK_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void SetTaskControls(object sender, EventArgs e)
        {
            ScheduledAction saCurr;
            DateTime dt;
            int dow;
            string[] per;
            char[] sep = new char[1];
            int i;
            sep[0] = ' ';

            if (lvActions.SelectedItems.Count == 0)
            {
                btDelete.Enabled = false;
                btNew_Click(sender, e);
                return;
            }
            btDelete.Enabled = true;
            mtbDaysBefore.Enabled = false;
            btDelete.Enabled = true;
            i = lvActions.SelectedIndices[0];
            saCurr = m_scheduledActions[(string)lvActions.Items[i].Tag];
            tbAlertmsg.Text = saCurr.alertmsg;
            dt = new DateTime(saCurr.fire);
            monthCalendar1.RemoveAllBoldedDates();
            monthCalendar1.AddBoldedDate(dt.Date);
            // this code is really stupid, but it helps to show the bolded date!
            monthCalendar1.SetDate(dt.Date.AddYears(1));
            monthCalendar1.SetDate(dt.Date);
            // end stupid code
            udHours.Value = dt.Hour;
            udMinutes.Value = dt.Minute;
            miMa.Checked = miDi.Checked = miWo.Checked = miDo.Checked = miVr.Checked = miZa.Checked = miZo.Checked = false;
            btWeekdays.Text = "...";
            mtbDMJ.Text = "01-00-00";
            mtbUM.Text = "00:00";
            mtbMJ.Text = "01-00";
            udKeer.Value = 99;
            //monthCalendar1.SetDate(dt.Date);
            if (saCurr.repeat)
            {
                checkBox1.Checked = true;
                if (saCurr.repeattype.Equals("period"))
                {
                    rbTijd.Checked = true;
                    per = saCurr.period.Split(sep);
                    mtbDMJ.Text = per[0];
                    mtbUM.Text = per[1];

                }
                else if (saCurr.repeattype.Equals("weekday"))
                {
                    rbWeek.Checked = true;
                    per = saCurr.period.Split(sep);
                    dt = dt.AddDays(Convert.ToInt32(per[4]));
                    mtbMJ.Text = per[3];
                    // dt2: first day of the month
                    DateTime dtFirstInMonth = new DateTime(dt.Year, dt.Month, 1);
                    DateTime dtS, dtE;
                    if (per[0].Equals("first"))
                    {
                        dtS = dtFirstInMonth; //.AddDays(Convert.ToInt32(per[4]));
                        dtE = dt.Date;
                        btWeekdays.Text = ">> " + per[1];
                        monthCalendar1.SetSelectionRange(dtS, dtE);
                    }
                    else
                    {
                        // dtE last day of the month
                        dtS = dt; // .Date.AddDays(Convert.ToInt32(per[4]));
                        dtE = dtFirstInMonth.AddMonths(1).AddDays(-1);
                        btWeekdays.Text = per[1] + " <<";
                        monthCalendar1.SetSelectionRange(dtS, dtE);
                    }
                    mtbDaysBefore.Text = per[4];
                    mtbDaysBefore.Enabled = true;
                    dow = Convert.ToInt32(per[2]);
                    miMa.Checked = Convert.ToBoolean(dow & 0x0001);
                    miDi.Checked = Convert.ToBoolean(dow & 0x0002);
                    miWo.Checked = Convert.ToBoolean(dow & 0x0004);
                    miDo.Checked = Convert.ToBoolean(dow & 0x0008);
                    miVr.Checked = Convert.ToBoolean(dow & 0x0010);
                    miZa.Checked = Convert.ToBoolean(dow & 0x0020);
                    miZo.Checked = Convert.ToBoolean(dow & 0x0040);
                }
                udKeer.Value = saCurr.times;
            }
            else
                checkBox1.Checked = false;
        }

        private void btNew_Click(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            lvActions.SelectedItems.Clear();
            tbAlertmsg.Text = String.Empty;
            monthCalendar1.SetDate(dt.Date);
            udHours.Value = dt.Hour;
            udMinutes.Value = dt.Minute;
            checkBox1.Checked = false;
            miMa.Checked = miDi.Checked = miWo.Checked = miDo.Checked = miVr.Checked = miZa.Checked = miZo.Checked = false;
            btWeekdays.Text = "...";
            mtbDMJ.Text = "01-00-00";
            mtbUM.Text = "00:00";
            mtbMJ.Text = "01-00";
            mtbDaysBefore.Text = "00";
            udKeer.Value = 99;
        }

        private void tbAlertmsg_TextChanged(object sender, EventArgs e)
        {
            btApply.Enabled = !tbAlertmsg.Text.Equals(String.Empty);
        }

        private void btApply_Click(object sender, EventArgs e)
        {
            ScheduledAction saTmp, saCurr = new ScheduledAction();
            DateTime dt;
            ListViewItem lvi;
            int i;
            string lastfirst;
            int dow;
            if (checkBox1.Checked && rbWeek.Checked && btWeekdays.Text.Contains(">>"))
                dt = new DateTime(monthCalendar1.SelectionEnd.Ticks);
            else
                dt = new DateTime(monthCalendar1.SelectionStart.Ticks);
            dt = dt.AddHours(Convert.ToDouble(udHours.Value));
            dt = dt.AddMinutes(Convert.ToDouble(udMinutes.Value));
            saCurr.repeat = checkBox1.Checked;
            if (checkBox1.Checked)
            {
                if (udKeer.Value == 0)
                {
                    MessageBox.Show("Nul keer herhalen kan niet.", "Fout", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (rbTijd.Checked)
                {
                    if (mtbDMJ.Text.Contains(" ") || mtbDMJ.Text.Length!=8 || mtbUM.Text.Contains(" ") || mtbUM.Text.Length!=5 || mtbDMJ.Text.Equals("00-00-00") && mtbUM.Text.Equals("00:00"))
                    {
                        MessageBox.Show("De tussenliggende tijd mag geen underscores bevatten en moet minimaal een minuut zijn.", "Fout", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    saCurr.repeattype = "period";
                    saCurr.period = mtbDMJ.Text + " " + mtbUM.Text;
                }
                else if (rbWeek.Checked)
                {
                    if (mtbMJ.Text.Contains(" ") || mtbMJ.Text.Length!=5 || mtbMJ.Text.Equals("00-00"))
                    {
                        MessageBox.Show("De tussenliggende tijd mag geen underscores bevatten en moet minimaal een maand zijn.", "Fout", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (Convert.ToInt32(mtbDaysBefore.Text) >= 32)
                    {
                        MessageBox.Show("Dagen ervoor moet kleiner gelijk 31 zijn.", "Fout", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    saCurr.repeattype = "weekday";
                    dow = 0x0000;
                    if (miMa.Checked) dow |= 0x0001;
                    if (miDi.Checked) dow |= 0x0002;
                    if (miWo.Checked) dow |= 0x0004;
                    if (miDo.Checked) dow |= 0x0008;
                    if (miVr.Checked) dow |= 0x0010;
                    if (miZa.Checked) dow |= 0x0020;
                    if (miZo.Checked) dow |= 0x0040;
                    if (btWeekdays.Text.Equals("...") || dow == 0)
                    {
                        MessageBox.Show("Trek een periode vanaf begin/eind van de maand en kies 1 of meer weekdagen via contextmenu van de knop.", "Fout", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (btWeekdays.Text.Contains("<<"))
                    {
                        lastfirst = "last ";
                        lastfirst += btWeekdays.Text.Substring(0, 1);
                    }
                    else
                    {
                        lastfirst = "first ";
                        lastfirst += btWeekdays.Text.Substring(btWeekdays.Text.Length-1);
                    }
                    saCurr.period = lastfirst + " " + dow.ToString() + " " + mtbMJ.Text + " " + mtbDaysBefore.Text;
                    dt = dt.AddDays(-1 * Convert.ToInt32(mtbDaysBefore.Text));
                }
                saCurr.times = Convert.ToInt32(udKeer.Value);
            }
            saCurr.fire = dt.Ticks;
            saCurr.alertmsg = tbAlertmsg.Text;
            if (lvActions.SelectedItems.Count == 0)
            {
                // new alert
                saCurr.sGUID = Guid.NewGuid().ToString();

                int k = 1;
                string key;
                do
                {
                    key = saCurr.fire.ToString() + "_" + k.ToString();
                    k++;
                } while (m_scheduledActions.ContainsKey(key));

                m_scheduledActions.Add(key, saCurr);
                lvi = new ListViewItem(tbAlertmsg.Text);
                lvi.Tag = key;
                lvActions.Items.Add(lvi);
                lvi.Selected = true;
            }
            else
            {
                // update of existing alert
                lvActions.Items[lvActions.SelectedIndices[0]].Text = tbAlertmsg.Text;
                string key = (string)lvActions.SelectedItems[0].Tag;
                //saTmp = m_scheduledActions[key];
                //saCurr.sGUID = saTmp.sGUID;
                m_scheduledActions[key] = saCurr;
            }
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            string key = (string)lvActions.SelectedItems[0].Tag;
            RemoveSA(key);
            // lvActions.Items[lvActions.SelectedIndices[0]].Remove();
            btDelete.Enabled = (lvActions.SelectedItems.Count > 0);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            groupBox2.Enabled = checkBox1.Checked;
        }

        private void rbTijd_CheckedChanged(object sender, EventArgs e)
        {
            mtbDMJ.Enabled = mtbUM.Enabled = rbTijd.Checked;
        }

        private void rbWeek_CheckedChanged(object sender, EventArgs e)
        {
            btWeekdays.Enabled = mtbMJ.Enabled = rbWeek.Checked;
        }

        private void SetButton(object sender, DateRangeEventArgs e)
        {
            DateTime cursor;
            int cnt=1;
            miMa.Checked = miDi.Checked = miWo.Checked = miDo.Checked = miVr.Checked = miZa.Checked = miZo.Checked = false;
            if (e.Start.Month == e.End.Month && (e.Start.Day == 1 ^ (e.End.AddDays(1).Day == 1)))
            {
                mtbDaysBefore.Enabled = true;
                if (e.Start.Day == 1)
                {
                    cursor = new DateTime(e.Start.Ticks);
                    while (!cursor.Date.Equals(e.End.Date))
                    {
                        if (cursor.DayOfWeek.CompareTo(e.End.DayOfWeek) == 0)
                            cnt++;
                        cursor = cursor.AddDays(1);
                    }
                    btWeekdays.Text = ">> " + cnt.ToString();
                    cursor = new DateTime(e.End.Ticks);
                }
                else
                {
                    cursor = new DateTime(e.End.Ticks);
                    while (!cursor.Date.Equals(e.Start.Date))
                    {
                        if (cursor.DayOfWeek.CompareTo(e.Start.DayOfWeek) == 0)
                            cnt++;
                        cursor = cursor.AddDays(-1);
                    }
                    btWeekdays.Text = cnt.ToString() + " <<";
                    cursor = new DateTime(e.Start.Ticks);
                    // e.Start.DayOfWeek.ToString().Substring(0, 2);
                }
                switch (cursor.DayOfWeek)
                {
                    case DayOfWeek.Monday:
                        miMa.Checked = true;
                        break;
                    case DayOfWeek.Tuesday:
                        miDi.Checked = true;
                        break;
                    case DayOfWeek.Wednesday:
                        miWo.Checked = true;
                        break;
                    case DayOfWeek.Thursday:
                        miDo.Checked = true;
                        break;
                    case DayOfWeek.Friday:
                        miVr.Checked = true;
                        break;
                    case DayOfWeek.Saturday:
                        miZa.Checked = true;
                        break;
                    default:
                        miZo.Checked = true;
                        break;
                }
            }
            else
            {
                mtbDaysBefore.Enabled = false;
                btWeekdays.Text = "...";
            }
        }

        private void checkMe(object sender, EventArgs e)
        {
            ToolStripMenuItem mi;
            mi = sender as ToolStripMenuItem;
            mi.Checked = !mi.Checked;
        }

        private void mtbDaysBefore_TextChanged(object sender, EventArgs e)
        {
            DateTime alarmDate = DateTime.Now;
            int dateType = 0;
            if (monthCalendar1.SelectionStart.Day == 1)
            {
                alarmDate = monthCalendar1.SelectionEnd;
                dateType = 1;
            }
            else if (monthCalendar1.SelectionEnd.AddDays(1).Day == 1)
            {
                alarmDate = monthCalendar1.SelectionStart;
                dateType = 2;
            }
            if (dateType > 0)
            {
                int deltaDate = -1 * Convert.ToInt32((sender as TextBox).Text);
                alarmDate = alarmDate.AddDays(deltaDate);
                monthCalendar1.RemoveAllBoldedDates();
                monthCalendar1.AddBoldedDate(alarmDate);
                //monthCalendar1.SetDate(alarmDate.AddYears(1));
                //monthCalendar1.SetDate(alarmDate.AddYears(-1));
            }
        }
    }
}