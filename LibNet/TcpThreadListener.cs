using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace mognetwork
{
    public class TcpThreadListener
    {
        private Thread thread;
        private ListenerHandler handler;
        private TcpSocket socket;

        /// <summary>
        /// Create the listener
        /// </summary>
        /// <param name="handler">The handler</param>
        /// <param name="socket">The CONNECTED socket (need to be connected to a server)</param>
        public TcpThreadListener(ListenerHandler handler, TcpSocket socket)
        {
            this.handler = handler;
            this.socket = socket;
            thread = new Thread(run);
        }

        public void start()
        {
            thread.Start();
        }

        public void wait()
        {
            thread.Join();
        }

        public void stop()
        {
            thread.Interrupt(); // THIS IS NOT GOOD. I HAVE TO DO IT AGAIN AFTER.
        }

        // Not good. But, will work.
        public void run()
        {
            while (true)
            {
                handler.onMessageReceived(socket.receiveDatas());
            }
        }
    }
}
