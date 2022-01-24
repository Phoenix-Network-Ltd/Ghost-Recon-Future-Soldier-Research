using System;
using System.Collections.Generic;
using System.Net;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading.Tasks;

namespace QuazalWV
{
    public static class Global
    {
        /// <summary>
        /// Unique pids for hardcoded users.
        /// </summary>
        public enum SPECIAL_PID
        {
            /// <summary>
            /// Unique pid for 'Tracking' user.
            /// </summary>
            Tracking = 0x1111,
        }

        public static readonly string keyDATA = "CD&ML";
        /// <summary>
        /// For remote clients, configure for your environment.
        /// </summary>
        public static string RemoteServerIp = "192.168.1.70";
        /// <summary>
        /// For localhost client testing.
        /// </summary>
        public static string LocalServerIp = "127.0.0.1";
        /// <summary>
        /// Only for Kerberos ticket, hardcoded for every user.
        /// </summary>
        public static byte[] KerberosSesKey = new byte[] { 0x9C, 0xB0, 0x1D, 0x7A, 0x2C, 0x5A, 0x6C, 0x5B, 0xED, 0x12, 0x68, 0x45, 0x69, 0xAE, 0x09, 0x0D };
        public static string serverBindAddress = "127.0.0.1";
        public static uint idCounter = 0x12345678;
        public static uint pidCounter = 0x1234;
        public static uint dummyFriendPidCounter = 0x1235;
        public static string sessionURL = "prudp:/address=127.0.0.1;port=21032;RVCID=4660";
        public static List<ClientInfo> clients = new List<ClientInfo>();
        public static Stopwatch uptime = new Stopwatch();

        public static ClientInfo GetClientByEndPoint(IPEndPoint ep)
        {
            foreach (ClientInfo c in clients)
                if (c.ep.Address.ToString() == ep.Address.ToString() && c.ep.Port == ep.Port)
                    return c;
            WriteLog(1, "Error : Cant find client for end point : " + ep.ToString());
            return null;
        }

        public static ClientInfo GetClientByIDsend(uint id)
        {
            foreach (ClientInfo c in clients)
                if (c.IDsend == id)
                    return c;
            WriteLog(1, "Error : Cant find client for id : 0x" + id.ToString("X8"));
            return null;
        }

        public static ClientInfo GetClientByIDrecv(uint id)
        {
            foreach (ClientInfo c in clients)
                if (c.IDrecv == id)
                    return c;
            WriteLog(1, "Error : Cant find client for id : 0x" + id.ToString("X8"));
            return null;
        }

        private static void WriteLog(int priority, string s)
        {
            Log.WriteLine(priority, "[Global] " + s);
        }
    }
}
