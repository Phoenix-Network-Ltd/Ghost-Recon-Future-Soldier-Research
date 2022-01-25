using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuazalWV
{
    public class RMCPacketRequestPrivilegesService_GetPrivilegesEx : RMCPRequest
    {
        public string LocaleCode { get; set; }

        public RMCPacketRequestPrivilegesService_GetPrivilegesEx(Stream s)
        {
            LocaleCode = Helper.ReadString(s);
        }

        public override string PayloadToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"\t[Locale : {LocaleCode}]");
            return sb.ToString();
        }

        public override byte[] ToBuffer()
        {
            MemoryStream m = new MemoryStream();
            Helper.WriteString(m, LocaleCode);
            return m.ToArray();
        }

        public override string ToString()
        {
            return "[GetPrivilegesEx Request]";
        }
    }
}
