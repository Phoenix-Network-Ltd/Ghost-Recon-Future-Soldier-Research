using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuazalWV
{
    /// <summary>
    /// https://github.com/kinnay/NintendoClients/wiki/NEX-Common-Types#rvconnectiondata-structure
    /// </summary>
    class RVConnectionData
    {
        public string m_urlRegularProtocols = "prudps:/address=#ADDRESS#;port=#PORT#;CID=1;PID=#SERVERID#;sid=1;stream=3;type=2";
        public List<byte> m_lstSpecialProtocols = new List<byte>();
        public string m_urlSpecialProtocols = "";
    }

    class RMCPacketResponseAuthenticationService_Login : RMCPResponse
    {
        public uint resultCode = 0x10001;
        public uint PID;
        public byte[] ticketBuffer;
        public KerberosTicket ticket;
        public string address;
        public ushort port;
        public uint serverID;
        public RVConnectionData rvConnData = new RVConnectionData();
        public string returnMsgServerBuild;

        public RMCPacketResponseAuthenticationService_Login()
        {

        }

        public RMCPacketResponseAuthenticationService_Login(ClientInfo client, string username)
        {
            // Set the server ip for remote or local client
            address = client.isLocal ? Global.LocalServerIp : Global.RemoteServerIp;
            if(username == "Tracking")
                PID = (uint)Global.SPECIAL_PID.Tracking;
            serverID = client.sPID;
            port = client.sPort;
            ticket = new KerberosTicket(client, username);
            ticketBuffer = ticket.ToBuffer();
            returnMsgServerBuild = "the server build string";
            rvConnData.m_urlRegularProtocols = rvConnData.m_urlRegularProtocols
                .Replace("#ADDRESS#", address)
                .Replace("#PORT#", port.ToString())
                .Replace("#SERVERID#", serverID.ToString());
        }

        public override byte[] ToBuffer()
        {
            MemoryStream m = new MemoryStream();
            Helper.WriteU32(m, resultCode);
            Helper.WriteU32(m, PID);
            // kerberos ticket
            Helper.WriteU32(m, (uint)ticketBuffer.Length);
            m.Write(ticketBuffer, 0, ticketBuffer.Length);
            // secure server url
            Helper.WriteString(m, rvConnData.m_urlRegularProtocols);
            Helper.WriteU32(m, (uint)rvConnData.m_lstSpecialProtocols.Count);
            // special protocols list
            foreach (byte b in rvConnData.m_lstSpecialProtocols)
                Helper.WriteU8(m, b);
            // special protocols url
            Helper.WriteString(m, rvConnData.m_urlSpecialProtocols);
            // server build, doesnt need to be sent
            Helper.WriteString(m, returnMsgServerBuild);
            return m.ToArray();
        }

        public override string ToString()
        {
            return "[Authentication Service Login Response]";
        }

        public override string PayloadToString()
        {
            StringBuilder sb = new StringBuilder();
            string secServerUrl = rvConnData.m_urlRegularProtocols;
            sb.AppendLine("\t[Result code       : 0x" + resultCode.ToString("X8") + "]");
            sb.AppendLine("\t[PID               : 0x" + PID.ToString("X8") + "]");
            sb.AppendLine(ticket.ToString());
            sb.AppendLine("\t[Secure Server URL : " + secServerUrl + "]");
            return sb.ToString();
        }

    }
}