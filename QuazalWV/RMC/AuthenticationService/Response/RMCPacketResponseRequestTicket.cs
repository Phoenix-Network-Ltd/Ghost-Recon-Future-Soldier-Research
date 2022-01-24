using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuazalWV
{
    public class RMCPacketResponseRequestTicket : RMCPResponse
    {
        public uint resultCode = 0x10001;
        public byte[] ticketBuffer;
        public KerberosTicket ticket;

        public RMCPacketResponseRequestTicket(ClientInfo client, uint pid)
        {
            // Check for special users like 'Tracking'
            switch(pid)
            {
                // 'Tracking' user
                case (uint)Global.SPECIAL_PID.Tracking:
                    ticket = new KerberosTicket(client, "Tracking");
                    break;
                // Regular Ubi Connect user
                default:
                    ticket = new KerberosTicket(client, client.name);
                    break;
            }
            ticketBuffer = ticket.ToBuffer();
        }

        public override byte[] ToBuffer()
        {
            MemoryStream m = new MemoryStream();
            Helper.WriteU32(m, resultCode);
            Helper.WriteU32(m, (uint)ticketBuffer.Length);
            foreach (byte b in ticketBuffer)
                Helper.WriteU8(m, b);
            return m.ToArray();
        }

        public override string ToString()
        {
            return "[RequestTicket Response]";
        }

        public override string PayloadToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("\t[Result Code   : 0x" + resultCode.ToString("X8") + "]");
            sb.Append("\t[Ticket Buffer : { ");
            foreach (byte b in ticketBuffer)
                sb.Append(b.ToString("X2") + " ");
            sb.AppendLine("}]");
            return sb.ToString();
        }
    }
}
