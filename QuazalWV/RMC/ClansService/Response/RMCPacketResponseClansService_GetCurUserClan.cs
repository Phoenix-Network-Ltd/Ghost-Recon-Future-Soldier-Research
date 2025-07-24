using System.IO;

namespace QuazalWV
{
    public class RMCPacketResponseClansService_GetCurUserClan : RMCPResponse
    {
        public uint ClanId { get; set; }

        public RMCPacketResponseClansService_GetCurUserClan()
        {
            ClanId = 1;
        }

        public override string PayloadToString()
        {
            return "";
        }

        public override byte[] ToBuffer()
        {
            MemoryStream m = new MemoryStream();
            Helper.WriteU32(m, ClanId);
            return m.ToArray();
        }

        public override string ToString()
        {
            return "[GetCurUserClan Response]";
        }
    }
}
