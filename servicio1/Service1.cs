using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace servicio1
{
    public partial class Service1 : ServiceBase
    {
        private static System.Windows.Forms.Timer timer;
        private static System.Timers.Timer timerTask;
        public Service1()
        {
            InitializeComponent();
        }

        public void init()
        {
            timerTask = new System.Timers.Timer();
            timerTask.Enabled = false;
            timerTask.Interval = 1000;
            timerTask.Elapsed += OnTimedEvent;
            timerTask.Start();
            //timer = new System.Windows.Forms.Timer();
            //timer.Enabled = false;
            //timer.Interval = 1000;
            //timer.Tick += System.EventHandler(this.hello);
        }

        private static void OnTimedEvent(Object source, System.Timers.ElapsedEventArgs e)
        {
            try
            {
                //Console.WriteLine("The Elapsed event was raised at {0}", e.SignalTime);
                string textopath = Application.StartupPath + "\\tramas.txt";
                string[] lines = { "First line", "Second line", "Third line" };
                // WriteAllLines creates a file, writes a collection of strings to the file,
                // and then closes the file.  You do NOT need to call Flush() or Close().
                //System.IO.File.WriteAllLines(textopath, lines);
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(textopath))
                {
                    foreach (string line in lines)
                    {
                        // If the line doesn't contain the word 'Second', write the line to the file.
                        //if (!line.Contains("Second"))
                        //{
                            file.WriteLine(line);
                        //}
                    }
                }

            }
            catch(Exception ex)
            {
                string textolog = Application.StartupPath + "\\Log.txt";
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(textolog))
                {
                    file.WriteLine(textolog);
                }       
            }
            
        }

        private void hello(object sender, EventArgs e)
        {

        }

        protected override void OnStart(string[] args)
        {
            //AddingNewEventHandler timer1, AddressOf(HagoAlgo)
            timer1.Start();
        }

        protected override void OnStop()
        {
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            //StreamWriter wt = new StreamWriter();
            Console.WriteLine($"{DateTime.Now.ToString("dd/MM/yyyy")}");
        }
    }
}
