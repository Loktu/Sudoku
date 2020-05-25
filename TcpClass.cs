using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace TcpConnection
{
    sealed public class TcpClass : IDisposable
    {
        private TcpListener tcpListener=null;
        private TcpClient tcpClient = null;
        public delegate void writeNewString(string s);
        public event writeNewString evWriteNewString = null;

        public EventHandler<MessageArgs> Receiving;
        public class MessageArgs : EventArgs
        {
            public string message;
            public MessageArgs(string message)
            {
                this.message = message;
            }
        }

        public TcpClass()
        {
        }

        public void Send(string message)
        {
            if (evWriteNewString != null)
                evWriteNewString(message);
        }

        public void Receive(string message)
        {
            if (Receiving != null)
            {
                Receiving(this, new MessageArgs(message));
            }
        }

        private async void DoTheExchange(TcpClient tc)
        {
            NetworkStream ns = tc.GetStream();
            var u8enc = new UTF8Encoding(false);
            // adding a writer to this stream
            evWriteNewString += delegate(string msg)
            {
                if (!ns.CanWrite)
                    return;
                var bb = u8enc.GetBytes(msg);
                ns.Write(bb, 0, bb.Length);
            };
            try
            {
                const int bm = 4096;
                byte[] b = new byte[bm];
                int r;
                while (0 < (r = await ns.ReadAsync(b, 0, bm)))
                {
                    string s = u8enc.GetString(b);
                    Receive(s);
                }
            }
            catch
            {
                   //Receive(string.Format("got exception {0}", ex.Message));
            }
            ns.Close();
        }

        public void Stop()
        {
            if (tcpListener != null)
                tcpListener.Stop();
            tcpListener = null;

            evWriteNewString = null;

            if (tcpClient != null)
                tcpClient.Close();
            tcpClient = null;
        }

#pragma warning disable CA1063 // Implement IDisposable Correctly
      public void Dispose()
#pragma warning restore CA1063 // Implement IDisposable Correctly
      {
            Stop();
        }

        public void StopServer()
        {
            if (tcpListener != null)
            {
                tcpListener.Stop();
                tcpListener = null;
            }
        }
        public void StopClient()
        {
            if (tcpClient != null)
            {
                tcpClient.Close();
            }
        }

        public async void RunServer(string host, int port)
        {
            tcpListener = new TcpListener(IPAddress.Any, port);
            tcpListener.Start();
            try
            {
                while (true) // until exeption
                {
                    await Accept(await tcpListener.AcceptTcpClientAsync());
                }
            }
            catch { }
            finally { if (tcpListener != null) tcpListener.Stop(); }
        }

        async Task Accept(TcpClient tcpClient)
        {
            await Task.Yield();
            DoTheExchange(tcpClient);
        }

        public async void RunClient(string host, int port)
        {
            tcpClient = new TcpClient();
            try
            {
                await tcpClient.ConnectAsync(host, port);
                if (tcpClient.Connected)
                    DoTheExchange(tcpClient);
            }
            catch
            { }
            
        }

    }
}
