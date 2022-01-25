using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuazalWV
{
    public class RMCPacketRequestTitleStorageService_BrowseContentsByType : RMCPRequest
    {
        public string ContentType { get; set; }
        public uint Flags { get; set; }
        public byte FlagsMaskType { get; set; }
        public uint ExtendedFlags { get; set; }
        public byte ExtendedFlagsMaskType { get; set; }

        public RMCPacketRequestTitleStorageService_BrowseContentsByType(Stream s)
        {
            ContentType = Helper.ReadString(s);
            Flags = Helper.ReadU32(s);
            FlagsMaskType = Helper.ReadU8(s);
            ExtendedFlags = Helper.ReadU32(s);
            ExtendedFlagsMaskType = Helper.ReadU8(s);
        }

        public override string PayloadToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"\t[ContentType      : {ContentType}]");
            sb.AppendLine($"\t[Flags            : {Flags}]");
            sb.AppendLine($"\t[FlagsMaskType    : {FlagsMaskType}]");
            sb.AppendLine($"\t[ExtendedFlags    : {ExtendedFlags}]");
            sb.AppendLine($"\t[ExtFlagsMaskType : {ExtendedFlagsMaskType}]");
            return sb.ToString();
        }

        public override byte[] ToBuffer()
        {
            MemoryStream m = new MemoryStream();
            Helper.WriteString(m, ContentType);
            Helper.WriteU32(m, Flags);
            Helper.WriteU8(m, FlagsMaskType);
            Helper.WriteU32(m, ExtendedFlags);
            Helper.WriteU8(m, ExtendedFlagsMaskType);
            return m.ToArray();
        }

        public override string ToString()
        {
            return "[BrowseContentsByType Request]";
        }
    }
}
