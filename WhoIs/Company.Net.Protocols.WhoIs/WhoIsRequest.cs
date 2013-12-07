using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Company.Net.Protocols.WhoIs
{
    /// <summary>
    /// Used to request whois server for domain information
    /// </summary>
    public class WhoIsRequest
    {
        /// <summary>
        /// WhoIs server name e.g. www.WhoisServer.com.
        /// </summary>
        public string Server { get; protected set; }

        /// <summary>
        /// Domain name for which the information is required.
        /// </summary>
        public string Domain { get; protected set; }

        /// <summary>
        /// The default port is 43 unless explicitly changed.
        /// </summary>
        public int Port { get; set; }

        private byte[] requestPayload = null;

        public WhoIsRequest(string server, string domain)
        {
            this.Server = server;
            this.Domain = domain;
            this.Port = 43;

            requestPayload = Encoding.ASCII.GetBytes(string.Format("{0}\r\n", this.Domain));
        }

        public string Execute()
        {
            using (TcpClient client = new TcpClient(this.Server, this.Port))
            {
                Stream stream = client.GetStream();
                stream.Write(this.requestPayload, 0, this.requestPayload.Length);

                StreamReader reader = new StreamReader(client.GetStream(), Encoding.ASCII);
                string response = reader.ReadToEnd();

                client.Close();

                return response;
            }

        }
    }
}
