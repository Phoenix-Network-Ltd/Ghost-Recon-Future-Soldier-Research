using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuazalWV
{
    public class RMCPacketRequestTelemetryService_GetConfiguration : RMCPResponse
    {
        List<string> Tags { get; set; }

        public RMCPacketRequestTelemetryService_GetConfiguration()
        {
            Tags = new List<string>()
            {
                "TestPhoenixTag"
            };
        }

        public override byte[] ToBuffer()
        {
            MemoryStream m = new MemoryStream();
            Helper.WriteU32(m, (uint)Tags.Count);
            foreach (string tag in Tags)
                Helper.WriteString(m, tag);
            return m.ToArray();
        }

        public override string PayloadToString()
        {
            return "";
        }

        public override string ToString()
        {
            return "[Telemetry GetConfiguration]";
        }

    }
}
