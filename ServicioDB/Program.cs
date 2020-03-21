using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;

namespace ServicioDB
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        static void Main()
        {
#if (!DEBUG)

#else
            Service1 Servicio1 = new Service1();
            Servicio1.init();
            System.Threading.Thread.Sleep(System.Threading.Timeout.Infinite);
#endif
            //ServiceBase[] ServicesToRun;
            //ServicesToRun = new ServiceBase[]
            //{
            //    new Service1()
            //};
            //ServiceBase.Run(ServicesToRun);
        }
    }
}
