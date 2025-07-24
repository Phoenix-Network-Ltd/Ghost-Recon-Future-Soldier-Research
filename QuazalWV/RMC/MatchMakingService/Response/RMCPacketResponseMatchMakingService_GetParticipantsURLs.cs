using System.IO;
using System.Collections.Generic;

namespace QuazalWV
{
    public class RMCPacketResponseMatchMakingService_GetParticipantsURLs : RMCPResponse
    {

        public List<string> stationURLs = new List<string>();

        public RMCPacketResponseMatchMakingService_GetParticipantsURLs()
        {
            stationURLs.Add(Global.sessionURL);
        }

        public override byte[] ToBuffer()
        {
            MemoryStream m = new MemoryStream();
            Helper.WriteStringList(m, stationURLs);
            return m.ToArray();
        }

        public override string ToString()
        {
            return "[GetParticipantsURLs Response]";
        }

        public override string PayloadToString()
        {
            return "";
        }
    }
}
