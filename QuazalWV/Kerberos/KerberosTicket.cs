using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace QuazalWV
{
    public class KerberosTicket
    {
        public uint userPID;
        public byte[] sessionKey = Global.KerberosSesKey;
        public uint serverPID;
        public byte[] ticket = new byte[] { 0x76, 0x21, 0x4B, 0xA6, 0x21, 0x96, 0xD3, 0xF3, 0x9A, 0x8C, 0x7A, 0x27, 0x0D, 0xD9, 0xB3, 0xFA, 0x21, 0x0E, 0xED, 0xAF, 0x42, 0x63, 0x92, 0x95, 0xC1, 0x16, 0x54, 0x08, 0xEE, 0x6E, 0x69, 0x17, 0x35, 0x78, 0x2E, 0x6E };
        public byte[] encKey = null;

        /// <summary>
        /// Processes user for which the key is generated.
        /// </summary>
        /// <param name="client"></param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        public KerberosTicket(ClientInfo client, string username)
        {
            userPID = client.PID;
            serverPID = client.sPID;
            // Process user login
            switch(username)
            {
                // Tracking service user (hardcoded)
                case "Tracking":
                    encKey = DeriveKey((uint)Global.SPECIAL_PID.Tracking, "JaDe!");
                    break;
                // A regular Ubisoft Connect user, PASSWORD IS NOT USED
                default:
                    encKey = DeriveKey(userPID);
                    break;
            }
        }

        /// <summary>
        /// Pass user's password as input
        /// For tracking service, Auth Service (1) Login method is used and the following credentials are used:
        /// Username: Tracking
        /// Password: JaDe!
        /// For regular users Auth Service (2) LoginEx passes Ubisoft Connect password.
        /// This is very dangerous and not even a hash should ever be possible to be obtained in its raw RC4ed form.
        /// </summary>
        /// <param name="pid"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static byte[] DeriveKey(uint pid, string password = "UbiDummyPwd")
        {
            uint count = 65000 + (pid % 1024);
            MD5 md5 = MD5.Create();
            byte[] buff = Encoding.ASCII.GetBytes(password);
            for (uint i = 0; i < count; i++)
                buff = md5.ComputeHash(buff);
            return buff;
        }

        public byte[] ToBuffer()
        {
            MemoryStream m = new MemoryStream();
            m.Write(sessionKey, 0, 16);
            Helper.WriteU32(m, serverPID);
            Helper.WriteU32(m, (uint)ticket.Length);
            m.Write(ticket, 0, ticket.Length);
            byte[] buff = m.ToArray();
            buff = Helper.Encrypt(encKey, buff);
            byte[] hmac = Helper.MakeHMAC(encKey, buff);
            m = new MemoryStream();
            m.Write(buff, 0, buff.Length);
            m.Write(hmac, 0, hmac.Length);
            return m.ToArray();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("\t[Kerberos Ticket]");
            sb.Append("\t\t[Session Key : { ");
            foreach (byte b in sessionKey)
                sb.Append(b.ToString("X2") + " ");
            sb.AppendLine("}]");
            sb.AppendLine("\t\t[Server PID : 0x" + serverPID.ToString("X8"));
            sb.Append("\t\t[Ticket Data : { ");
            foreach (byte b in ticket)
                sb.Append(b.ToString("X2") + " ");
            sb.AppendLine("}]");
            return sb.ToString();
        }
    }
}