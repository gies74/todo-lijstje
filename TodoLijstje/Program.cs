using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Collections;

namespace TodoLijstje
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }

    public class Activiteit
    {
        #region Internal properties
        public string m_sDesc;
        public string sGUID;
        public bool visible;
        public long totalAvailable;
        public Hashtable m_Hash;
        #endregion

        /// <summary>
        /// constructor
        /// </summary>
        public Activiteit()
        {
            this.m_Hash = new Hashtable();
            this.visible = true;
            this.totalAvailable = 0L;
        }

        /// <summary>
        /// how many seconds have been spent on date dt
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public long GetTimespent(DateTime dt)
        {
            string sNow = dt.ToShortDateString();
            if (!this.m_Hash.ContainsKey(sNow))
                this.m_Hash.Add(sNow, 0L);
            return (long)this.m_Hash[sNow];
        }

        /// <summary>
        /// how many seconds have been spent today
        /// </summary>
        /// <returns></returns>
        public long GetTimespent()
        {
            return GetTimespent(System.DateTime.Now);
        }

        /// <summary>
        /// set the time spent on this activity
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="lTimespent"></param>
        public void SetTimespent(DateTime dt, long lTimespent)
        {
            string sNow = dt.ToShortDateString();
            if (!this.m_Hash.ContainsKey(sNow))
                this.m_Hash.Add(sNow, 0L);
            this.m_Hash[sNow] = lTimespent;
        }

        /// <summary>
        /// set the time spent today on this activity 
        /// </summary>
        /// <param name="lTimespent"></param>
        public void SetTimespent(long lTimespent)
        {
            SetTimespent(System.DateTime.Now, lTimespent);
        }
    }

    class ScheduledAction
    {
        public bool hasbeenfired;
        public long fire;
        public string alertmsg;
        public string sGUID;
        public bool repeat;
        public string repeattype;
        public int times;
        public string period;
        public ScheduledAction()
        {
            hasbeenfired = false;
        }
    }
}