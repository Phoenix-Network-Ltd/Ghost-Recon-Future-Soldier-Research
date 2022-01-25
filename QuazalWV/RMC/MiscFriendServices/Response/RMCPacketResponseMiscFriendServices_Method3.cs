using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuazalWV
{
    public class RMCPacketResponseMiscFriendServices_Method3 : RMCPResponse
    {
        public List<MiscFriendObject> Objects { get; set; }

        public RMCPacketResponseMiscFriendServices_Method3()
        {
            Objects = new List<MiscFriendObject>();
        }

        public override string ToString()
        {
            return "[MiscFriendServices Method 3]";
        }

        public override string PayloadToString()
        {
            return "";
        }

        public override byte[] ToBuffer()
        {
            MemoryStream m = new MemoryStream();
            Helper.WriteU32(m, (uint)Objects.Count);
            foreach (MiscFriendObject o in Objects)
                o.ToBuffer(m);
            return m.ToArray();
        }
    }
}
