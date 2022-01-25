using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuazalWV
{
    public class RMCPacketResponseTrackingExtService_RegisterTrackingSessionEx : RMCPResponse
    {
        public bool Registered { get; set; }

        public RMCPacketResponseTrackingExtService_RegisterTrackingSessionEx()
        {
            Registered = true;
        }

        public override string ToString()
        {
            return "[RegisterTrackingSessionEx Response]";
        }

        public override string PayloadToString()
        {
            return $"\t[Registered : {Registered}]";
        }

        public override byte[] ToBuffer()
        {
            MemoryStream m = new MemoryStream();
            Helper.WriteBool(m, Registered);
            return m.ToArray();
        }
    }
}
