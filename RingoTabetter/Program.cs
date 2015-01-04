using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Owin.Hosting;
using System.Threading;

namespace RingoTabetter
{
    class Program
    {
        private static ManualResetEvent _quitEvent = new ManualResetEvent(false);

        static void Main(string[] args)
        {
            var port = 8765;
            if (args.Length > 0)
            {
                int.TryParse(args[0], out port);
            }


            Console.CancelKeyPress += (sender, eArgs) =>
            {
                _quitEvent.Set();
                eArgs.Cancel = true;
            };


            using (WebApp.Start<Startup>(string.Format("http://+:{0}", port)))
            {
                Console.WriteLine("Running port: {0}", port);
                Console.WriteLine("Started");
                _quitEvent.WaitOne();
            }
        }
    }
}
