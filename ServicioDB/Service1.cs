using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Windows.Forms;

namespace ServicioDB
{
    public partial class Service1 : ServiceBase
    {
#pragma warning disable CS0169 // El campo 'Service1.timer' nunca se usa
        private static System.Windows.Forms.Timer timer;
#pragma warning restore CS0169 // El campo 'Service1.timer' nunca se usa
        private static System.Timers.Timer timerTask;

        public Service1()
        {
            InitializeComponent();
        }
        public void init()
        {
            this.OnStart(null);
        }

        private static void OnTimedEvent(Object source, System.Timers.ElapsedEventArgs e)
        {
            try
            {
                string textopath = Application.StartupPath + "\\tramas.txt";
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(textopath))
                {
                    file.WriteLine($"{DateTime.Now.ToString()}");
                }
            }
            catch (Exception ex)
            {
                string textolog = Application.StartupPath + "\\Log.txt";
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(textolog))
                {
                    file.WriteLine(ex.Message);
                }
            }

        }

        protected override void OnStart(string[] args)
        {
            timerTask = new System.Timers.Timer();
            timerTask.Enabled = false;
            timerTask.Interval = 1000;
            timerTask.Elapsed += OnTimedEvent;
            timerTask.Start();
        }

        protected override void OnStop()
        {
        }
    }
}
