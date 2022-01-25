using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuazalWV
{
    /// <summary>
    /// Request name assumed.
    /// </summary>
    public class RMCPacketRequestRichPresenceService_StartPresence : RMCPRequest
    {
        public uint UnkUint { get; set; }
        public string Id { get; set; }

        public RMCPacketRequestRichPresenceService_StartPresence(Stream s)
        {
            UnkUint = Helper.ReadU32(s);
            Id = Helper.ReadString(s);
        }

        public override string ToString()
        {
            return "[StartPresence Request]";
        }

        public override string PayloadToString()
        {
            throw new NotImplementedException();
        }

        public override byte[] ToBuffer()
        {
            MemoryStream m = new MemoryStream();
            Helper.WriteU32(m, UnkUint);
            Helper.WriteString(m, Id);
            return m.ToArray();
        }
    }
}
