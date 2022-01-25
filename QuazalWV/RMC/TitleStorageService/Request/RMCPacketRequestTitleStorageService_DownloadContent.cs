using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuazalWV
{
    public class RMCPacketRequestTitleStorageService_DownloadContent : RMCPRequest
    {
        public uint ContentId { get; set; }

        public RMCPacketRequestTitleStorageService_DownloadContent(Stream s)
        {
            ContentId = Helper.ReadU32(s);
        }

        public override string ToString()
        {
            return "[DownloadContent Request]";
        }

        public override string PayloadToString()
        {
            return $"\t[ContentId : {ContentId}]";
        }

        public override byte[] ToBuffer()
        {
            MemoryStream m = new MemoryStream();
            Helper.WriteU32(m, ContentId);
            return m.ToArray();
        }
    }
}
