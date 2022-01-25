using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuazalWV
{
    public class RMCPacketRequestFriendsService_GetRelationships : RMCPRequest
    {
        ResultRange Range { get; set; }

        public RMCPacketRequestFriendsService_GetRelationships(Stream s)
        {
            Range = new ResultRange(s);
        }

        public override string PayloadToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"\t[Range offset: {Range.Offset}]");
            sb.AppendLine($"\t[Range Size: {Range.Size}]");
            return sb.ToString();
        }

        public override byte[] ToBuffer()
        {
            MemoryStream m = new MemoryStream();
            Range.ToBuffer(m);
            return m.ToArray();
        }

        public override string ToString()
        {
            return "[GetRelationships Request]";
        }
    }
}
