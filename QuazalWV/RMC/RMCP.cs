using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuazalWV
{
    public class RMCP
    {
        public enum PROTOCOL
        {
            NATTraversalRelayProtocol = 3,
            AuthenticationService = 0xA,
            SecureService = 0xB,
            BackendServices = 0xE,
            FriendsService = 0x14,
            MatchMakingService = 0x15,
            PersistentStoreService = 0x18,
            AccountMgmtService = 0x19,
            MessageDeliveryProtocol = 0x1B,
            NewsService = 0x1F,
            UbiNewsService = 0x21,
            PrivilegesService = 0x23,
            TelemetryService = 0x24,
            LocalizationService = 0x27,
            GameSessionService = 0x2A,
            UbiFriendsService = 0x2F,
            TitleStorageService = 0x33,
            SearchFriendsService = 0x56,
            FriendMessagesExtService = 0x57,
            PlayerStatisticsService = 0x6C,
            RichPresenceProtocol = 0x6D,
            ClansService = 0x6E,
            MiscFriendServices = 0x6F,
            IP2LocationService = 0x70,
            GameInfoService = 0x71,
            ContactsExtensionService = 0x72,
            HermesAchievementsService = 0x74,
            SocialNetworksService = 0x75,
            GameStorageFileVersionService = 0x76,
            GR5AwardService = 0x77,
            UplayWinService = 0x78,
            MapListService = 0x79,
            TrackingExtService = 0x7D,
            EventsTrackingService = 0x7E,
            OnlinePassProtocolService = 0x7F,
            RPNEProtocolService = 0x1389,
            OverlordNewsProtocolService = 0x138A,
            OverlordCoreProtocolService = 0x138B,
            ExtraContentProtocolService = 0x138C,
            OverlordFriendsProtocolService = 0x138D,
            OverlordAwardsProtocolService = 0x138E,
            OverlordChallengeProtocolService = 0x138F,
            OverlordDareProtocolService = 0x1390
        }

        public PROTOCOL proto;
        public bool isRequest;
        public bool success;
        public uint error;
        public uint callID;
        public uint methodID;
        public RMCPRequest request;
        public int _afterProtocolOffset;

        public RMCP()
        {
        }

        public RMCP(QPacket p)
        {
            MemoryStream m = new MemoryStream(p.payload);
            Helper.ReadU32(m);
            ushort b = Helper.ReadU8(m);
            isRequest = (b >> 7) == 1;
            try
            {
                if ((b & 0x7F) != 0x7F)
                    proto = (PROTOCOL)(b & 0x7F);
                else
                {
                    b = Helper.ReadU16(m);
                    proto = (PROTOCOL)(b);
                }
            }
            catch
            {
                Log.WriteLine(1, "[RMC Packet] Error: Unknown RMC packet protocol 0x" + b.ToString("X2"));
                return;
            }
            _afterProtocolOffset = (int)m.Position;
        }
        

        public override string ToString()
        {
            return "[RMC Packet : Proto = " + proto + " CallID=" + callID + " MethodID=" + methodID + "]";
        }

        public string PayLoadToString()
        {
            StringBuilder sb = new StringBuilder();
            if (request != null)
                sb.Append(request);
            return sb.ToString();
        }

        public byte[] ToBuffer()
        {
            MemoryStream result = new MemoryStream();
            byte[] buff = request.ToBuffer();
            Helper.WriteU32(result, (uint)(buff.Length + 9));
            byte b = (byte)proto;
            if (isRequest)
                b |= 0x80;
            Helper.WriteU8(result, b);
            Helper.WriteU32(result, callID);
            Helper.WriteU32(result, methodID);
            result.Write(buff, 0, buff.Length);
            return result.ToArray();
        }
    }
}
