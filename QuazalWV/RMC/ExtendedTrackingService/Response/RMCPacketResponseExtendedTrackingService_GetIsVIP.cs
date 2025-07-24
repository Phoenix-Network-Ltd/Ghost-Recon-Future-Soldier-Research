using System.IO;

namespace QuazalWV
{
    public class RMCPacketResponseExtendedTrackingService_GetIsVIP : RMCPResponse
    {
        public bool IsVIP { get; set; }

        public RMCPacketResponseExtendedTrackingService_GetIsVIP()
        {
            IsVIP = true;
        }

        public override string ToString()
        {
            return "[GetIsVIP Response]";
        }

        public override string PayloadToString()
        {
            return $"\t[Registered : {IsVIP}]";
        }

        public override byte[] ToBuffer()
        {
            MemoryStream m = new MemoryStream();
            Helper.WriteBool(m, IsVIP);
            return m.ToArray();
        }
    }
}
