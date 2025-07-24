using System.IO;

namespace QuazalWV
{
    public static class MiscService
    {
        public static void ProcessMiscServiceRequest(Stream s, RMCP rmc)
        {
            switch (rmc.methodID)
            {
                case 3:
                    break;
                case 4:
                    break;
                default:
                    Log.WriteLine(1, "[RMC Misc] Error: Unknown Method 0x" + rmc.methodID.ToString("X"));
                    break;
            }
        }

        public static void HandleMiscServiceRequest(QPacket p, RMCP rmc, ClientInfo client)
        {
            RMCPResponse reply;
            switch (rmc.methodID)
            {
                case 3:
                    reply = new RMCPacketResponseMiscFriendServices_GetGenericSettings();
                    RMC.SendResponseWithACK(client.udp, p, rmc, client, reply);
                    break;
                case 4:
                    reply = new RMCPResponseEmpty();
                    RMC.SendResponseWithACK(client.udp, p, rmc, client, reply);
                    break;
                default:
                    Log.WriteLine(1, "[RMC Misc] Error: Unknown Method 0x" + rmc.methodID.ToString("X"));
                    break;
            }
        }
    }
}
