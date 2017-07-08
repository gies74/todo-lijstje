using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml;
using System.Collections;
using TodoLijstje.Resources;
using Microsoft.Win32;

namespace TodoLijstje
{
    public partial class MainForm : Form
    {
        #region class properties (global variables)
        TreeView m_tvCurr;
        bool checkPass = true;
        const int nchars=15;
        frmActVis m_frmActVis;
        frmActProps m_frmActProps;
        frmOptions m_frmOptions;
        frmScheduledAction m_frmScheduledAction;
        Herinnering m_frmReminder;
        private ArrayList m_invisTabPages;
        #endregion

        public MainForm()
        {
            InitializeComponent();
            m_frmActVis = new frmActVis();
            m_frmActProps = new frmActProps();
            m_frmOptions = new frmOptions();
            m_frmScheduledAction = new frmScheduledAction();
            m_frmReminder = new Herinnering();

        }

        /// <summary>
        /// Create new activity
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btNewAct_Click(object sender, EventArgs e)
        {
            Activiteit pAct;
            pAct = new Activiteit();
            pAct.sGUID = Guid.NewGuid().ToString();
            pAct.m_sDesc = "Nieuwe activiteit";
            pAct.SetTimespent(0L);

            TabPage tpNew = new TabPage(pAct.m_sDesc);
            tpNew.ToolTipText = pAct.m_sDesc;
            tcActLijst.TabPages.Add(tpNew);

            tpNew.Tag = pAct;
            // tpNew.ContextMenuStrip = cmActiviteit;
            // tcActLijst.ContextMenuStrip = cmActiviteit;

            TreeView tvNew = new TreeView();
            tpNew.Controls.Add(tvNew);

            resizeInner();
            btPausestart.Enabled = true;

            tvNew.CheckBoxes = true;
            tvNew.LabelEdit = true;
            tvNew.AfterLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.tvTaskLijst_RenameAct);
            tvNew.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tvActLijst_MouseDown);

            TreeNode tnNew = new TreeNode("*");
            tvNew.Nodes.Add(tnNew);

            tnNew.BeginEdit();

        }

        /// <summary>
        /// Remove task from activity panel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void verwijderTaak(object sender, EventArgs e)
        {
            if (m_tvCurr != null)
            {
                m_tvCurr.SelectedNode.Remove();
                m_tvCurr = null;
            }
        }

        /// <summary>
        /// Remove activity
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void verwijderActiviteit(object sender, EventArgs e)
        {
            Activiteit actCurr = tcActLijst.SelectedTab.Tag as Activiteit;
            if (MessageBox.Show("Verwijder activiteit '"+actCurr.m_sDesc+"'?", "Bevestig keuze", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, 
                MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                tcActLijst.TabPages.Remove(tcActLijst.SelectedTab);
                if (tcActLijst.TabCount == 1 && timer1.Enabled)
                {
                    btPausestart.Enabled = false;
                    btPausestart_Click(sender, e);
                }
            }

        }

        /// <summary>
        /// Eventhandler that identifies which treeview node has been clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tvActLijst_MouseDown(object sender, MouseEventArgs e)
        {
            TreeView tv = sender as TreeView;
            Point pos = new Point(e.X, e.Y);
            tv.SelectedNode = tv.GetNodeAt(pos);
            m_tvCurr = tv;
        }

        /// <summary>
        /// User clicked pause-start button, toggle timer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btPausestart_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled)
            {
                timer1.Stop();
                btPausestart.Image = global::TodoLijstje.Resource1.play; //.Text = ">";
                this.Text = "ToDo " + System.Reflection.Assembly.GetAssembly(this.GetType()).GetName().Version.ToString(4); 
            }
            else
            {
                timer1.Start();
                btPausestart.Image = global::TodoLijstje.Resource1.stop; //.Text = "||";
            }
            resizeInner();
        }

        /// <summary>
        /// function that sets the label with each Timer epoch
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void IncrCurrTijd(object sender, EventArgs e)
        {
            int iHours,iMins, iSecs;
            long time,mtime;
            Activiteit actCurr;
            
            actCurr = (Activiteit)tcActLijst.SelectedTab.Tag;
            if (actCurr is Activiteit)
            {
                // btPausestart_Click(null, null);
                // return;
                time = actCurr.GetTimespent() + 1;
                actCurr.SetTimespent(time);
                iSecs = System.Convert.ToInt32(time % 60);
                iMins = System.Convert.ToInt32(Math.Floor(System.Convert.ToDouble(time) / 60L));
                mtime = (long)iMins;
                iMins = System.Convert.ToInt32(mtime % 60);
                iHours = System.Convert.ToInt32(Math.Floor(System.Convert.ToDouble(mtime) / 60L));
                string pasttime = String.Format("{0}:{1:00}:{2:00}", iHours, iMins, iSecs);
                this.Text = pasttime + " " + actCurr.m_sDesc;
            }
            else
                this.Text = "ToDo " + System.Reflection.Assembly.GetAssembly(this.GetType()).GetName().Version.ToString(4); 

        }

        /// <summary>
        /// speaks for itself
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private bool doReturn = false;
        private void tvTaskLijst_RenameAct(object sender, NodeLabelEditEventArgs e)
        {
            TreeView tv = sender as TreeView;
            if (String.IsNullOrEmpty(e.Label) && e.Node.Text == "*" && doReturn)
            {
                doReturn = false;
                return;
            }
            if ((String.IsNullOrEmpty(e.Label) || e.Label == "*") && (String.IsNullOrEmpty(e.Node.Text) || e.Node.Text == "*"))
            {
                if (e.Node.Index < tv.Nodes.Count - 1)
                {
                    tv.Nodes.Remove(e.Node);
                }
                else
                    tv.Nodes[e.Node.Index].Text = "*";
                return;
            }
            else if (!String.IsNullOrEmpty(e.Label))
            {
                e.Node.ContextMenuStrip = cmTaak;
                TreeNode tn = new TreeNode("*");
                if (e.Node.Index == (tv.Nodes.Count - 1))
                    tv.Nodes.Add(tn);
                else
                    tv.Nodes.Insert(e.Node.Index + 1, tn);
                doReturn = true;
                tn.BeginEdit();
            }
        }

        /// <summary>
        /// speaks for itself
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            RegistryKey regKey;
            m_invisTabPages = new ArrayList();
            OpenConfig();

            // make sure it elapses at the first whole minute
            DateTime dtNow = DateTime.Now;
            timer2.Interval = (59 - dtNow.Second) * 1000 + (1000-dtNow.Millisecond);

            regKey = Registry.CurrentUser.OpenSubKey(@"Software\ToDo");
            if (regKey == null)
            {
                regKey = Registry.CurrentUser.CreateSubKey(@"Software\ToDo");
                regKey.SetValue("AlwaysOnTop", "True");
            }
            cbAlwaysOnTop.Checked = this.TopMost = Convert.ToBoolean(regKey.GetValue("AlwaysOnTop"));
            cbAlwaysOnTop.Text = LocalizedText.Label_Text_AlwaysOnTop;
            
            m_frmScheduledAction.TopMost = m_frmActVis.TopMost = m_frmActProps.TopMost = m_frmOptions.TopMost = this.TopMost;

            string locsize = Convert.ToString(regKey.GetValue("LocationSize"));
            if (String.IsNullOrEmpty(locsize))
                locsize = "100,100,300,220";
            string[] elts = locsize.Split(new char[1] { ',' });

            this.Location = new Point(Convert.ToInt32(elts[0]), Convert.ToInt32(elts[1]));
            this.Size = new Size(Convert.ToInt32(elts[2]), Convert.ToInt32(elts[3]));

            IEnumerator scEnum = Screen.AllScreens.GetEnumerator();
            Screen s;
            bool inScreenBounds=false;
            while (scEnum.MoveNext())
            {
                s = scEnum.Current as Screen;
                if (s.Bounds.Contains(this.Location))
                    inScreenBounds=true;
            }
            if (!inScreenBounds)
            {
                locsize = "100,100";
                elts = locsize.Split(new char[1] { ',' });
                this.Location = new Point(Convert.ToInt32(elts[0]), Convert.ToInt32(elts[1]));
            }

            string urenurl = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\uren.html";
            webBrowser1.Url = new System.Uri(urenurl);
#if !DEBUG
            btForceTick.Visible = false;
#endif
            this.Text = "ToDo " + System.Reflection.Assembly.GetAssembly(this.GetType()).GetName().Version.ToString(4); 
        }

        /// <summary>
        /// speaks for itself
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Unload(object sender, FormClosedEventArgs e)
        {
            SaveConfig();
            RegistryKey regKey;
            regKey = Registry.CurrentUser.OpenSubKey(@"Software\ToDo", true);
            regKey.SetValue("AlwaysOnTop", Convert.ToString(cbAlwaysOnTop.Checked));
            int storex, storey;
            if (this.WindowState != FormWindowState.Minimized)
            {
                storex = this.Location.X;
                storey = this.Location.Y;
                regKey.SetValue("LocationSize", Convert.ToString(storex) + "," + Convert.ToString(storey) + "," + Convert.ToString(this.Size.Width) + "," + Convert.ToString(this.Size.Height));
            }
        }

        /// <summary>
        /// load configuration from XML
        /// </summary>
        private void OpenConfig()
        {
            TreeNode tnNew;
            XmlNodeList nodes,tnodes,dnodes;
            XmlDocument ActReg = new XmlDocument();
            Activiteit actCurr;
            ScheduledAction saCurr;
            ICollection coll;
            XmlNode tmpNode;
            bool loadCompleted;

            RegistryKey regKey;
            regKey = Registry.CurrentUser.OpenSubKey(@"Software\ToDo");
            if (regKey == null)
            {
                regKey = Registry.CurrentUser.CreateSubKey(@"Software\ToDo", RegistryKeyPermissionCheck.ReadWriteSubTree);
                regKey.SetValue("LoadCompleted", "False");
            }
            loadCompleted = Convert.ToBoolean(regKey.GetValue("LoadCompleted"));

            try
            {
                ActReg.Load(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\ActivityRegistration.xml");
            }
            catch
            {
                return;
            }

            tcActLijst.ContextMenuStrip = cmActiviteit;

            nodes = ActReg.SelectNodes("/ACTIVITIES/ACTIVITY");
            foreach (XmlNode node in nodes)
            {
                actCurr = new Activiteit();
                actCurr.sGUID = node.Attributes["id"].Value;
                actCurr.m_sDesc = node.SelectSingleNode("DESCRIPTION").InnerText;

                tmpNode = node.SelectSingleNode("AVAILABLETIME");
                if (tmpNode != null)
                    actCurr.totalAvailable = Convert.ToInt64(tmpNode.InnerText);

                coll = actCurr.m_Hash.Keys;
                dnodes = node.SelectNodes("TIMESPENT/DAY");

                foreach (XmlNode dnode in dnodes)
                {
                    actCurr.m_Hash.Add(dnode.Attributes["day"].Value, System.Convert.ToInt64(dnode.InnerText));
                }

                string str = actCurr.m_sDesc;
                TabPage tpNew = new TabPage(str.Substring(0, Math.Min(str.Length, nchars)));
                tpNew.ToolTipText = str;

                if (node.Attributes["visible"] != null)
                    actCurr.visible = Convert.ToBoolean(node.Attributes["visible"].Value);
                else
                    actCurr.visible = true;
                if (actCurr.visible)
                    tcActLijst.TabPages.Add(tpNew);
                else
                    m_invisTabPages.Insert(m_invisTabPages.Count,tpNew);

                tpNew.Tag = actCurr;
                // tpNew.ContextMenuStrip = cmActiviteit;
                // tcActLijst.ContextMenuStrip = cmActiviteit;

                TreeView tvNew = new TreeView();
                tpNew.Controls.Add(tvNew);

                tvNew.CheckBoxes = true;
                tvNew.LabelEdit = true;
                tvNew.AfterLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.tvTaskLijst_RenameAct);
                tvNew.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tvActLijst_MouseDown);

                tnodes = node.SelectNodes("TASKS/TASK");
                foreach (XmlNode tnode in tnodes)
                {
                    if (loadCompleted || !System.Convert.ToBoolean(tnode.Attributes["completed"].Value))
                    {
                        tnNew = new TreeNode(tnode.Attributes["description"].Value);
                        tvNew.Nodes.Add(tnNew);
                        tnNew.ContextMenuStrip = cmTaak;
                        tnNew.Checked = System.Convert.ToBoolean(tnode.Attributes["completed"].Value);
                    }
                }
                tnNew = new TreeNode("*");
                tvNew.Nodes.Add(tnNew);
                btPausestart.Enabled = true;

            }

            nodes = ActReg.SelectNodes("/ACTIVITIES/SCHEDULEDACTION");
            foreach (XmlNode node in nodes)
            {
                saCurr = new ScheduledAction();
                saCurr.sGUID = node.Attributes["id"].Value;
                saCurr.hasbeenfired = Convert.ToBoolean(node.Attributes["hasbeenfired"].Value);
                saCurr.fire = Convert.ToInt64(node.SelectSingleNode("FIRE").InnerText);
                saCurr.alertmsg = node.SelectSingleNode("ALERTMSG").InnerText;
                tmpNode = node.SelectSingleNode("REPEAT");
                if (tmpNode != null)
                {
                    saCurr.repeat = true;
                    saCurr.repeattype = tmpNode.Attributes["type"].Value;
                    saCurr.times = Convert.ToInt32(tmpNode.Attributes["times"].Value);
                    saCurr.period = tmpNode.InnerText;
                }
                else
                    saCurr.repeat = false;

                int k = 1;
                string key;
                do {
                    key = saCurr.fire.ToString() + "_" + k.ToString();
                    k++;
                } while (m_frmScheduledAction.m_scheduledActions.ContainsKey(key));
                m_frmScheduledAction.m_scheduledActions.Add(key, saCurr);
            }

            resizeInner();
        }

        /// <summary>
        /// saves current memory state to XML file
        /// </summary>
        private void SaveConfig()
        {
            XmlDocument actReg = new XmlDocument();
            XmlElement rootEl, actEl, saEl, taskEl, chEl, dEl, rEl;
            Activiteit actCurr;
            TabPage tp;
            ICollection coll;

            rootEl = actReg.CreateElement("ACTIVITIES");
            int i2;
            for (int i = 0; i < tcActLijst.TabCount + m_invisTabPages.Count; i++)
            {
                if (i < tcActLijst.TabCount)
                {
                    tp = tcActLijst.TabPages[i];
                    if (!(tp.Tag is Activiteit))
                        continue;
                }
                else
                {
                    i2 = i - tcActLijst.TabCount;
                    tp = m_invisTabPages[i2] as TabPage;
                }
                actCurr = (Activiteit)tp.Tag;
                actEl = actReg.CreateElement("ACTIVITY");
                actEl.SetAttribute("id", actCurr.sGUID);
                actEl.SetAttribute("visible", Convert.ToString(actCurr.visible));

                // omschrijvende term
                chEl = actReg.CreateElement("DESCRIPTION");
                chEl.InnerText = actCurr.m_sDesc;
                actEl.AppendChild(chEl);

                chEl = actReg.CreateElement("AVAILABLETIME");
                chEl.InnerText = Convert.ToString(actCurr.totalAvailable);
                actEl.AppendChild(chEl);

                // takenlijst
                taskEl = actReg.CreateElement("TASKS");

                IEnumerator ce = tp.Controls.GetEnumerator();
                ce.MoveNext();
                Control c = (Control)ce.Current;
                if (c.GetType().ToString().Equals("System.Windows.Forms.TreeView"))
                {
                    TreeView tv = (TreeView)c;


                    for (int j = 0; j < tv.Nodes.Count-1; j++)
                    {
                        chEl = actReg.CreateElement("TASK");
                        chEl.SetAttribute("description", tv.Nodes[j].Text);
                        chEl.SetAttribute("completed", System.Convert.ToString(tv.Nodes[j].Checked));
                        taskEl.AppendChild(chEl);
                    }
                }
                actEl.AppendChild(taskEl);

                // time spent
                chEl = actReg.CreateElement("TIMESPENT");
                coll = actCurr.m_Hash.Keys;
                foreach (string sKey in coll)
                {
                    dEl = actReg.CreateElement("DAY");
                    dEl.SetAttribute("day", sKey);
                    dEl.InnerText = System.Convert.ToString(actCurr.m_Hash[sKey]);
                    chEl.AppendChild(dEl);
                }
                actEl.AppendChild(chEl);

                rootEl.AppendChild(actEl);
            }

            foreach (ScheduledAction saCurr in m_frmScheduledAction.m_scheduledActions.Values)
            {
                saEl = actReg.CreateElement("SCHEDULEDACTION");
                saEl.SetAttribute("id", saCurr.sGUID);
                saEl.SetAttribute("hasbeenfired", Convert.ToString(saCurr.hasbeenfired));
                chEl = actReg.CreateElement("FIRE");
                chEl.InnerText = Convert.ToString(saCurr.fire);
                saEl.AppendChild(chEl);
                chEl = actReg.CreateElement("ALERTMSG");
                chEl.InnerText = saCurr.alertmsg;
                saEl.AppendChild(chEl);
                if (saCurr.repeat)
                {
                    rEl = actReg.CreateElement("REPEAT");
                    rEl.SetAttribute("type", saCurr.repeattype);
                    rEl.SetAttribute("times", Convert.ToString(saCurr.times));
                    rEl.InnerText = saCurr.period;
                    saEl.AppendChild(rEl);
                }
                rootEl.AppendChild(saEl);
            }




            actReg.AppendChild(rootEl);
            actReg.Save(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\ActivityRegistration.xml");
        }

        #region handle resize

        /// <summary>
        /// event handler, speaks for itself
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Resize(object sender, EventArgs e)
        {
            // m_repaint = 3;
            DoLayout();
        }

        /// <summary>
        /// move around a couple of elements of the mainform when form is resized
        /// </summary>
        private void DoLayout()
        {
            //btPausestart.Location = new Point(btPausestart.Location.X, this.Height - 67);
            //cbAlwaysOnTop.Location = new Point(cbAlwaysOnTop.Location.X, this.Height - 51);
            //btNewAct.Location = new Point(this.Width - 51, this.Height - 67);
            //tcActLijst.Size = new Size(this.Width - 32, this.Height - 85);
            resizeInner();
        }

        /// <summary>
        /// resize treeview of each tabpage when tabcontrol is resized
        /// </summary>
        private void resizeInner()
        {
            if (!checkPass)
                return;
            checkPass = false;
            foreach (TabPage tp in tcActLijst.TabPages)
            {
                IEnumerator ce = tp.Controls.GetEnumerator();
                ce.MoveNext();
                Control c = (Control)ce.Current;
                if (c.GetType().ToString().Equals("System.Windows.Forms.TreeView"))
                {
                    TreeView tv = (TreeView)c;
                    tv.Size = tcActLijst.SelectedTab.Size;
                }
            }
            checkPass = true;
        }

        #endregion

        /// <summary>
        /// determine which tabpage has been clicked on the tabcontrol
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tcActLijst_MouseDown(object sender, MouseEventArgs e)
        {
            int toRemove = -1;
            Rectangle rect;
            for (int i = 0; i < tcActLijst.TabPages.Count; i++)
            {
                rect = tcActLijst.GetTabRect(i);
                if (rect.Contains(e.Location))
                {
                    toRemove = i;
                    break;
                }
            }

            if (toRemove == -1)
                return;
            tcActLijst.SelectTab(toRemove);

            if (this.tcActLijst.SelectedTab.Tag is Activiteit)
            {
                verwijderAllesToolStripMenuItem.Enabled = verwijderVoltooidToolStripMenuItem.Enabled = verbergToolStripMenuItem.Enabled = sorteerTakenToolStripMenuItem.Enabled = eigenschappenToolStripMenuItem.Enabled = verwijderToolStripMenuItem.Enabled = hernoemToolStripMenuItem.Enabled = true;
            }
            else
            {
                verwijderAllesToolStripMenuItem.Enabled = verwijderVoltooidToolStripMenuItem.Enabled = verbergToolStripMenuItem.Enabled = sorteerTakenToolStripMenuItem.Enabled = eigenschappenToolStripMenuItem.Enabled = verwijderToolStripMenuItem.Enabled = hernoemToolStripMenuItem.Enabled = false;
                SaveConfig();
                webBrowser1.Refresh();
            }

        }

        /// <summary>
        /// speaks for itself
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void hernoemAct(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                if (!toolStripTextBox1.Text.Equals(String.Empty))
                {
                    Activiteit actCurr;
                    string str = toolStripTextBox1.Text;
                    tcActLijst.SelectedTab.Text = str.Substring(0, Math.Min(str.Length,nchars));
                    tcActLijst.SelectedTab.ToolTipText = str;
                    actCurr = tcActLijst.SelectedTab.Tag as Activiteit;
                    actCurr.m_sDesc = str;
                }
                toolStripTextBox1.Text = String.Empty;
                cmActiviteit.Hide();
            }
        }

        #region taak node verplaatsen

        private void bovenaanToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            verplaatsNode(0);
        }

        private void naarBovenToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (m_tvCurr.SelectedNode.Index == 0)
                return;
            verplaatsNode(m_tvCurr.SelectedNode.Index - 1);
        }

        private void naarOnderToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (m_tvCurr.SelectedNode.Index == m_tvCurr.Nodes.Count-2)
                return;
            verplaatsNode(m_tvCurr.SelectedNode.Index + 2);
            
        }

        private void onderaanToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            verplaatsNode(m_tvCurr.Nodes.Count - 1);
        }

        private void verplaatsNode(int idx)
        {
            TreeNode newNode = new TreeNode(m_tvCurr.SelectedNode.Text);
            newNode.ContextMenuStrip = cmTaak;
            newNode.Checked = m_tvCurr.SelectedNode.Checked;
            m_tvCurr.Nodes.Insert(idx, newNode);
            m_tvCurr.SelectedNode.Remove();
            m_tvCurr.SelectedNode = newNode;
        }

        #endregion

        /// <summary>
        /// executed after a user has checked which activities should be made visible 
        /// or hidden. Tabpages are actually removed and attached to a class property
        /// (arraylist), as they have no Visible property.
        /// </summary>
        private void processVisible() 
        {
            Activiteit actCurr;
            TabPage tp;
            int last;
            
            for (int i = tcActLijst.TabCount-1; i>=0; i--)
            {
                tp = tcActLijst.TabPages[i];
                if (!(tp.Tag is Activiteit))
                    continue;
                actCurr = (Activiteit)tp.Tag;
                if(!m_frmActVis.isVisible(actCurr.m_sDesc))
                {
                    actCurr.visible = false;
                    m_invisTabPages.Insert(m_invisTabPages.Count, tp);
                    HideTabPage(tp);
                }
            }
            last = tcActLijst.TabCount;
            for (int i = m_invisTabPages.Count - 1; i>=0 ; i--)
            {
                tp = m_invisTabPages[i] as TabPage;
                actCurr = (Activiteit)tp.Tag;

                if (m_frmActVis.isVisible(actCurr.m_sDesc))
                {
                    actCurr.visible = true;
                    ShowTabPage(tp,last);
                    m_invisTabPages.RemoveAt(i);
                }
            }
            resizeInner();

        }

        /// <summary>
        /// event handler belonging to CONTEXT MENU "Verberg/toon activietien"
        /// this procedure sets the right checks in the list and eventually 
        /// shows the form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            Activiteit actCurr;
            TabPage tp;
            System.Windows.Forms.DialogResult dr;
            m_frmActVis.clearList();
            for (int i = 1; i < tcActLijst.TabCount; i++)
            {
                tp = tcActLijst.TabPages[i];
                actCurr = (Activiteit)tp.Tag;
                m_frmActVis.addBox(actCurr.m_sDesc, true);
            }
            for (int i = 0; i < m_invisTabPages.Count; i++)
            {
                tp = m_invisTabPages[i] as TabPage;
                actCurr = (Activiteit)tp.Tag;
                m_frmActVis.addBox(actCurr.m_sDesc, false);
            }
            // m_frmActVis.Location = new Point(this.Location.X+100, this.Location.Y + 100);
            
            dr = m_frmActVis.ShowDialog();
            if (dr == DialogResult.OK)
                processVisible();
        }

        #region Tabpage stuff

        private void HideTabPage(TabPage tp)
        {
            if (tcActLijst.TabPages.Contains(tp))
                tcActLijst.TabPages.Remove(tp);
        }


        private void ShowTabPage(TabPage tp)
        {
            ShowTabPage(tp, tcActLijst.TabPages.Count);
        }


        private void ShowTabPage(TabPage tp, int index)
        {
            if (tcActLijst.TabPages.Contains(tp)) return;
            InsertTabPage(tp, index);
        }


        private void InsertTabPage(TabPage tabpage, int index)
        {
            if (index < 0 || index > tcActLijst.TabCount)
                throw new ArgumentException("Index out of Range.");
            tcActLijst.TabPages.Add(tabpage);
            if (index < tcActLijst.TabCount - 1)
                do
                {
                    SwapTabPages(tabpage, (tcActLijst.TabPages[tcActLijst.TabPages.IndexOf(tabpage) - 1]));
                }
                while (tcActLijst.TabPages.IndexOf(tabpage) != index);
            tcActLijst.SelectedTab = tabpage;
        }

        private void SwapTabPages(TabPage tp1, TabPage tp2)
        {
            if (tcActLijst.TabPages.Contains(tp1) == false || tcActLijst.TabPages.Contains(tp2) == false)
                throw new ArgumentException("TabPages must be in the TabControls TabPageCollection.");

            int Index1 = tcActLijst.TabPages.IndexOf(tp1);
            int Index2 = tcActLijst.TabPages.IndexOf(tp2);
            tcActLijst.TabPages[Index1] = tp2;
            tcActLijst.TabPages[Index2] = tp1;

        }
        #endregion

        /// <summary>
        /// show the amount of time spent on current activity in a form
        /// allow user to change
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void showProps(object sender, EventArgs e)
        {
            m_frmActProps.m_actCurr = tcActLijst.SelectedTab.Tag as Activiteit;
            m_frmActProps.setNaam(m_frmActProps.m_actCurr.m_sDesc);
            m_frmActProps.ShowDialog();
        }

        /// <summary>
        /// any child form should immediately get the same property
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void changeAlwaysOnTop(object sender, EventArgs e)
        {
            m_frmScheduledAction.TopMost = m_frmOptions.TopMost = m_frmActProps.TopMost = m_frmActVis.TopMost = this.TopMost = cbAlwaysOnTop.Checked;
        }

        /// <summary>
        /// show options form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpenOpties(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                m_frmOptions.ShowDialog();
            }
        }

        /// <summary>
        /// open Alert scheduler form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void geagendeerdeTakenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            m_frmScheduledAction.ShowDialog();
        }

        /// <summary>
        /// this timer keeps track of Alerts and shows them if necessary
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer2_Tick(object sender, EventArgs e)
        {
            ScheduledAction saCurr;
            DateTime dtnow = DateTime.Now, dttask;
            long ts, secs = 0;
            int j, dow;
            string[] per, per2;
            string msg;
            char[] sep = new char[3];
            timer2.Interval = 60000;
            List<string> keyList = new List<string>();
            foreach (string key in m_frmScheduledAction.m_scheduledActions.Keys)
            {
                keyList.Add(key);
            }
            foreach (string key in keyList)
            {
                saCurr = m_frmScheduledAction.m_scheduledActions[key];
                dttask = new DateTime(saCurr.fire);
                ts = dtnow.Ticks - dttask.Ticks;
                secs = Convert.ToInt64(Math.Round(Convert.ToDouble(ts) / 10000000));
                if (secs >= 0)
                {
                    //FormWindowState oldWindowState = this.WindowState;
                    //bool restoreWS = false;
                    //if (this.WindowState == FormWindowState.Minimized)
                    //    restoreWS = true;
                    if (secs > 0 && saCurr.hasbeenfired == false || secs == 0)
                    {
                        //if (restoreWS)
                        //    this.WindowState = FormWindowState.Normal;
                        msg = (secs > 0 && (saCurr.hasbeenfired == false)) ?
                            String.Format(LocalizedText.MessageBox_Text_OnAtProgrammed, new object[] { dttask.ToShortDateString(), dttask.ToShortTimeString(), saCurr.alertmsg }) : saCurr.alertmsg;
                        saCurr.hasbeenfired = true;
                        m_frmReminder.textBox1.Text = msg;
                        m_frmReminder.RemoveReminder = !(saCurr.repeat && saCurr.times > 0);
                        m_frmReminder.ShowDialog();
                        if (m_frmReminder.RemoveReminder)
                        {
                            m_frmScheduledAction.RemoveSA(key);
                            continue;
                        }
                    }
                    // now reschedule the reminder
                    if (saCurr.repeat && saCurr.times > 0)
                    {
                        DateTime nexttask = dttask;
                        while (nexttask.Ticks < DateTime.Now.Ticks && saCurr.times > 0)
                        {
                            if (saCurr.repeattype.Equals("period"))
                            {
                                sep[0] = ' '; sep[1] = '-'; sep[2] = ':';
                                per = saCurr.period.Split(sep);
                                dttask = dttask.AddYears(Convert.ToInt32(per[2]));
                                dttask = dttask.AddMonths(Convert.ToInt32(per[1]));
                                dttask = dttask.AddDays(Convert.ToInt32(per[0]));
                                dttask = dttask.AddHours(Convert.ToInt32(per[3]));
                                dttask = dttask.AddMinutes(Convert.ToInt32(per[4]));
                                nexttask = dttask;
                            }
                            else if (saCurr.repeattype.Equals("weekday"))
                            {
                                sep[0] = ' '; // sep[1] = '-'; sep[2] = ':';
                                per = saCurr.period.Split(sep);
                                j = Convert.ToInt32(per[1]);
                                dow = Convert.ToInt32(per[2]);
                                sep[0] = '-';
                                per2 = per[3].Split(sep);
                                // first set the dttask forward
                                dttask = dttask.AddDays(Convert.ToInt32(per[4]));
                                dttask = dttask.AddYears(Convert.ToInt32(per2[1]));
                                dttask = dttask.AddMonths(Convert.ToInt32(per2[0]));
                                dttask = dttask.AddDays(-1 * (dttask.Day - 1));
                                if (per[0].Equals("last"))
                                {
                                    dttask = dttask.AddMonths(1).AddDays(-1);
                                    dttask = dttask.AddDays((j - 1) * -7);
                                    while (!matchWeekday(dttask, dow))
                                        dttask = dttask.AddDays(-1);

                                }
                                else
                                {
                                    dttask = dttask.AddDays((j - 1) * 7);
                                    while (!matchWeekday(dttask, dow))
                                        dttask = dttask.AddDays(1);
                                }
                                // now set it backward
                                nexttask = dttask; 
                                dttask = dttask.AddDays(-1 * Convert.ToInt32(per[4]));
                            }
                            saCurr.fire = dttask.Ticks;
                            if (saCurr.times < 99)
                                saCurr.times--;
                        }
                        if (saCurr.times >= 0)
                            saCurr.hasbeenfired = false;
                    }
                }
            }
        }
         
        /// <summary>
        /// does the given date match the given Day-of-Week bit code?
        /// Coding examples:
        /// 00000000.00000000.00000000.00000001 means Monday
        /// 00000000.00000000.00000000.00000010 means Tuesday
        /// 00000000.00000000.00000000.00100010 means Tuesday and Saturday
        /// 00000000.00000000.00000000.00011111 means Weekdays
        /// </summary>
        /// <param name="dt">date</param>
        /// <param name="dow">Day of week bit code (7 least significant bits of integer)</param>
        /// <returns></returns>
        private bool matchWeekday(DateTime dt, int dow)
        {  
            int wd; 
            switch (dt.DayOfWeek)
            {
                case DayOfWeek.Monday:
                    wd = 0x0001;
                    break;
                case DayOfWeek.Tuesday:
                    wd = 0x0002;
                    break;
                case DayOfWeek.Wednesday:
                    wd = 0x0004;
                    break;
                case DayOfWeek.Thursday:
                    wd = 0x0008;
                    break;
                case DayOfWeek.Friday:
                    wd = 0x0010;
                    break;
                case DayOfWeek.Saturday:
                    wd = 0x0020;
                    break;
                default:
                    wd = 0x0040;
                    break;
            }
            return Convert.ToBoolean(dow & wd);
        }

        /// <summary>
        /// invoke xml save of configuration
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void opslaanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveConfig();
        }

        private struct task
        {
            public string tdesc;
            public bool tcheck;
            public task(string ts, bool tc)
            {
                this.tdesc = ts;
                this.tcheck = tc;
            }
        }

        private void SortTasks()
        {
            const string RE = @"^([0-9]+(\.[0-9]+)?) .*$";
            Regex pRE = new Regex(RE);
            IEnumerator ce = tcActLijst.SelectedTab.Controls.GetEnumerator();
            ce.MoveNext();
            
            if (ce.Current is TreeView)
            {
                SortedList<double, task> sl = new SortedList<double, task>();
                SortedList sl2 = new SortedList();
                TreeView tv = ce.Current as TreeView;
                string skey,text;
                task mt;
                for (int i = 0; i < tv.Nodes.Count -1 ; i++)
                {
                    text = tv.Nodes[i].Text;
                    mt = new task(text, tv.Nodes[i].Checked);
                    if (Regex.Match(tv.Nodes[i].Text, RE).Success)
                    {
                        skey = Regex.Replace(text, RE, "$1");
                        double fidx, ftmp;
                        fidx = Double.Parse(skey, new System.Globalization.CultureInfo("en-us"));
                        ftmp = 0.1;
                        while (sl.ContainsKey(fidx))
                        {
                            fidx += ftmp;
                            ftmp /= 10;
                        }
                        sl.Add(fidx, mt);
                    }
                    else
                    {
                        sl2.Add(text, mt);
                    }
                }

                tv.Nodes.Clear();
                TreeNode tn;
                for (int i = 0; i < sl.Count; i++)
                {
                    mt = sl.Values[i];
                    tn = new TreeNode(mt.tdesc);
                    tn.Checked = mt.tcheck;
                    tn.ContextMenuStrip = cmTaak;
                    tv.Nodes.Add(tn);
                }
                for (int i = 0; i < sl2.Count; i++)
                {
                    mt = (task)sl2.GetByIndex(i);
                    tn = new TreeNode(mt.tdesc);
                    tn.Checked = mt.tcheck;
                    tn.ContextMenuStrip = cmTaak;
                    tv.Nodes.Add(tn);
                }
                tv.Nodes.Add("*");
            }
        }

        private void sorteerTakenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SortTasks();
        }

        private void verbergToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Activiteit actCurr = tcActLijst.SelectedTab.Tag as Activiteit;
            actCurr.visible = false;
            m_invisTabPages.Insert(m_invisTabPages.Count, tcActLijst.SelectedTab);
            HideTabPage(tcActLijst.SelectedTab);
        }

        private void VerwijderVoltooid_Click(object sender, EventArgs e)
        {
            bool alles = (sender == verwijderAllesToolStripMenuItem);
            IEnumerator ce = tcActLijst.SelectedTab.Controls.GetEnumerator();
            ce.MoveNext();

            if (ce.Current is TreeView)
            {
                TreeView tv = ce.Current as TreeView;
                for (int i = tv.Nodes.Count - 2; i >= 0; i--)
                {
                    if (tv.Nodes[i].Checked || alles)
                        tv.Nodes[i].Remove();
                }
            }
        }

        private void btForceTick_Click(object sender, EventArgs e)
        {
            timer2_Tick(null, null);
        }

    }
}