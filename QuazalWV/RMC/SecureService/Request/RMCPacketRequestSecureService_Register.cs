using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuazalWV
{
    public class RMCPacketRequestSecureService_Register : RMCPRequest
    {
        public List<string> stationUrls;

        public RMCPacketRequestSecureService_Register(Stream s)
        {
            stationUrls = Helper.ReadStringList(s);
        }

        public override byte[] ToBuffer()
        {
            MemoryStream result = new MemoryStream();
            Helper.WriteStringList(result, stationUrls);
            return result.ToArray();
        }

        public override string ToString()
        {
            return "[Register Request]";
        }

        public override string PayloadToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("\t[Station List :]");
            foreach (string s in stationUrls)
                sb.AppendLine("\t\t\t[\"" + s + "\"]");
            return sb.ToString();
        }
    }
}