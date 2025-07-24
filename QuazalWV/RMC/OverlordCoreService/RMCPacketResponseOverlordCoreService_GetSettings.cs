using System;
using System.Collections.Generic;
using System.IO;

namespace QuazalWV
{
    public class RMCPacketResponseOverlordCoreService_GetSettings : RMCPResponse
    {
        //public List<string,Variant> Variants { get; set; }

        public RMCPacketResponseOverlordCoreService_GetSettings()
        {

        }

        public override string PayloadToString()
        {
            return "";
        }

        public override byte[] ToBuffer()
        {
            MemoryStream m = new MemoryStream();
            // Empty list of settings, should be checked with live server
            Helper.WriteU32(m, 0);
            return m.ToArray();
        }

        public override string ToString()
        {
            return "[GetSettings Response]";
        }
    }
}
