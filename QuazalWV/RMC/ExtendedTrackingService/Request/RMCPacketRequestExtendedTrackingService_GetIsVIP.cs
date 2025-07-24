using System.IO;

namespace QuazalWV
{
    public class RMCPacketRequestExtendedTrackingService_GetIsVIP : RMCPRequest
    {
        public string Pid { get; set; }

        public RMCPacketRequestExtendedTrackingService_GetIsVIP(Stream s)
        {
            Pid = Helper.ReadString(s);
        }

        public override string ToString()
        {
            return "[GetIsVIP Request]";
        }

        public override string PayloadToString()
        {
            return $"\t[Pid : {Pid}]";
        }

        public override byte[] ToBuffer()
        {
            MemoryStream m = new MemoryStream();
            Helper.WriteString(m, Pid);
            return m.ToArray();
        }
    }
}
