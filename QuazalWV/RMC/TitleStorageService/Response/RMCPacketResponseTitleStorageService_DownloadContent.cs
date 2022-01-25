using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuazalWV
{
    public class RMCPacketResponseTitleStorageService_DownloadContent : RMCPResponse
    {
        public string Protocol { get; set; }
        public string Host { get; set; }
        public string Path { get; set; }

        public RMCPacketResponseTitleStorageService_DownloadContent()
        {
            Protocol = "http";
            Host = "localhost";
            Path = "/OnlineConfigService.svc/GetOnlineConfig";
        }

        public override string ToString()
        {
            return "[DownloadContent Response]";
        }

        public override string PayloadToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"\t[Proto : {Protocol}]");
            sb.AppendLine($"\t[Host  : {Host}]");
            sb.AppendLine($"\t[Path  : {Path}]");
            return sb.ToString();
        }

        public override byte[] ToBuffer()
        {
            MemoryStream m = new MemoryStream();
            Helper.WriteString(m, Protocol);
            Helper.WriteString(m, Host);
            Helper.WriteString(m, Path);
            return m.ToArray();
        }
    }
}
