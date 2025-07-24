using System.IO;

namespace QuazalWV
{
    public static class ClansService
    {
        public static void ProcessClansServiceRequest(Stream s, RMCP rmc)
        {
            switch (rmc.methodID)
            {
                case 0xD:
                    break;
                default:
                    Log.WriteLine(1, "[RMC Clans] Error: Unknown Method 0x" + rmc.methodID.ToString("X"));
                    break;
            }
        }

        public static void HandleClansServiceRequest(QPacket p, RMCP rmc, ClientInfo client)
        {
            RMCPResponse reply;
            switch (rmc.methodID)
            {
                case 0xD:
                    reply = new RMCPacketResponseClansService_GetCurUserClan();
                    RMC.SendResponseWithACK(client.udp, p, rmc, client, reply);
                    break;
                default:
                    Log.WriteLine(1, "[RMC Clans] Error: Unknown Method 0x" + rmc.methodID.ToString("X"));
                    break;
            }
        }
    }
}
