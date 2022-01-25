using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuazalWV
{
    public class RMCPacketRequestUPlayWinService_GetActionsForUser : RMCPRequest
    {
        public string Username { get; set; }

        public RMCPacketRequestUPlayWinService_GetActionsForUser(Stream s)
        {
            Username = Helper.ReadString(s);
        }

        public override string PayloadToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"\t[User: {Username}]");
            return sb.ToString();
        }

        public override byte[] ToBuffer()
        {
            MemoryStream m = new MemoryStream();
            Helper.WriteString(m, Username);
            return m.ToArray();
        }

        public override string ToString()
        {
            return "[GetActionsForUser Request]";
        }
    }
}
