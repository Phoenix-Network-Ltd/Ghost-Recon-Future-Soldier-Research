using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuazalWV
{
    public static class TrackingExtService
    {
        public static void ProcessTrackingExtServiceRequest(Stream s, RMCP rmc)
        {
            switch (rmc.methodID)
            {
                case 1:
                    rmc.request = new RMCPacketRequestTrackingExtService_RegisterTrackingSessionEx(s);
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
                    reply = new RMCPacketResponseTrackingExtService_RegisterTrackingSessionEx();
                    RMC.SendResponseWithACK(client.udp, p, rmc, client, reply);
                    break;
                default:
                    Log.WriteLine(1, "[RMC Tracking Ext] Error: Unknown Method 0x" + rmc.methodID.ToString("X"));
                    break;
            }
        }
    }
}
