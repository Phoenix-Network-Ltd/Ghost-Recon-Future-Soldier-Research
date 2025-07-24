using System.IO;

namespace QuazalWV
{
    public static class ExtendedTrackingService
    {
        public static void ProcessTrackingExtServiceRequest(Stream s, RMCP rmc)
        {
            switch (rmc.methodID)
            {
                case 1:
                    rmc.request = new RMCPacketRequestExtendedTrackingService_GetIsVIP(s);
                    break;
                default:
                    Log.WriteLine(1, "[RMC Tracking Ext] Error: Unknown Method 0x" + rmc.methodID.ToString("X"));
                    break;
            }
        }

        public static void HandleTrackingExtServiceRequest(QPacket p, RMCP rmc, ClientInfo client)
        {
            RMCPResponse reply;
            switch (rmc.methodID)
            {
                case 1:
                    reply = new RMCPacketResponseExtendedTrackingService_GetIsVIP();
                    RMC.SendResponseWithACK(client.udp, p, rmc, client, reply);
                    break;
                default:
                    Log.WriteLine(1, "[RMC Tracking Ext] Error: Unknown Method 0x" + rmc.methodID.ToString("X"));
                    break;
            }
        }
    }
}
