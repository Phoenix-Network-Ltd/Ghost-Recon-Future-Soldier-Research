using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuazalWV
{
    public class RMCPacketRequestTrackingExtService_RegisterTrackingSessionEx : RMCPRequest
    {
        public string Pid { get; set; }

        public RMCPacketRequestTrackingExtService_RegisterTrackingSessionEx(Stream s)
        {
            Pid = Helper.ReadString(s);
        }

        public override string ToString()
        {
            return "[RegisterTrackingSessionEx Request]";
        }

        public override string PayloadToString()
        {
            return $"\t[Pid : {Pid}]";
        }

        public override byte[] ToBuffer()
        {
            MemoryStream m = new MemoryStream();
            Helper.WriteString(m, Pid);
            return m.ToArray();
        }
    }
}
