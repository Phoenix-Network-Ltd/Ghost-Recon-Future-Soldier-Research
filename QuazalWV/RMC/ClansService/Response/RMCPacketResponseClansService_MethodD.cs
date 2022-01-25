using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuazalWV
{
    public class RMCPacketResponseClansService_MethodD : RMCPResponse
    {
        public RMCPacketResponseClansService_MethodD()
        {

        }

        public override string PayloadToString()
        {
            return "";
        }

        public override byte[] ToBuffer()
        {
            MemoryStream m = new MemoryStream();
            // Unknown
            Helper.WriteU32(m, 1);
            return m.ToArray();
        }

        public override string ToString()
        {
            return "[Clan 0xD Response]";
        }
    }
}
