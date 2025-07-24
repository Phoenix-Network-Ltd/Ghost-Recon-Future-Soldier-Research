using System.Collections.Generic;
using System.IO;

namespace QuazalWV
{
    public class RMCPacketResponseMiscFriendServices_GetGenericSettings : RMCPResponse
    {
        public List<GenericSetting> Objects { get; set; }

        public RMCPacketResponseMiscFriendServices_GetGenericSettings()
        {
            Objects = new List<GenericSetting>();
        }

        public override string ToString()
        {
            return "[GetGenericSettings Response]";
        }

        public override string PayloadToString()
        {
            return "";
        }

        public override byte[] ToBuffer()
        {
            MemoryStream m = new MemoryStream();
            Helper.WriteU32(m, (uint)Objects.Count);
            foreach (GenericSetting o in Objects)
                o.ToBuffer(m);
            return m.ToArray();
        }
    }
}
